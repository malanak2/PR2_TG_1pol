using PR2_RPG_TG.Classes;
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
            Run();
            /*Console.WriteLine("Welcome! Press 1 to run normal sim, or anything else for unit testing!");
            char c = Console.ReadKey().KeyChar;
            if (c == '1') Run();
            else UnitTest.Test();*/
        }

        public static void Run()
        {
            Console.Clear();
            Thread.Sleep(sleepTime);
            Character character1 = new("Naruto");
            Thread.Sleep(sleepTime);
            Character character2 = new("Sasuke");
            Thread.Sleep(sleepTime);
            Console.WriteLine(character1);
            Thread.Sleep(sleepTime);
            Console.WriteLine(character2);
            rand = new Random();


            Thread.Sleep(sleepTime);
            character1.PickupItem(new ArmorItem("Headband", 5, 5));
            Thread.Sleep(sleepTime);
            Console.WriteLine(character1);
            Thread.Sleep(sleepTime);
            character2.PickupItem(new WeaponItem("Kunai", 10, 10));
            Thread.Sleep(sleepTime);
            Console.WriteLine(character2);

            Thread.Sleep(sleepTime);
            character1.PickupItem(new CoinItem("Bronze Coin", 1, 10));
            Thread.Sleep(sleepTime);
            character1.PrintInventory();
            Thread.Sleep(sleepTime);
            character1.PickupItem(new CoinItem("Bronze Coin", 1, 5));
            Thread.Sleep(sleepTime);
            character1.PrintInventory();

            character2.PickupItem(new BasicItem("Grass", 1));
            Thread.Sleep(sleepTime);
            character2.PrintInventory();


            while (character1.IsAlive() && character2.IsAlive())
            {
                Thread.Sleep(sleepTime);
                Console.WriteLine(String.Format("{0} attacks {1}!", character1.GetName(), character2.GetName()));
                Thread.Sleep(sleepTime);
                int randDef1 = rand.Next(1, 13);
                Thread.Sleep(sleepTime);
                Console.WriteLine(String.Format("{0} defends for {1}(+{2})!", character2.GetName(), randDef1, character2.GetDef()));
                Thread.Sleep(sleepTime);
                int randDmg1 = rand.Next(1, 13);
                Thread.Sleep(sleepTime);
                Console.WriteLine(String.Format("{0} attacks with {1}(+{2})!", character1.GetName(), randDmg1, character1.GetDamage()));
                Thread.Sleep(sleepTime);
                character2.TakeDamage(randDmg1 + character1.GetDamage(), randDef1);
                if (!character2.IsAlive())
                {
                    break;
                }
                Thread.Sleep(sleepTime);
                Console.WriteLine(String.Format("{0} attacks {1}!", character2.GetName(), character1.GetName()));
                Thread.Sleep(sleepTime);
                int randDef2 = rand.Next(1, 13);
                Thread.Sleep(sleepTime);
                Console.WriteLine(String.Format("{0} defends for {1}(+{2})!", character1.GetName(), randDef2, character1.GetDef()));
                Thread.Sleep(sleepTime);
                int randDmg2 = rand.Next(1, 13);
                Thread.Sleep(sleepTime);
                Console.WriteLine(String.Format("{0} attacks with {1}(+{2})!", character2.GetName(), randDmg2, character2.GetDamage()));
                Thread.Sleep(sleepTime);
                character1.TakeDamage(randDmg2 + character2.GetDamage(), randDef2);
            }
            Console.WriteLine("{0} has won!", character1.IsAlive() ? character1.GetName() : character2.GetName());
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
    }
}
