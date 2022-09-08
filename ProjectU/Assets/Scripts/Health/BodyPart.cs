public abstract class BodyPart
{
    private float _heatPoit;
    public float HeatPoint => _heatPoit;

    public abstract Influence GetInfluence();
}