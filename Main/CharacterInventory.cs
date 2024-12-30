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
    class Armor
    {
        string Helmet { get; set; }
        string ChestArmor { get; set; }
        string Gloves { get; set; }
        string Pants { get; set; }
        string Shoes { get; set; }
    }
    public class Inventory
    {
        public Inventory()
        {
            MeleeWeapon = "Kitchen Knife";
            RangeWeapon = "Pistol - USP-S";
            Bullets = 7;
            //Arrows = 20;
            HollyWaterBottles = 1;
            Bandages = 1;
            FirstAidSpray = 0;            
            AddArmory();

        }


        public string MeleeWeapon {  get; set; }
        public string RangeWeapon {  get; set; }
        public int Bullets { get; set; }
        //public int Arrows { get; set; }
        public int HollyWaterBottles { get; set; }
        public int Bandages { get; set; }
        public int FirstAidSpray { get; set; }
        public Dictionary<string,int> ArmorNameAndBonus { get; set; } 

        public int RangeDamageBonus()
        {
            string rangeWeapon = RangeWeapon;
            int damageBonus = 0;

            switch (rangeWeapon)
            {
                case "Pistol - USP-S":
                    damageBonus = 120;
                    break;
                case "Pistol - Desert Eagle":
                    damageBonus = 140;
                    break;
                case "Rifle - AK-47":
                    damageBonus = 160;
                    break;
                case "Rifle - M4A1-S":
                    damageBonus = 180;
                    break;
                case "Shotgun - Nova":
                    damageBonus = 1000;
                    break;
            } 
            return damageBonus;
        }
        public int MeleeDamageBonus()
        {
            string meleeWeapon = MeleeWeapon;
            int damageBonus = 0;

            switch (meleeWeapon)
            {
                case "Kitchen Knife":
                    damageBonus = 10;
                    break;
                case "Baseball Bat":
                    damageBonus = 20;
                    break;
                case "Shovel":
                    damageBonus = 30;
                    break;
                case "Axe":
                    damageBonus = 40;
                    break;
                case "Chainsaw":
                    damageBonus = 100;
                    break;
            }
            return damageBonus;
        }

        public int MeleeAttackBonus()
        {
            string meleeWeapon = MeleeWeapon;
            int attackBonus = 0;

            switch (meleeWeapon)
            {
                case "Kitchen Knife":
                    attackBonus = 3;
                    break;
                case "Baseball Bat":
                    attackBonus = 4;
                    break;
                case "Shovel":
                    attackBonus = 5;
                    break;
                case "Axe":
                    attackBonus = 6;
                    break;
                case "chainsaw":
                    attackBonus = 10;
                    break;
            }
            return attackBonus;
        }
        public int RangeAttackBonus()
        {
            string rangeWeapon = RangeWeapon;
            int attackBonus = 0;

            switch (rangeWeapon)
            {
                case "Pistol - USP-S":
                    attackBonus = 2;
                    break;
                case "Pistol - Desert Eagle":
                    attackBonus = 4;
                    break;
                case "Rifle - AK-47":
                    attackBonus = 6;
                    break;
                case "Rifle - M4A1-S":
                    attackBonus = 8;
                    break;
                case "Shotgun - Nova":
                    attackBonus = 10;
                    break;
            }
            return attackBonus;
        }

        private void AddArmory()
        {
            ArmorNameAndBonus = new Dictionary<string, int>();

            ArmorNameAndBonus.Add("No Helmet", 0);
            ArmorNameAndBonus.Add("No Armor", 0);
            ArmorNameAndBonus.Add("No Gloves", 0);
            ArmorNameAndBonus.Add("Normal Pants", 0);
            ArmorNameAndBonus.Add("Normal Shoes", 0);
        }
    }
}
