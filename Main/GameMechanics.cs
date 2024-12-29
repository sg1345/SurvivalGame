using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class GameMechanics
    {
        public static void UseFirstAidSpray(MainCharacter character, Inventory inventory)
        {
            if (inventory.FirstAidSpray > 0)
            {
                character.HitPoints = 1000;
                inventory.FirstAidSpray -= 1;
            }
        }
        public static void UseBandages(MainCharacter character, Inventory inventory)
        {
            if (inventory.Bandages > 0)
            {
                character.HitPoints += 250;
                if (character.HitPoints >= 1000)
                {
                    character.HitPoints = 1000;
                }
                inventory.Bandages -= 1;
            }
        }
        public static void UseHollyWater(Inventory inventory, Enemies enemy)
        {
            if (inventory.HollyWaterBottles > 0)
            {
                enemy.HitPoints = 0;
                inventory.HollyWaterBottles -= 1;
            }
        }
        public static void RangeWeaponAttack(MainCharacter character, Inventory inventory, Enemies enemy)
        {
            bool haveAmmo = true;
            if (inventory.Bullets > 0)
            {
                inventory.Bullets -= 1;
            }
            else
            {
                haveAmmo = false;
            }

            if ((character.RollAttackVSArmorClass() + inventory.RangeAttackBonus()) > enemy.ArmorClass && haveAmmo)
            {
                enemy.HitPoints -= character.AttackDamage() + inventory.RangeDamageBonus();
            }

            if (enemy.RollAttackVSArmorClass() > character.ArmorClass)
            {
                character.HitPoints -= enemy.Damage;
            }
        }
        public static void MeleeWeaponAttack(MainCharacter character, Inventory inventory, Enemies enemy)
        {
            if ((character.RollAttackVSArmorClass() + inventory.MeleeAttackBonus()) > enemy.ArmorClass)
            {
                enemy.HitPoints -= character.AttackDamage() + inventory.MeleeDamageBonus();
            }
            if ((enemy.RollAttackVSArmorClass()) > character.ArmorClass)
            {
                character.HitPoints -= enemy.Damage;
            }
        }
    }
}


