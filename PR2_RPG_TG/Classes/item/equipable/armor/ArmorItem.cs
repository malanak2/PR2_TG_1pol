using PR2_RPG_TG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PR2_RPG_TG.Classes.item.equipable.armor
{
    public class ArmorItem : Item, Armor, Equipable
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int defense { get; set; }

        public ArmorItem(String _name, int w, int d)
        {
            Name = _name;
            Weight = w;
            defense = d;
        }
    }
}
