using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Heroes.Models.Heroes;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            //var knights = players
            //    .OfType<Knight>()
            //    .Where(knights => knights.IsAlive)
            //    .ToList();

            //var barbarians = players
            //    .OfType<Barbarian>()
            //    .Where(barb => barb.IsAlive)
            //    .ToList();

            var knights = new List<Knight>();
            var barbarians = new List<Barbarian>();

            foreach (var player in players)
            {
                if (player.IsAlive)
                {
                    if (player is Knight)
                    {
                        knights.Add((Knight)player);
                    }
                    else if (player is Barbarian)
                    {
                        barbarians.Add((Barbarian)player);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid player type.");
                    }
                }
            }

            var continueBattle = true;

            while (continueBattle)
            {
                var allKnightsAreDead = true;
                var allBarbsAreDead = true;

                var aliveKnights = 0;
                var aliveBarbs = 0;
                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        allKnightsAreDead = false;
                        aliveKnights++;
                        foreach (var barbarian in barbarians)
                        {
                            var weaponDamage = knight.Weapon.DoDamage();

                            barbarian.TakeDamage(weaponDamage);
                        }
                    }
                }

                foreach (var barbarian in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        allBarbsAreDead = false;
                        aliveBarbs++;
                        foreach (var knight in knights)
                        {
                            var barbWeaponDamage = barbarian.Weapon.DoDamage();

                            knight.TakeDamage(barbWeaponDamage);
                        }
                    }
                }

                if (allKnightsAreDead)
                {
                    var deadBarbs = barbarians.Count - aliveBarbs;
                    return $"The barbarians took {deadBarbs} casualties but won the battle.";
                }

                if (allBarbsAreDead)
                {
                    var deadKnights = knights.Count - aliveKnights;
                    return $"The knights took {deadKnights} casualties but won the battle.";
                }

            }

            throw new InvalidOperationException("The map fight logic has a bug.");
        }
    }
} 
