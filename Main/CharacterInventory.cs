using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Inventory:
    1. Ammo
    2. Heal
    3. Armor Parts
 */

namespace Main
{
    public class Inventory
    {
        public Inventory()
        {
            Knife = "Yes";
            Bullets = 7;
            Arrows = 20;
            HollyWaterBottles = 0;
            Bandages = 1;
            FirstAidSpray = 0;
            ArmorBuffs = 0;
        }

        public string Knife {  get; set; }
        public int Bullets { get; set; }
        public int Arrows { get; set; }
        public int HollyWaterBottles { get; set; }
        public int Bandages { get; set; }
        public int FirstAidSpray { get; set; }
        public int ArmorBuffs { get; set; } 
    }
}
