using UnityEngine;

namespace Effects
{
    public class Damage : Effect
    {
        private float _timeBetweenDamage;
        private int _damage;

        public Damage(float dituratuin, float timeBetweenDamage, int damage) : base(dituratuin)
        {
            _timeBetweenDamage = timeBetweenDamage;
            _damage = -damage;
        }

        public Damage(int damage) : base(0)
        {
            _timeBetweenDamage = Time.fixedDeltaTime;
            _damage = -damage;
        }

        public override Impact GetImpact()
        {
            return new Impact()
            {
                HealValue = Diruration % _timeBetweenDamage == 0 ? _damage : 0
            };
        }
    }
}