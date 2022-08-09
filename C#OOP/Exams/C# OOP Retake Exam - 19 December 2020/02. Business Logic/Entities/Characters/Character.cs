using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		// TODO: Implement the rest of the class.

		private string name;
		private double health;
		private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag) //<- protected
        {
            this.Name = name;
			this.BaseHealth = health;
			this.Health = health;
			this.BaseArmor = armor;
			this.Armor = armor;
			this.AbilityPoints = abilityPoints;
			this.Bag = bag;
		}

        public IBag Bag { get; private set; }

        public double AbilityPoints { get; private set; }

        public double BaseArmor  { get; private set; }

        public double Armor
		{
            get 
			{ 
				return armor; 
			}
            private set 
			{
				armor = value;

                if (armor < 0)
                {
					armor = 0;
                }
			}
        }

        public double BaseHealth { get; private set; }

        public double Health
		{
            get 
			{ 
				return health; 
			}
            set 
			{
				health = value;

				if (health < 0)
				{
					health = 0;
					IsAlive = false;
				}

                if (health > BaseHealth)
                {
					health = BaseHealth;
                }
			}
        }

        public string Name 
		{ 
			get 
			{ 
				return this.name; 
			} 
			private set 
			{
                if (string.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);

				}
				this.name = value; 
			}
		}

		public bool IsAlive { get; set; } = true;


		public void TakeDamage(double hitPoints)
        {
            if (!this.IsAlive)
            {
				return;
            }

			//EnsureAlive(); ??

			double leftHitPoints = hitPoints - this.Armor > 0
				? hitPoints - this.Armor
				: 0;

			this.Armor -= hitPoints;
			this.Health -= leftHitPoints;
			this.IsAlive = this.Health > 0;
           
        }

		public void UseItem(Item item)
        {
			this.EnsureAlive();

			item.AffectCharacter(this);

        }


		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}