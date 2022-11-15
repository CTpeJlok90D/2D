using System;

[Serializable]
public struct Impact
{
    public int Damage;
    public int Heal;

    public static Impact operator +(Impact a, Impact b)
    {
        return new Impact() 
        {
            Damage = a.Damage + b.Damage,
            Heal = a.Heal + b.Heal
        };
    }
}