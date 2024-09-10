using PR2_RPG_TG.Classes;
using PR2_RPG_TG.Interfaces;
using PR2_RPG_TG.Classes.item;
using PR2_RPG_TG.Classes.item.equipable.weapon;
using PR2_RPG_TG.Classes.item.equipable.armor;
using PR2_RPG_TG.Classes.item.stackable;
using PR2_RPG_TG.Unit_testing;
namespace PR2_RPG_TG
{
    internal class Program
    {
        static Random rand;
        static private int sleepTime = 500;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome! Press 1 to run normal sim, or anything else for unit testing!");
            char c = Console.ReadKey().KeyChar;
            if (c == '1') run();
            else UnitTest.Test();
        }

        public static void run()
        {
            Console.Clear();
            Thread.Sleep(sleepTime);
            Character character1 = new Character("Naruto");
            Thread.Sleep(sleepTime);
            Character character2 = new Character("Sasuke");
            Thread.Sleep(sleepTime);
            Console.WriteLine(character1);
            Thread.Sleep(sleepTime);
            Console.WriteLine(character2);
            rand = new Random();


            Thread.Sleep(sleepTime);
            character1.pickupItem(new ArmorItem("Headband", 5, 5));
            Thread.Sleep(sleepTime);
            Console.WriteLine(character1);
            Thread.Sleep(sleepTime);
            character2.pickupItem(new WeaponItem("Kunai", 10, 10));
            Thread.Sleep(sleepTime);
            Console.WriteLine(character2);

            Thread.Sleep(sleepTime);
            character1.pickupItem(new CoinItem("Bronze Coin", 1, 10));
            Thread.Sleep(sleepTime);
            character1.printInventory();
            Thread.Sleep(sleepTime);
            character1.pickupItem(new CoinItem("Bronze Coin", 1, 5));
            Thread.Sleep(sleepTime);
            character1.printInventory();



            while (character1.isAlive() && character2.isAlive())
            {
                Thread.Sleep(sleepTime);
                Console.WriteLine(String.Format("{0} attacks {1}!", character1.getName(), character2.getName()));
                Thread.Sleep(sleepTime);
                int randDef1 = rand.Next(1, 13);
                Thread.Sleep(sleepTime);
                Console.WriteLine(String.Format("{0} defends for {1}(+{2})!", character2.getName(), randDef1, character2.getDef()));
                Thread.Sleep(sleepTime);
                int randDmg1 = rand.Next(1, 13);
                Thread.Sleep(sleepTime);
                Console.WriteLine(String.Format("{0} attacks with {1}(+{2})!", character1.getName(), randDmg1, character1.getDamage()));
                Thread.Sleep(sleepTime);
                character2.takeDamage(randDmg1 + character1.getDamage(), randDef1);
                if (!character2.isAlive())
                {
                    break;
                }
                Thread.Sleep(sleepTime);
                Console.WriteLine(String.Format("{0} attacks {1}!", character2.getName(), character1.getName()));
                Thread.Sleep(sleepTime);
                int randDef2 = rand.Next(1, 13);
                Thread.Sleep(sleepTime);
                Console.WriteLine(String.Format("{0} defends for {1}(+{2})!", character1.getName(), randDef2, character1.getDef()));
                Thread.Sleep(sleepTime);
                int randDmg2 = rand.Next(1, 13);
                Thread.Sleep(sleepTime);
                Console.WriteLine(String.Format("{0} attacks with {1}(+{2})!", character2.getName(), randDmg2, character2.getDamage()));
                Thread.Sleep(sleepTime);
                character1.takeDamage(randDmg2 + character2.getDamage(), randDef2);
            }
            Console.WriteLine("{0} has won!", character1.isAlive() ? character1.getName() : character2.getName());
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
    }
}
