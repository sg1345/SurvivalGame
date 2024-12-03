using Main;

internal class Program
{
    static void Main()
    {
        Console.SetWindowSize(170, 40);

        MainCharacter character = new();
        Inventory inventory = new();
        Counters counters = new();

        while (true)
        {
            Enemies enemy = new();

            PrintEnemy(enemy);

            PrintKillCounter(counters);

            PrintCharacter(character);

            PrintInventory(inventory);

            PrintAction();

            while (enemy.HitPoints > 0 && character.HitPoints > 0)
            {                
                SetDefaultCursorPosition();

                string command = Console.ReadLine();

                bool isNotRealCommand = false;
                switch (command)
                {
                    case "A": //knife attack
                        int hitDamage;
                        enemy.HitPoints -= character.Damage;
                        character.HitPoints -= enemy.Damage;
                        break;

                    case "Q": //pistol shot
                        hitDamage = character.Damage * 2;
                        enemy.HitPoints -= hitDamage;
                        break;

                    //case "C": //bow shot
                    //    hitDamage = character.Damage;
                    //    enemy.HitPoints -= hitDamage;
                    //    break;

                    case "R": //holly water
                        enemy.HitPoints = 0;
                        break;

                    case "E": //bandage
                        character.HitPoints += 250;
                        if (character.HitPoints >= 1000)
                        {
                            character.HitPoints = 1000;
                        }
                        break;

                    case "W": //first aid spray
                        character.HitPoints = 1000;
                        break;

                    default:
                        isNotRealCommand = true;
                        break;
                }

                if (isNotRealCommand)
                {
                    continue;
                }

                if(enemy.HitPoints <= 0)
                {
                    counters.Total++;
                }

                PrintEnemy(enemy);

                if (character.HitPoints <= 0)
                {
                    character.HitPoints = 0;
                }
                PrintCharacter(character);
            }

            if (character.HitPoints <= 0)
            {                
                Console.WriteLine("YOU DIED! PLAY AGAIN?");
                return;
            }
        }
    }



    static void PrintEnemy(Enemies enemy)
    {
        Console.SetCursorPosition(0, 0);

        LineCleaner(0, 0, 100);
        Console.WriteLine($"You are fighting: {enemy.EnemyType}");

        LineCleaner(0,1,100);// 100 е за да не изстрие целия ред
        Console.WriteLine($"HP: {enemy.HitPoints}");

        LineCleaner(0, 2, 100);
        Console.Write($"DMG {enemy.Damage}");
    }
    static void PrintKillCounter(Counters counters)
    {
        Console.SetCursorPosition(120, 0);
        Console.Write($"Soulless Killed: {counters.Soulles}");
        Console.SetCursorPosition(121, 1);
        Console.Write($"Hiddens Killed: {counters.Hiddens}");
        Console.SetCursorPosition(121, 2);
        Console.Write($"Hunters Killed: {counters.Hunters}");
        Console.SetCursorPosition(122, 3);
        Console.Write($"Demons Killed: {counters.Demons}");
        Console.SetCursorPosition(123, 5);
        Console.Write($"Total Killed: {counters.Total}");
    }
    static void PrintCharacter(MainCharacter character)
    {
        Console.SetCursorPosition(0, 4);
        Console.WriteLine($"Characters Stats:");
        LineCleaner(0,5, 100);
        Console.Write($"HP: {character.HitPoints}\\1000".PadRight(40));
        Console.Write($"DMG: {character.Damage}".PadRight(40));
        Console.WriteLine($"ARMOR: {character.Armor}");
        Console.WriteLine();
    }
    static void PrintInventory(Inventory inventory)
    {
        Console.SetCursorPosition(0, 7);
        Console.WriteLine($"Inventory:");
        Console.Write($"Knife: {inventory.Knife}".PadRight(40));
        Console.Write($"Bullets: {inventory.Bullets}".PadRight(40));
        Console.WriteLine($"Arrows: {inventory.Arrows}");
        Console.Write($"Holly Water Bottles: {inventory.HollyWaterBottles}".PadRight(40));
        Console.Write($"Bandages: {inventory.Bandages}".PadRight(40));
        Console.Write($"First Aid Spray: {inventory.FirstAidSpray}");
        Console.WriteLine();
        Console.WriteLine();
    }
    static void PrintAction()
    {
        Console.SetCursorPosition(0, 11);
        Console.WriteLine($"Actions:");
        Console.Write($"Q: Shoot with the Pistol".PadRight(40));
        Console.Write($"W: Hide and use a First Aid Spray".PadRight(40));
        Console.Write($"E: Hide and use a Bandage".PadRight(40));
        Console.WriteLine($"R: Throw a Holly Water Bottle".PadRight(40));
        Console.Write($"A: Knife Attack".PadRight(40));
        Console.Write($"S: Hide".PadRight(40));
        //Console.WriteLine($"C: Shoot with the Bow".PadRight(40));
        Console.WriteLine();
    }
    static void SetDefaultCursorPosition()
    {
        Console.SetCursorPosition(0, 14);
        Console.WriteLine(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, 14);
    }

    static void LineCleaner(int left, int top, int charCount)
    {
        Console.WriteLine(new string(' ', charCount));
        Console.SetCursorPosition(left, top);
    }
}