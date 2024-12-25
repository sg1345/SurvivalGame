using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Enemies:
    Soulless = zombie
    Hunter =  physical (barbarian/ orc)
    Hidden = magical  (witch / cursed creаture)
    Demon = is summoned on constant number of enemies
 */
namespace Main
{
    public class Enemies
    {
        public Enemies()
        {
            Random randomName = new Random();
            int index = randomName.Next(4);
            string[] enemiesTypesPool = { "Soulless", "Hunter", "Hidden", "Demon" };

            string enemy = enemiesTypesPool[index];

            EnemyInput(enemy);
        }



        public string EnemyType { get; set; }
        public int HitPoints { get; set; }
        public int Damage { get; set; }
        public int ArmorClass { get; set; }

        //action
        public int RollAttackVSArmorClass()
        {
            Random dice20 = new Random();
            int rollDice = dice20.Next(20);
            return rollDice;
        }

        //inputMethod
        private void EnemyInput(string enemyType)
        {
            EnemyType = AdjectiveGenerator(enemyType);
            HitPoints = HitPointsGenerator(enemyType);
            Damage = DamageGenerator(enemyType);
            ArmorClass= ArmorClassGenerator(enemyType);
        }

        //random generator
        private int ArmorClassGenerator(string enemyType)
        {
            int AC = 0;
            switch (enemyType)
            {
                case "Soulless":
                    AC = 10;
                    break;

                case "Hunter":
                    AC = 13;
                    break;

                case "Hidden":
                    AC = 10;
                    break;

                case "Demon":
                    AC = 15;
                    break;
            }
            return AC;
        }
        private string AdjectiveGenerator(string enemyType)
        {
            List<string> adjectives = new();

            switch (enemyType)
            {
                case "Soulless":
                    string[] soullessAdjectives =
                    {
                        "Lifeless","Rotten","Decayed", "Putrid",
                        "Mindless", "Ravenous", "Gory", "Relentless",
                        "Shambling", "Gnashing", "Grotesque", "Macabre",
                        "Sinister", "Ominous", "Unholy", "Dreadful",
                        "Horrific", "Eerie", "Forsaken","Haunting"
                    };
                    adjectives.AddRange(soullessAdjectives);
                    break;

                case "Hunter":
                    string[] hunterAdjectives =
                    {
                        "Bloodthirsty", "Savage", "Ruthless", "Barbaric",
                        "Frenzied", "Ferocious", "Scarred", "Brutal",
                        "Warlike", "Relentless", "Gnarly", "Wounded",
                        "Battle-hardened", "Vicious", "Unyielding", "Crimson-stained",
                        "Gory", "Merciless", "Wild", "Untamed",
                        "Ravenous", "Menacing", "Feral", "Wrathful",
                        "Hulking", "Intimidating"
                    };
                    adjectives.AddRange(hunterAdjectives);
                    break;

                case "Hidden":
                    string[] hiddenAdjectives =
                    {
                        "Intelligent", "Cursed", "Magical", "Mysterious",
                        "Fearful", "Dark", "Evil", "Malevolent",
                        "Deceptive", "Enigmatic", "Cryptic", "Shadowed",
                        "Occult", "Forbidden", "Sinister", "Scheming",
                        "Twisted", "Unholy", "Wicked", "Arcane",
                        "Elusive", "Machiavellian",
                        "Sly", "Venomous", "Corrupt"
                    };
                    adjectives.AddRange(hiddenAdjectives);
                    break;

                case "Demon":
                    string[] demonAdjectives =
                        {
                            "Sinister", "Malevolent", "Ominous", "Cunning",
                            "Fiery", "Macabre", "Malisious","Otherworldly",
                            "Vile", "Diabolical", "Grotesque","Eldritch",
                            "Shadowy", "Baleful", "Ruthless", "Haunting",
                            "Venomous", "Wrathful", "Spectral", "Dreadful",
                            "Pernicious", "Horrific","Eerie", "Forsaken",
                            "Fiendish", "Ancient","Wicked","Infernal",
                            "Unholy","Savage",
                        };
                    adjectives.AddRange(demonAdjectives);
                    break;
            }


            Random random = new Random();
            int index = random.Next(adjectives.Count);


            string adjective = adjectives[index];
            adjectives.Clear();

            return $"{adjective} {enemyType}";
        }
        private int HitPointsGenerator(string enemyType)
        {
            int hitPoints = 0;

            switch (enemyType)
            {
                case "Soulless":
                    hitPoints = 404;
                    break;

                case "Hunter":
                    hitPoints = 420;
                    break;

                case "Hidden":
                    hitPoints = 314;
                    break;

                case "Demon":
                    hitPoints = 666;
                    break;
            }

            Random random = new();
            int randomHP = random.Next(1, 4);

            switch (randomHP)
            {
                case 1:
                    double multiplier = random.Next(101, 120) * 0.01;
                    hitPoints = (int)(hitPoints * multiplier);
                    break;
                case 2:
                    break;
                case 3:
                    double devider = random.Next(80, 99) * 0.01;
                    hitPoints = (int)(hitPoints * devider);
                    break;
            }

            return hitPoints;
        }
        private int DamageGenerator(string enemyType)
        {
            int damage = 0;

            switch (enemyType)
            {
                case "Soulless":
                    damage = 69;
                    break;

                case "Hunter":
                    damage = 66;
                    break;

                case "Hidden":
                    damage = 77;
                    break;

                case "Demon":
                    damage = 99;
                    break;
            }

            Random random = new();
            int randomHP = random.Next(1, 4);

            switch (randomHP)
            {
                case 1:
                    double multiplier = random.Next(101, 120) * 0.01;
                    damage = (int)(damage * multiplier);
                    break;
                case 2:
                    break;
                case 3:
                    multiplier = random.Next(80, 99) * 0.01;
                    damage = (int)(damage * multiplier);
                    break;
            }

            return damage;
        }
    }
}