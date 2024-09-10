using PR2_RPG_TG.Classes;
using PR2_RPG_TG.Classes.item;
using PR2_RPG_TG.Classes.item.equipable.armor;
using PR2_RPG_TG.Classes.item.equipable.weapon;
using PR2_RPG_TG.Classes.item.stackable;
using PR2_RPG_TG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR2_RPG_TG.Unit_testing
{
    internal class UnitTest
    {
        static string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
        static string RED = Console.IsOutputRedirected ? "" : "\x1b[91m";
        static string GREEN = Console.IsOutputRedirected ? "" : "\x1b[92m";
        static string YELLOW = Console.IsOutputRedirected ? "" : "\x1b[93m";
        static string BLUE = Console.IsOutputRedirected ? "" : "\x1b[94m";
        static string MAGENTA = Console.IsOutputRedirected ? "" : "\x1b[95m";
        static string CYAN = Console.IsOutputRedirected ? "" : "\x1b[96m";
        static string GREY = Console.IsOutputRedirected ? "" : "\x1b[97m";
        static string BOLD = Console.IsOutputRedirected ? "" : "\x1b[1m";
        static string NOBOLD = Console.IsOutputRedirected ? "" : "\x1b[22m";
        static string UNDERLINE = Console.IsOutputRedirected ? "" : "\x1b[4m";
        static string NOUNDERLINE = Console.IsOutputRedirected ? "" : "\x1b[24m";
        static string REVERSE = Console.IsOutputRedirected ? "" : "\x1b[7m";
        static string NOREVERSE = Console.IsOutputRedirected ? "" : "\x1b[27m";
        /// <summary>
        /// Main class - All unit tests called from here
        /// </summary>
        public static void Test()
        {
            Console.Clear();
            Console.WriteLine(YELLOW + "Welcome to the debugging tool!");
            Console.WriteLine("Running unit tests..." + NORMAL);
            Character ch = new Character(null);
            int failed = 0;
            /*
            try
            {

                Console.WriteLine(GREEN + " passed." + NORMAL);
            }
            catch (Exception e)
            {
                Console.WriteLine(RED + BOLD + " did not pass. (" + e.ToString() + ")");
            }
            */

            try
            {
                ch = new Character(null);
                ch = new Character("pepa");
                Console.WriteLine(GREEN + "Character creation passed." + NORMAL);
            } catch (Exception e)
            {
                failed++;
                Console.WriteLine(RED + BOLD + "Character creation did not pass. (" + e.ToString() + ")" + NORMAL);
            }
            try
            {
                ch.takeDamage(5, 0);
                ch.heal();
                ch.takeDamage(-5, 1);
                ch.heal();
                ch.takeDamage(3, 8);
                ch.heal();
                Console.WriteLine(GREEN + "Character.takeDamage and Character.heal passed." + NORMAL);
            }
            catch (Exception e)
            {
                failed++;
                Console.WriteLine(RED + BOLD + "Character.takeDamage or Character.heal did not pass. (" + e.ToString() + ")" + NORMAL);
            }

            try
            {
                ch.pickupItem(new CoinItem("testCoin", 1, 50));
                ch.pickupItem(new WeaponItem("testWeapon", 25, 50));
                ch.pickupItem(new ArmorItem("testArmor", 25, 50));
                ch.pickupItem(new BasicItem("testBasic", 1));
                ch.pickupItem<WeaponItem>(null);
                Console.WriteLine(GREEN + "Character.pickupItem passed." + NORMAL);
            }
            catch (Exception e)
            {
                failed++;
                Console.WriteLine(RED + BOLD + "Character.pickupItem did not pass. (" + e.ToString() + ")" + NORMAL);
            }

            try
            {
                ch.printInventory();
                Console.WriteLine(GREEN + "Character.printInventory passed." + NORMAL);
            }
            catch (Exception e)
            {
                failed++;
                Console.WriteLine(RED + BOLD + "Character.printInventory did not pass. (" + e.ToString() + ")");
            }
            if (failed == 0)
            {
                Console.WriteLine(GREEN + "All unit tests passed. Press any key to exit..." + NORMAL);
                Console.ReadKey();
            } else
            {
                Console.WriteLine(RED + BOLD + failed + " test(s) did not pass.");
                Console.ReadKey();
            }

        }


    }
}
