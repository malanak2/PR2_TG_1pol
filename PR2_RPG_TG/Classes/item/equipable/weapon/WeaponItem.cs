using PR2_RPG_TG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR2_RPG_TG.Classes.item.equipable.weapon
{
    public class WeaponItem : Item, Weapon, Equipable
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Damage { get; set; }

        public WeaponItem(String _name, int w, int d) 
        {
            Name = _name;
            Weight = w;
            Damage = d;
        }
    }
}
