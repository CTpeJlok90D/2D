abstract public class Effect
{
    private float _dituratuin;
    private bool _firstTick = true;
    public float Diruration => _dituratuin;
    public bool FirstTick => _firstTick;
    virtual public bool Visible => false;

    public Effect(float dituratuin)
    {
        _dituratuin = dituratuin;
    }

    public void RemoveDiruration(float value)
    {
        _dituratuin -= value;
        _firstTick = false;
        FixedUpdate();
    }

    abstract public Impact GetImpact();
    
    virtual protected void FixedUpdate()
    {

    }
}