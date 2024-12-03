using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Stats:
    1. HP
    2. DMG
    3. Armor
   (4.Fear)
 */

namespace Main
{
    public class MainCharacter
    {
        public MainCharacter() 
        {
            HitPoints = 1000;
            Damage = 66;
            Armor = 13;
        }

        public int HitPoints { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
    }
}
