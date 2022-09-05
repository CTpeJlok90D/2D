public class Lung : BodyPart
{
    private float _givingOxygen = 6f;
    private float _givingOxygenStorage = 50f;

    public override Influence GetInfluence()
    {
        return new() { GivingOxygen = _givingOxygen * HeatPoint, GivingOxygenStorage = _givingOxygenStorage * HeatPoint };
    }
}