namespace Raiding.Models
{
    using Raiding.Global;
    public class Paladin : BaseHero
    {
        public Paladin(string name) : base(name)
        {
        }

        public override int Power => GlobalConst.PaladinAndWarriorPower;

        public override string CastAbility()
        {
            return string.Format(GlobalConst.PaladinAndDruidString, GetType().Name, Name, Power);
        }
    }
}
