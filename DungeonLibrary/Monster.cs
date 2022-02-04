using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //FIELDS
        private int _minDamage;

        //PROPERTIES

        public int MaxDamage { get; set; }

        public string Description { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }

        public Monster(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description)
        {
            MaxLife = MaxLife;
            MaxDamage = maxDamage;
            Name = name;
            Life = life;
            HitChance = hitChance;
            Block = block;
            MinDamage = minDamage;
            Description = description;
        }

        public Monster() { }

        public override string ToString()
        {
            return string.Format("\n***** Monster *****\n" +
                "{0}\nLife: {1} of {2}\nDamage: {3} to {4}\n" +
                "Block: {5}\nDescription:\n{6}\n",
                Name,
                Life,
                MaxLife,
                MinDamage,
                MaxDamage,
                Block,
                Description);
        }

        public override int CalcDamage()
        {
            Random rand = new Random();

            return rand.Next(MinDamage, MaxDamage + 1);
        }

    }
}
