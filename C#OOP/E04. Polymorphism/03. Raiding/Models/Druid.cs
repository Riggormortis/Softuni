using Raiding.Global;

namespace Raiding.Models
{
   public class Druid : BaseHero
    {
       

        public Druid(string name) 
            : base(name)
        {
        }

        public override int Power => GlobalConst.DruidAndRoguePower;

        public override string CastAbility()
        {
            return string.Format(GlobalConst.PaladinAndDruidString, GetType().Name, Name, Power);
        }



    }
}
