using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THE_WITCHER
{
    // implementing the SearchContracts methode
    class WitcherProgram
    {

        public /*static*/ ContractLinkedList SearchContracts(ContractLinkedList contracts, int adventureLength, string initialCity, WitcherGraph witcherGraph)
        {
            ContractLinkedList optimalContracts = new ContractLinkedList();
            int minHazardLevel = int.MaxValue;
            int maxGoldReward = int.MinValue;
            string currentCity = initialCity;
            int daysRemaining = adventureLength - 1;

            HashSet<Contract> addedContracts = new HashSet<Contract>(); // Track added contracts

            foreach (var contractNode in contracts)
            {
                if (contractNode.Contract.HazardLevel < minHazardLevel)
                {
                    minHazardLevel = contractNode.Contract.HazardLevel;
                    optimalContracts.Clear();
                    optimalContracts.AddLast(contractNode.Contract);
                }
                else if (contractNode.Contract.HazardLevel == minHazardLevel)
                {
                    optimalContracts.AddLast(contractNode.Contract);
                }

                if (contractNode.Contract.GoldReward > maxGoldReward)
                {
                    maxGoldReward = contractNode.Contract.GoldReward;
                    optimalContracts.Clear();
                    optimalContracts.AddLast(contractNode.Contract);
                }
                else if (contractNode.Contract.GoldReward == maxGoldReward)
                {
                    optimalContracts.AddLast(contractNode.Contract);
                }

                addedContracts.Add(contractNode.Contract); // Add contracts to the HashSet
            }

            while (daysRemaining > 0)
            {
                bool foundContract = false;

                foreach (var contractNode in contracts)
                {
                    if (contractNode.Contract.HazardLevel == minHazardLevel && contractNode.Contract.GoldReward == maxGoldReward)
                    {
                        if (!addedContracts.Contains(contractNode.Contract)) // Check if contract already added
                        {
                            optimalContracts.AddLast(contractNode.Contract);
                            addedContracts.Add(contractNode.Contract);
                            foundContract = true;
                            break;
                        }
                    }
                }

                if (foundContract)
                    break;

                ContractLinkedList adjacentContracts = new ContractLinkedList();

                foreach (var contractNode in contracts)
                {
                    if (witcherGraph.AreConnected(currentCity, contractNode.Contract.City))
                    {
                        adjacentContracts.AddLast(contractNode.Contract);
                    }
                }

                ContractNode nextContractNode = null;

                foreach (var contractNode in adjacentContracts)
                {
                    if (!addedContracts.Contains(contractNode.Contract)) 
                    {
                        if (nextContractNode == null || contractNode.Contract.GoldReward > nextContractNode.Contract.GoldReward)
                        {
                            nextContractNode = contractNode;
                        }
                    }
                }

                if (nextContractNode != null)
                {
                    optimalContracts.AddLast(nextContractNode.Contract);
                    addedContracts.Add(nextContractNode.Contract);
                    minHazardLevel = nextContractNode.Contract.HazardLevel;
                    maxGoldReward = nextContractNode.Contract.GoldReward;
                    currentCity = nextContractNode.Contract.City;
                    daysRemaining--;
                }
                else
                {
                    break;
                }
            }

            return optimalContracts;
        }

    }

}
