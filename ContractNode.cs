using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THE_WITCHER
{
    public class ContractNode
    {
        public Contract Contract { get; set; }
        public ContractNode Next { get; set; }
    }
}
