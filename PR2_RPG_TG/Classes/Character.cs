using System;
using System.Collections;
using PR2_RPG_TG.Classes.item.equipable.armor;
using PR2_RPG_TG.Classes.item.equipable.weapon;
using PR2_RPG_TG.Interfaces;

namespace PR2_RPG_TG.Classes
{
    public class Character
    {
        private string _name ="";

        private int str; // Strength

        private int dex; // Dexterity

        private int res; // Resistance

        private double HP;

        private double maxHP;

        private ArrayList inventory;

        private int weight = 0;

        private int capacity;

        private Weapon weapon;

        private Armor armor;

        Random rand;
        public Character(string name)
        {
            if (name == null)
            {
                _name = name;
                return;
            }
            rand = new Random();
            _name = name;
            inventory = new ArrayList();
            Console.WriteLine(name + " has been created!");
            str = rand.Next(5, 13);
            dex = rand.Next(1, 13);
            res = rand.Next(5, 13);
            maxHP = res * 3;
            HP = maxHP;
            capacity = str * 10;
        }

        public override string ToString()
        {
            string ret = String.Format("{0}: str {1}", _name, str);
            if (weapon != null) ret += String.Format("(+{0})",weapon.Damage);
            ret += String.Format(", dex {0}, res {1}", dex, res);
            if (armor != null) ret += String.Format("(+{0})", armor.defense);
            ret += String.Format(", hp {0}/{1}, weight {2}/{3}", HP, maxHP, weight, capacity);
            return ret;

        }

        public String GetName()
        {
            return _name;
        }

        /// Combat impl

        public int GetDamage()
        {
            int critamount = 0;
            Random rand = new Random();
            if (rand.Next(0, 10) == 0) { 
                critamount = 9999; 
                Console.WriteLine(String.Format("{0} has dealt a CRITICAL HIT!", _name));
            }
            if (weapon != null) return str + weapon.Damage+ critamount;
            return str + critamount;
        }

        public int GetDef()
        {
            if (armor != null) return res + armor.defense;
            return res;
        }

        ///  <summary>
        /// Takes damage and checks if the character has died (is at the end of the calculation)
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(float damage, float randDef)
        {
            if (damage <= 0) return;
            double taken = damage - (damage * ((randDef + res)/100));
            taken = Math.Round(taken, 2);
            HP -= taken;
            HP = Math.Round(HP, 2);
            Console.WriteLine(String.Format("{0} has taken {1} damage! Current HP: {2}/{3}", _name, taken, HP, maxHP));
            if (HP <= 0)
            {
                Console.WriteLine(_name + " has died!");
            }
        }

        public void Heal()
        {
            HP = maxHP;
        }

        public bool IsAlive()
        {
            return HP > 0; 
        }


        /// Inventory impl
        
        /// <summary>
        /// Tries to pick up an item and add it to the inventory
        /// </summary>
        /// <param name="item">item to pick up</param>
        public void PickupItem<T>(T item) where T : Item
        {
            if (item == null) return;
            if ((weight + item.Weight) <= capacity)
            {
                if (item is Equipable)
                {
                    if (item is WeaponItem)
                    {
                        if (weapon != null)
                        {
                            Console.WriteLine(String.Format("{0} already has a Weapon!", _name));
                            return;
                        }
                        Console.WriteLine(String.Format("{0} has equipped {1}!", _name, item.Name));
                        weapon = (Weapon)item;
                        weight += item.Weight;
                        return;
                    }
                    if (item is ArmorItem)
                    {
                        if (armor != null)
                        {
                            Console.WriteLine(String.Format("{0} already has Armor!", _name));
                            return;
                        }
                        Console.WriteLine(String.Format("{0} has equipped {1}!", _name, item.Name));
                        armor = (Armor)item;
                        weight += item.Weight;
                        return;
                    }
                }
                if (item is Stackable)
                {
                    bool contains = false;
                    Stackable og = (Stackable)item;
                    foreach (Item i in inventory)
                    {
                        if (i.Name == item.Name)
                        {
                            contains = true;
                            og = (Stackable)i;
                        }
                    }
                    Stackable stackable = (Stackable)item;
                    if (contains) //(x => x.name == item.name)
                    {
                        stackable.quantity += og.quantity;
                        inventory.Remove(og);
                        inventory.Add(stackable);
                    }
                    else
                    {
                        inventory.Add(item);
                    }
                    weight += item.Weight * stackable.quantity;
                    return;
                }
                else inventory.Add(item);
                Console.WriteLine(String.Format("{0} has picked up {1}!", _name, item.Name));
                weight += item.Weight;
            }
            else
            {
                Console.WriteLine(String.Format("{0} is too heavy! ({1}/{2}, {3})", item.Name, weight, capacity, item.Weight));
            }
        }

        /// <summary>
        /// Prints the inventory contents
        /// </summary>
        public void PrintInventory()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine(String.Format("{0}'s inventory is empty!", _name));
                return;
            }
            string text = "";
            foreach (Item item in inventory)
            {
                text += item.Name;
                if (item is Stackable)
                {
                    Stackable stackable = (Stackable)item;
                    text += String.Format("({0})", stackable.quantity);
                }
                text += ", ";
            }
            text = text.TrimEnd([',', ' ']);
            Console.WriteLine(String.Format("{0}'s inventory contains: {1}", _name, text));
        }   
    }
}