namespace Effects
{
    public class BaseDamage : Effect
    {
        private int _damage;
        public BaseDamage(int damage) : base(0)
        {
            _damage = damage;
        }

        public override Impact GetImpact()
        {
            if (FirstTick)
            {
                return new Impact()
                {
                    Damage = _damage
                };
            }
            return new Impact();
        }
    }
}
