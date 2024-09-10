using PR2_RPG_TG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PR2_RPG_TG.Classes.item.equipable.armor
{
    internal class ArmorItem : Item, Armor, Equipable
    {
        public string name { get; set; }
        public int weight { get; set; }
        public int defense { get; set; }

        public ArmorItem(String _name, int w, int d)
        {
            name = _name;
            weight = w;
            defense = d;
        }
    }
}
