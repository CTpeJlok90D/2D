abstract public class Effect
{
    private float _dituratuin;
    public float Diruration => _dituratuin;

    public Effect(float dituratuin)
    {
        _dituratuin = dituratuin;
    }

    public void RemoveDiruration(float value)
    {
        _dituratuin -= value;
    }

    abstract public Impact GetEffectResult();
}