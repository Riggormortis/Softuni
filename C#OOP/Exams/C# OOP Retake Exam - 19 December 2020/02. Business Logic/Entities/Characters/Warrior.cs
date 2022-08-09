using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
//    public class Warrior : Character, IAttacker
//    {
//        public Warrior(string name) 
//            : base(name, 100, 50, 40, new Satchel())
//        {
//        }

//        public void Attack(Character character)
//        {
//            this.EnsureAlive();

//            if (this.Equals(character))
//            {
//                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
//            }

//            character.TakeDamage(this.AbilityPoints);
//        }
//    }
//}

    public class Warrior : Character, IAttacker
    {
        private const double DefaultHealth = 100;
        private const double DefaultArmor = 50;
        private const double DefaultAbilityPoints = 40;

        private static Bag DefaultBag = new Satchel();

        public Warrior(string name) 
            : base(name, DefaultHealth, DefaultArmor, DefaultAbilityPoints, DefaultBag)
        {
        }

        public void Attack(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (this.Equals(character))
                {
                    throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
                }

                character.TakeDamage(this.AbilityPoints);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            

            
        }
    }
}
