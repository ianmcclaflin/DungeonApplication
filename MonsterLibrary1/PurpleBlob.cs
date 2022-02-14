using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonLibrary; 

namespace MonsterLibrary
{
    public class PurpleBlob : Monster
    {
        public bool IsSlimey { get; set; }

        public PurpleBlob(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isSlimey)
            : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            IsSlimey = isSlimey;
        }

        public PurpleBlob()
        {
            MaxLife = 10;
            MaxDamage = 6;
            Name = "Purple Blob";
            Life = 10;
            HitChance = 35;
            Block = 25;
            MinDamage = 1;
            Description = "A red and blue blob have fuzed to create a Purple Blob";
            IsSlimey = false;

        }

        public override string ToString()
        {
            return base.ToString() + (IsSlimey ? "Blob is Smiley" : "Blob is not slimey");
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            if (IsSlimey)
            {
                calculatedBlock += calculatedBlock / 2;
            }

            return calculatedBlock;
        }






    }
}
