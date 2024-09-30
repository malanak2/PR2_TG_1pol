using PR2_RPG_TG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR2_RPG_TG.Classes.item.stackable
{
    public class CoinItem : Item, Stackable
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int quantity { get; set; }
        public CoinItem(String _name, int w, int q)
        {
            Name = _name;
            Weight = w;
            quantity = q;
        }
    }
}
