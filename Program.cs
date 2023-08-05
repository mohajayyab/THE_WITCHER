using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THE_WITCHER;

internal class Program
{
    static void Main()
    {

        // Create the Witcher graph
        string[] cityNames = { "Novigrad", "Vizima", "Oxenfurt", "Beauclair", "Kaer Morhen", "Gors Velen", "Tretogor", "Rivia", "Nilfgaard", "Mahakam" };
        WitcherGraph witcherGraph = new WitcherGraph(cityNames);

        // Add connections between cities
        witcherGraph.AddConnection("Novigrad", "Vizima");
        witcherGraph.AddConnection("Vizima", "Oxenfurt");
        witcherGraph.AddConnection("Rivia", "Beauclair");
        witcherGraph.AddConnection("Oxenfurt", "Beauclair");
        witcherGraph.AddConnection("Kaer Morhen", "Novigrad");
        witcherGraph.AddConnection("Nilfgaard", "Tretogor");
        witcherGraph.AddConnection("Nilfgaard", "Mahakam");
        witcherGraph.AddConnection("Gors Velen", "Oxenfurt");
        witcherGraph.AddConnection("Vizima", "Mahakam");
        witcherGraph.AddConnection("Vizima", "Novigrad");


        // generate contracts (randomly)
        ContractLinkedList contracts = new ContractLinkedList();
        Random random = new Random();

        for (int i = 0; i < 20; i++)
        {
            Contract contract = new Contract();
            contract.TypeOfMonster = $"Monster{i + 1}";
            contract.HazardLevel = random.Next(1, 11);
            contract.GoldReward = random.Next(100, 1001);

            // Set the City property of the contract
            contract.City = cityNames[random.Next(0, cityNames.Length)];

            contracts.AddLast(contract);
        }

        Console.WriteLine("Welcome to Geralt of Rivia's Witcher world");
        Console.WriteLine("Cities of advanure: Novigrad, Vizima, Oxenfurt, Beauclair, Kaer Morhen, Gors Velen, Tretogor, Rivia, Nilfgaard, Mahakam\n");

        // Get user input for adventure length and initial city
        Console.Write("Enter the number of days for Geralt's adventure: ");
        int adventureLength = int.Parse(Console.ReadLine());

        Console.Write("Enter the initial city: ");
        string initialCity = Console.ReadLine();

        // Search for optimal contracts
            WitcherProgram witcherprgoram = new WitcherProgram();
        ContractLinkedList optimalContracts = witcherprgoram.SearchContracts(contracts, adventureLength, initialCity, witcherGraph);

        // Print optimal contracts
        Console.WriteLine("\nOptimal Contracts:");
        foreach (var contractNode in optimalContracts)
        {
            Console.WriteLine($"Monster: {contractNode.Contract.TypeOfMonster}, Hazard Level: {contractNode.Contract.HazardLevel}, Gold Reward: {contractNode.Contract.GoldReward}");
        }
    }
}

 


