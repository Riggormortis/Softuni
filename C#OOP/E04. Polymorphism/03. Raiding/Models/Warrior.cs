
namespace Raiding.Models
{
    using Raiding.Global;
    public class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        { }

        public override int Power => GlobalConst.PaladinAndWarriorPower;

        public override string CastAbility()
        {
            return string.Format(GlobalConst.WarriorAndRogueString, GetType().Name, Name, Power);
        }
    }
}
