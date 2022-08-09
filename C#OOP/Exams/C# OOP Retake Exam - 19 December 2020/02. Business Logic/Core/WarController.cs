using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private readonly List<Character> characters;
		private readonly List<Item> items;


		public WarController()
		{
			this.characters = new List<Character>();
			this.items = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

			Character character = null;

			if (characterType == nameof(Warrior))
			{
				character = new Warrior(name);
			}
			else if (characterType == nameof(Priest))
			{
				character = new Priest(name);
			}
            else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
			}

			this.characters.Add(character);

			return string.Format(SuccessMessages.JoinParty, name);

		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
			Item item = null;

			if (itemName == nameof(FirePotion))
            {
				item = new FirePotion();
			}
            else if (itemName == nameof(HealthPotion))
            {
				item = new HealthPotion();
			}
            else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
			}

			this.items.Add(item);
			return string.Format(SuccessMessages.AddItemToPool, itemName);
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
			Character character = this.characters
				.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}
            if (!items.Any())
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

			Item item = this.items.LastOrDefault();
			character.Bag.AddItem(item);
			this.items.Remove(item);

			return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);

		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];
			Character character = this.characters
				.FirstOrDefault(x => x.Name == characterName);

			if (character == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}
			
			Item item = character.Bag.GetItem(itemName);
			character.UseItem(item);

			return string.Format(SuccessMessages.UsedItem, characterName, itemName);
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();


			foreach (var character in this.characters
				.OrderByDescending(x => x.IsAlive)
				.ThenBy(x => x.Health))
            {
				sb.AppendLine(string.Format(
					SuccessMessages.CharacterStats, character.Name, character.Health, character.BaseHealth, character.Armor, character.BaseArmor, (character.IsAlive ? "Alive" : "Dead")));
            }

			return sb.ToString().TrimEnd();
		}

		

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			Character attacker = this.characters
				.FirstOrDefault(x => x.Name == attackerName);
			Character receiver = this.characters
				.FirstOrDefault(x => x.Name == receiverName);

			if (attacker == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
			}
			if (receiver == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
			}

			if (!(attacker is IAttacker))
			{
				throw new ArgumentException(String.Format(ExceptionMessages.AttackFail, attackerName));
			}


			((IAttacker)attacker).Attack(receiver);

			string result = string.Format(SuccessMessages.AttackCharacter, attackerName, receiverName, attacker.AbilityPoints, receiverName, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor);

            if (!receiver.IsAlive)
            {
				result += Environment.NewLine +
					string.Format(SuccessMessages.AttackKillsCharacter, receiverName);
            }

			return result;
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string receiverName = args[1];

			Character healer = this.characters
				.FirstOrDefault(x => x.Name == healerName);
			Character receiver = this.characters
				.FirstOrDefault(x => x.Name == receiverName);

			if (healer == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
			}
			if (receiver == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
			}

            if (!(healer is IHealer))
            {
				throw new ArgumentException(String.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

			((IHealer)healer).Heal(receiver);

			return string.Format(SuccessMessages.HealCharacter, healer.Name, receiver.Name, healer.AbilityPoints, receiver.Name, receiver.Health);

		}
	}
}
