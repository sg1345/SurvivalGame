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
            MeleeWeapon = "Knife";
            RangeWeapon = "Pistol - Desert Eagle";
            Bullets = 7;
            //Arrows = 20;
            HollyWaterBottles = 0;
            Bandages = 1;
            FirstAidSpray = 0;
            ArmorBuffs = 0;
        }

        public string MeleeWeapon {  get; set; }
        public string RangeWeapon {  get; set; }
        public int Bullets { get; set; }
        //public int Arrows { get; set; }
        public int HollyWaterBottles { get; set; }
        public int Bandages { get; set; }
        public int FirstAidSpray { get; set; }
        public int ArmorBuffs { get; set; } 

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
                case "chainsaw":
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

    }
}
