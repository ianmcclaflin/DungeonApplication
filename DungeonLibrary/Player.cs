using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Player : Character
    {
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

        public Player(string name, int hitChance, int block, int life, int maxLife,
            Race characterRace, Weapon equippedWeapon)
        {
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon; 

        }

        //METHODS
        public override string ToString()
        {
            //return base.ToString();

            string description = "";

            switch (CharacterRace)
            {
                case Race.Warrior:
                    break;
                case Race.Ninja:
                    break;
                case Race.Dwarf:
                    break;
                case Race.Thief:
                    break;
                case Race.Dragoon:
                    break;
            }

            return string.Format("-=-= {0} =-=-\n" +
                "Life: {1} of {2}\nHit Chance: {3}%\n" +
                "Weapon:\n{4}\nBlock: {5}\nDescription: {6}",
                Name,
                Life,
                MaxLife,
                CalcHitChance(),
                EquippedWeapon,
                Block,
                description);
        }

        public override int CalcDamage()
        {
            //return base.CalcDamage();)
            Random rand = new Random();
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            return damage;
        }

        public override int CalcHitChance()
        {
            //return base.CalcHitChance();

            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }




    }
}
