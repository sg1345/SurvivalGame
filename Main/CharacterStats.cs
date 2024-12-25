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
            Damage = AttackDamage();
            ArmorClass = 10;
        }

        public int HitPoints { get; set; }
        public int Damage { get; set; }
        public int ArmorClass { get; set; }
        public int MeleeWeaponBonus { get; set; }
        public int RangeWeaponBonus { get; set; }


        public int RollAttackVSArmorClass()
        {
            Random dice20 = new Random();
            int rollDice = dice20.Next(20);            
            return rollDice;
        }

        public int AttackDamage()
        {
            Random dice10 = new Random();
            int attackDice = dice10.Next(10);
            return attackDice;
        }
    }
}
