using Main;
using System.Security.Authentication.ExtendedProtection;
using System.Text.RegularExpressions;

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

            ConsoleManager.PrintEnemy(enemy);

            ConsoleManager.PrintKillCounter(counters);

            ConsoleManager.PrintCharacter(character);

            ConsoleManager.PrintInventory(inventory);

            ConsoleManager.PrintAction();

            while (enemy.HitPoints > 0 && character.HitPoints > 0)
            {
                ConsoleManager.SetDefaultCursorPosition();

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

                    Random random = new Random();
                    int countDropItems = random.Next(1,6);

                    Dictionary<string, int> displayedItems = new();

                    for (int i = 0; i < countDropItems; i++)
                    {
                        int currentDrop = random.Next(0, 6);

                        switch (currentDrop)
                        {
                            case 0:
                                bool isArmorDroped = false;

                                while (!isArmorDroped)
                                {
                                    int itemArmor = random.Next(1,5);
                                    //List<int>  
                                    if (itemArmor == 1)
                                    {
                                        if (inventory.ArmorNameAndBonus.ContainsKey("No Helmet"))
                                        {
                                            displayedItems.Add("Police Helmet", 1);
                                            isArmorDroped = true;
                                        }
                                        else if ((inventory.ArmorNameAndBonus.ContainsKey("Police Helmet")))
                                        {
                                            displayedItems.Add("Military Helmet", 2);
                                            isArmorDroped = true;
                                        }
                                        else
                                        {
                                            itemArmor += 1;
                                        }
                                    }

                                    if (itemArmor == 2)
                                    {
                                        if (inventory.ArmorNameAndBonus.ContainsKey("No Armor"))
                                        {
                                            displayedItems.Add("Police Chest Armor", 1);
                                            isArmorDroped = true;
                                        }
                                        else if (inventory.ArmorNameAndBonus.ContainsKey("Police Chest Armor"))
                                        {
                                            displayedItems.Add("Military Chest Armor", 2);
                                            isArmorDroped = true;
                                        }
                                        else
                                        {
                                            itemArmor += 1;
                                        }
                                    }

                                    if (itemArmor == 3)
                                    {
                                        if (inventory.ArmorNameAndBonus.ContainsKey("No Gloves"))
                                        {
                                            displayedItems.Add("Police Gloves", 1);
                                            isArmorDroped = true;
                                        }
                                        else if (inventory.ArmorNameAndBonus.ContainsKey("Police Gloves"))
                                        {
                                            displayedItems.Add("Military Gloves", 2);
                                            isArmorDroped = true;
                                        }
                                        else
                                        {
                                            itemArmor += 1;
                                        }
                                    }

                                    if (itemArmor == 4)
                                    {
                                        if (inventory.ArmorNameAndBonus.ContainsKey("Normal Pants"))
                                        {
                                            displayedItems.Add("Police Pants", 1);
                                            isArmorDroped = true;
                                        }
                                        else if (inventory.ArmorNameAndBonus.ContainsKey("Police Pants"))
                                        {
                                            displayedItems.Add("Military Pants", 2);
                                            isArmorDroped = true;
                                        }
                                        else
                                        {
                                            itemArmor += 1;
                                        }
                                    }

                                    if (itemArmor == 5)
                                    {
                                        if (inventory.ArmorNameAndBonus.ContainsKey("Normal Shoes"))
                                        {
                                            displayedItems.Add("Police Shoes", 1);
                                            isArmorDroped = true;
                                        }
                                        else if (inventory.ArmorNameAndBonus.ContainsKey("Police Shoes"))
                                        {
                                            displayedItems.Add("Military Shoes", 2);
                                            isArmorDroped = true;
                                        }
                                    }

                                    if (inventory.ArmorNameAndBonus.ContainsKey("Military Helmet") &&
                                            inventory.ArmorNameAndBonus.ContainsKey("Military Chest Armor") &&
                                            inventory.ArmorNameAndBonus.ContainsKey("Military Gloves") &&
                                            inventory.ArmorNameAndBonus.ContainsKey("Military Pants") &&
                                            inventory.ArmorNameAndBonus.ContainsKey("Military Shoes"))
                                    {
                                        i--;
                                        continue;
                                    }
                                }

                                break;

                            case 1:
                                if (displayedItems.ContainsKey("Ammonition"))
                                {
                                    i--;
                                    continue;
                                }
                                int ammo = random.Next(3, 21);
                                displayedItems.Add("Ammonition", ammo);
                                break;

                            case 2:
                                if (displayedItems.ContainsKey("Holly Water Bottle"))
                                {
                                    i--;
                                    continue;
                                }
                                displayedItems.Add("Holly Water Bottle", 1);
                                break;

                            case 3:
                                int randomDropHeal = random.Next(4);
                                if (randomDropHeal == 4)
                                {
                                    if (displayedItems.ContainsKey("First-Aid Spray"))
                                    {
                                        i--;
                                        continue;
                                    }
                                    displayedItems.Add("First-Aid Spray", 1000);
                                }
                                else
                                {
                                    if (displayedItems.ContainsKey("Bandages"))
                                    {
                                        i--;
                                        continue;
                                    }
                                    displayedItems.Add("Bandages", 250);
                                }
                                break;

                            case 4:
                                int meleeOrRangeDrop = random.Next(3);
                                if (meleeOrRangeDrop == 3)
                                {
                                    int RangeWeaponDrop = random.Next(5);
                                    switch (RangeWeaponDrop)
                                    {
                                        case 1:
                                            if (displayedItems.ContainsKey("Pistol - USP-S"))
                                            {
                                                i--;
                                                continue;
                                            }
                                            displayedItems.Add("Pistol - USP-S", 120);
                                            break;

                                        case 2:
                                            if (displayedItems.ContainsKey("Pistol - Desert Eagle"))
                                            {
                                                i--;
                                                continue;
                                            }
                                            displayedItems.Add("Pistol - Desert Eagle", 140);
                                            break;

                                        case 3:
                                            if (displayedItems.ContainsKey("Rifle - AK-47"))
                                            {
                                                i--;
                                                continue;
                                            }
                                            displayedItems.Add("Rifle - AK-47", 160);
                                            break;

                                        case 4:
                                            if (displayedItems.ContainsKey("Rifle - M4A1-S"))
                                            {
                                                i--;
                                                continue;
                                            }
                                            displayedItems.Add("Rifle - M4A1-S", 180);
                                            break;

                                        case 5:
                                            if (displayedItems.ContainsKey("Shotgun - Nova"))
                                            {
                                                i--;
                                                continue;
                                            }
                                            displayedItems.Add("Shotgun - Nova", 1000);
                                            break;
                                    }
                                }
                                else
                                {
                                    int MeleeWeaponDrop = random.Next(5);
                                    switch (MeleeWeaponDrop)
                                    {
                                        case 1:
                                            if(displayedItems.ContainsKey("Kitchen Knife")) 
                                            {
                                                i--;
                                                continue;
                                            }
                                            displayedItems.Add("Kitchen Knife", 10);
                                            break;

                                        case 2:
                                            if (displayedItems.ContainsKey("Baseball Bat"))
                                            {
                                                i--;
                                                continue;
                                            }
                                            displayedItems.Add("Baseball Bat", 20);
                                            break;

                                        case 3:
                                            if (displayedItems.ContainsKey("Shovel"))
                                            {
                                                i--;
                                                continue;
                                            }
                                            displayedItems.Add("Shovel", 30);
                                            break;

                                        case 4:
                                            if (displayedItems.ContainsKey("Axe"))
                                            {
                                                i--;
                                                continue;
                                            }
                                            displayedItems.Add("Axe", 40);
                                            break;

                                        case 5:
                                            if (displayedItems.ContainsKey("Chainsaw"))
                                            {
                                                i--;
                                                continue;
                                            }
                                            displayedItems.Add("Chainsaw", 100);
                                            break;
                                    }
                                }
                                break;
                        }
                    }

                    ConsoleManager.LineCleaner(0, 11,Console.WindowWidth);
                    ConsoleManager.LineCleaner(0, 12, Console.WindowWidth);
                    ConsoleManager.LineCleaner(0, 13, Console.WindowWidth);
                    Console.SetCursorPosition(0, 11);
                    Console.Write($"Founded Items:");

                    char[] buttons = { 'Q', 'W', 'E', 'R', 'A', 'S' };
                    int indexButton = 0;

                    Console.SetCursorPosition(0, 12);
                    foreach (var item in displayedItems)
                    {
                        if (indexButton >= buttons.Length)
                        {

                        }

                        if (indexButton == 4)
                        {
                            Console.SetCursorPosition(0, 13);
                        }

                        string armorPattern = @"Military|Police";
                        string healPattern = @"First-Aid Spray|Bandages";
                        Match ArmorMatch = Regex.Match(item.Key, armorPattern);
                        Match healMatch = Regex.Match(item.Key, healPattern);                       
                        if (item.Key == "Ammonition")
                        {
                            Console.Write($"{buttons[indexButton]}: + {item.Value} {item.Key}".PadRight(40));
                        }
                        else if (healMatch.Success)
                        {
                            Console.Write($"{buttons[indexButton]}: {item.Key} (Heals {item.Value} HP)".PadRight(40));
                        }
                        else if (ArmorMatch.Success)
                        {
                            Console.Write($"{buttons[indexButton]}: {item.Key} (+{item.Value} Armor)".PadRight(40));
                        }
                        else if (item.Key == "Holly Water Bottle")
                        {
                            Console.Write($"{buttons[indexButton]}: {item.Key}".PadRight(40));
                        }
                        else
                        {
                            Console.Write($"{buttons[indexButton]}: {item.Key} (+{item.Value} DMG)".PadRight(40));
                        }
                        indexButton++;
                    }
                    Console.SetCursorPosition(120, 13);
                    Console.Write($"Enter: Finish Looting");

                    //Екрана е направен. Трябва да се направят бутоните и да се доизпипа смяната на диспея.
                    Console.WriteLine();
                }

                ConsoleManager.PrintEnemy(enemy);

                if (character.HitPoints <= 0)
                {
                    character.HitPoints = 0;
                }
                ConsoleManager.PrintCharacter(character);
                ConsoleManager.PrintInventory(inventory);
            }

            if (character.HitPoints <= 0)
            {
                Console.WriteLine("YOU DIED! PLAY AGAIN?");
                return;
            }
        }
    }
}