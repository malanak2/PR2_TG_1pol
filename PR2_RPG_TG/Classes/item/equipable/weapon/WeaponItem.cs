using PR2_RPG_TG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR2_RPG_TG.Classes.item.equipable.weapon
{
    internal class WeaponItem : Item, Weapon, Equipable
    {
        public string name { get; set; }
        public int weight { get; set; }
        public int damage { get; set; }

        public WeaponItem(String _name, int w, int d) 
        {
            name = _name;
            weight = w;
            damage = d;
        }
    }
}
