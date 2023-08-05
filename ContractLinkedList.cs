using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THE_WITCHER
{
    //implements a linked list data structure to store ContractNode objects
    class ContractLinkedList : IEnumerable<ContractNode>
    {
        private ContractNode head;
        private ContractNode tail;

        public void Clear()
        {
            head = null;
            tail = null;
        }
        public void AddLast(Contract contract)
        {
            ContractNode newNode = new ContractNode { Contract = contract };

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
        }

        public ContractNode GetNext(ContractNode node)
        {
            return node.Next;
        }

        public IEnumerator<ContractNode> GetEnumerator()
        {
            ContractNode current = head;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
