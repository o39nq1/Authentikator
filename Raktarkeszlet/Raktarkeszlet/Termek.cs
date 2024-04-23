using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktarkeszlet
{
    public class Termek
    {
        public int id { get; set; }
        public string nev { get; set; }
        public int keszlet { get; set; }
        public string inventory_id { get; set; }
    }
}
