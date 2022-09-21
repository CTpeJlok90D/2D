public class Stun : Effect
{
    public Stun(float dituratuin) : base(dituratuin){}

    public override Impact GetEffectResult()
    {
        return new()
        {
            Stun = true,
            StunImmunitete = true
        };
    }
}