public class Influence
{
    public float GivingBoodLevelPerSecond = 0f;
    public float FilteringBloodPerSecond = 0f;
    public float BloodPumping = 0f;
    public float GivingOxygen = 0f;
    public float GivingOxygenStorage = 0f;
}

public abstract class BodyPart
{
    private float _effency;

    public float Effency => _effency;

    public abstract Influence GetInfluence();
}

public class Lung : BodyPart
{
    private float _givingOxygen = 6f;
    private float _givingOxygenStorage = 50f;

    public override Influence GetInfluence()
    {
        return new() { GivingOxygen = _givingOxygen * Effency, GivingOxygenStorage = _givingOxygenStorage * Effency };
    }
}