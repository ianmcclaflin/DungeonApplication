using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonLibrary;

namespace MonsterLibrary
{
    public class BlueBlob : Monster
    {
        public bool IsSlimey { get; set; }

        public BlueBlob(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isSlimey)
            : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            IsSlimey = isSlimey;
        }

        public BlueBlob()
        {
            MaxLife = 12;
            MaxDamage = 4;
            Name = "BlueBlob";
            Life = 11;
            HitChance = 30;
            Block = 20;
            MinDamage = 1;
            Description = "This is a dreaded Blue Blob";
            IsSlimey = false;
        }

        public override string ToString()
        {
            return base.ToString() + (IsSlimey ? "Not Slimey" : "This blob is extra slimey");
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
