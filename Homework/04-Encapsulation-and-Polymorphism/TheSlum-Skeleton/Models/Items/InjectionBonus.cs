namespace TheSlum.Models.Items
{
    internal class InjectionBonus : Bonus
    {
        public InjectionBonus(string id, int healthEffect = 200, int defenseEffect = 0, int attackEffect = 0)
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
            this.Countdown = 3;
            this.Timeout = 3;
            this.HasTimedOut = false;
        }
    }
}