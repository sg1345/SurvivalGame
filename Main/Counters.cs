using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Counters:
    1. Enemies killed
    2. Soulles, Hunter, Hidden, Demon
 */

namespace Main
{
    public class Counters
    {
        public Counters() 
        {
            Soulles = 0;
            Hunters = 0;
            Hiddens = 0;
            Demons = 0;
            Total = 0;            
        }

        public int Soulles { get; set; }
        public int Hunters { get; set; }
        public int Hiddens { get; set; }
        public int Demons { get; set; }
        public int Total { get; set; }
    }
}
