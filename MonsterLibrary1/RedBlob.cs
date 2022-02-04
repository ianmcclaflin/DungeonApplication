using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonLibrary;

namespace MonsterLibrary
{
    public class RedBlob : Monster
    {
        public RedBlob(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description) 
            : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {

        }

        public RedBlob()
        {
            MaxLife = 6;
            MaxDamage = 3;
            Name = "RedBlob";
            Life = 6;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "A gooey red blob";
        }







    }
}
