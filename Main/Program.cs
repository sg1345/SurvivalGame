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

                ConsoleKeyInfo command = Console.ReadKey(intercept: true);

                bool isNotRealCommand = false;
                switch (command.Key)
                {
                    case ConsoleKey.A:
                        GameMechanics.MeleeWeaponAttack(character, inventory, enemy);
                        break;

                    case ConsoleKey.Q:
                        GameMechanics.RangeWeaponAttack(character, inventory, enemy);
                        break;


                    case ConsoleKey.R:
                        GameMechanics.UseHollyWater(inventory, enemy);
                        break;

                    case ConsoleKey.E:
                        GameMechanics.UseBandages(character, inventory);
                        break;

                    case ConsoleKey.W:
                        GameMechanics.UseFirstAidSpray(character, inventory);
                        break;

                    default:
                        isNotRealCommand = true;
                        break;
                }

                if (isNotRealCommand)
                {
                    continue;
                }

                if (enemy.HitPoints <= 0)
                {
                    counters.Total++;
                }

                PrintEnemy(enemy);

                if (character.HitPoints <= 0)
                {
                    character.HitPoints = 0;
                }
                PrintCharacter(character);
                PrintInventory(inventory);
            }

            if (character.HitPoints <= 0)
            {
                Console.WriteLine("YOU DIED! PLAY AGAIN?");
                return;
            }
        }
    }

    //Printing Methods
    static void PrintEnemy(Enemies enemy)
    {
        Console.SetCursorPosition(0, 0);

        LineCleaner(0, 0, 100);
        Console.WriteLine($"You are fighting: {enemy.EnemyType}");

        LineCleaner(0, 1, 100);// 100 е за да не изстрие целия ред
        Console.Write($"HP: {enemy.HitPoints}".PadRight(40));
        Console.Write($"DMG {enemy.Damage}".PadRight(40));
        Console.Write($"ARMOR {enemy.ArmorClass}");

        // LineCleaner(0, 2, 100);// резервна линия
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
        LineCleaner(0, 5, 100);
        Console.Write($"HP: {character.HitPoints}\\1000".PadRight(40));
        Console.Write($"DMG: {character.Damage}".PadRight(40));
        Console.WriteLine($"ARMOR: {character.ArmorClass}");
        Console.WriteLine();
    }
    static void PrintInventory(Inventory inventory)
    {
        Console.SetCursorPosition(0, 7);
        Console.WriteLine($"Inventory:");
        LineCleaner(0, 8, Console.WindowWidth);
        Console.Write($"Melee Weapon: {inventory.MeleeWeapon}".PadRight(40));
        Console.Write($"Holly Water Bottles: {inventory.HollyWaterBottles}".PadRight(40));
        Console.WriteLine($"Bandages: {inventory.Bandages}");
        LineCleaner(0, 9, Console.WindowWidth);
        Console.Write($"Range Weapon: {inventory.RangeWeapon}".PadRight(40));
        Console.Write($"Bullets: {inventory.Bullets}".PadRight(40));
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