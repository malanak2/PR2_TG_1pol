using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PR2_RPG_TG.Interfaces;
namespace PR2_RPG_TG.Classes.item
{
    public class BasicItem : Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }

        public BasicItem(string n, int w)
        {
            Name = n;
            Weight = w;
        }
    }
}
