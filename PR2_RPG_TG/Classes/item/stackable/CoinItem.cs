using PR2_RPG_TG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR2_RPG_TG.Classes.item.stackable
{
    internal class CoinItem : Item, Stackable
    {
        public string name { get; set; }
        public int weight { get; set; }
        public int quantity { get; set; }
        public CoinItem(String _name, int w, int q)
        {
            name = _name;
            weight = w;
            quantity = q;
        }
    }
}
