using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PR2_RPG_TG.Interfaces;
namespace PR2_RPG_TG.Classes.item
{
    internal class BasicItem : Item
    {
        public string name { get; set; }
        public int weight { get; set; }

        public BasicItem(string n, int w)
        {
            name = n;
            weight = w;
        }
    }
}
