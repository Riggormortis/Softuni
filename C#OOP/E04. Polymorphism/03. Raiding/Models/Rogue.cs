namespace Raiding.Models
{
    using Raiding.Global;
    public class Rogue : BaseHero
    {
        public Rogue(string name)
            : base(name)
        {
        }

        public override int Power => GlobalConst.DruidAndRoguePower;
        public override string CastAbility()
        {
            return string.Format(GlobalConst.WarriorAndRogueString, GetType().Name, Name, Power);
        }

    }
}
