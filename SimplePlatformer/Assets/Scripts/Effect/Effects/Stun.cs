public class Stun : Effect
{
    public Stun(float dituratuin) : base(dituratuin){}

    public override Impact GetImpact()
    {
        return new()
        {
            Stun = true,
            StunImmunitete = true
        };
    }
}