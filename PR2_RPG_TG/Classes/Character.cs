using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using PR2_RPG_TG.Classes.item.equipable.armor;
using PR2_RPG_TG.Classes.item.equipable.weapon;
using PR2_RPG_TG.Interfaces;

namespace PR2_RPG_TG.Classes
{
    internal class Character
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
            if (name == null) return;
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
            if (weapon == null && armor == null) return String.Format("{0}: str {1}, dex {2}, res {3}, hp {4}/{5}, weight {6}/{7}", _name, str, dex, res, HP, maxHP, weight, capacity);
            if (weapon == null) return String.Format("{0}: str {1}, dex {2}, res {3}(+{8}), hp {4}/{5}, weight {6}/{7}", _name, str, dex, res, HP, maxHP, weight, capacity, armor.defense);
            if (armor == null) return String.Format("{0}: str {1}(+{8}), dex {2}, res {3}, hp {4}/{5}, weight {6}/{7}", _name, str, dex, res, HP, maxHP, weight, capacity, weapon.damage);
            return String.Format("{0}: str {1}(+{8}), dex {2}, res {3}(+{9}), hp {4}/{5}, weight {6}/{7}", _name, str, dex, res, HP, maxHP, weight, capacity, weapon.damage, armor.defense);

        }

        public String getName()
        {
            return _name;
        }

        /// Combat impl

        public int getDamage()
        {
            if (weapon != null) return str + weapon.damage;
            return str;
        }

        public int getDef()
        {
            if (armor != null) return res + armor.defense;
            return res;
        }

        ///  <summary>
        /// Takes damage and checks if the character has died (is at the end of the calculation)
        /// </summary>
        /// <param name="damage"></param>
        public void takeDamage(float damage, float randDef)
        {
            if (damage <= 0) return;
            double taken = damage - (damage * (1/(randDef + res)));
            taken = Math.Round(taken, 2);
            HP -= taken;
            HP = Math.Round(HP, 2);
            Console.WriteLine(String.Format("{0} has taken {1} damage! Current HP: {2}/{3}", _name, taken, HP, maxHP));
            if (HP <= 0)
            {
                Console.WriteLine(_name + " has died!");
            }
        }

        public void heal()
        {
            HP = maxHP;
        }

        public bool isAlive()
        {
            return HP > 0; 
        }


        /// Inventory impl
        
        /// <summary>
        /// Tries to pick up an item and add it to the inventory
        /// </summary>
        /// <param name="item">item to pick up</param>
        public void pickupItem<T>(T item) where T : Item
        {
            if (item == null) return;
            if ((weight + item.weight) <= capacity)
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
                        Console.WriteLine(String.Format("{0} has equipped {1}!", _name, item.name));
                        weapon = (Weapon)item;
                        weight += item.weight;
                        return;
                    }
                    if (item is ArmorItem)
                    {
                        if (armor != null)
                        {
                            Console.WriteLine(String.Format("{0} already has Armor!", _name));
                            return;
                        }
                        Console.WriteLine(String.Format("{0} has equipped {1}!", _name, item.name));
                        armor = (Armor)item;
                        weight += item.weight;
                        return;
                    }
                }
                if (item is Stackable)
                {
                    bool contains = false;
                    Stackable og = (Stackable)item;
                    foreach (Item i in inventory)
                    {
                        if (i.name == item.name)
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
                    weight += item.weight * stackable.quantity;
                    return;
                }
                else inventory.Add(item);
                Console.WriteLine(String.Format("{0} has picked up {1}!", _name, item.name));
                weight += item.weight;
            }
            else
            {
                Console.WriteLine(String.Format("{0} is too heavy! ({1}/{2}, {3})", item.name, weight, capacity, item.weight));
            }
        }

        /// <summary>
        /// Prints the inventory contents
        /// </summary>
        public void printInventory()
        {
            string text = "";
            foreach (Item item in inventory)
            {
                text += item.name;
                if (item is Stackable)
                {
                    Stackable stackable = (Stackable)item;
                    text += String.Format("({0})", stackable.quantity);
                }
                text += ", ";
            }
            text = text.TrimEnd(new char[] { ',', ' ' });
            Console.WriteLine(String.Format("{0}'s inventory contains: {1}", _name, text));
        }   
    }
}