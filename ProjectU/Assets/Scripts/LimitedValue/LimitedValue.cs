using System;
using UnityEngine;

[Serializable]
public class LimitedValue
{
    [SerializeField] private float _max;
    [SerializeField] private float _min;
    [SerializeField] private float _current;

    public LimitedValue(float value, float max)
    {
        _max = max;
        _min = int.MinValue;
        Current = value;
    }

    public LimitedValue(float value, float max, float min)
    {
        if (min > max)
        {
            throw new Exception("Maximum value must be more then minimum");
        }
        _min = min;
        _max = max;
        Current = value;
    }

    public float Max => _max;
    public float Min => _min;
    public float Current
    {
        get 
        {
            return _current;
        }
        set
        {
            _current = Math.Clamp(value, _min, _max);
        }
        
    }

    public void SetNewBorders(float min, float max)
    {
        _min = min;
        _max = max;
        Current = _current;
    }

    public void SetNewMax(float max)
    {
        _max = max;
        Current = _current;
    }

    public void SetNewMin(float min)
    {
        _min = min;
        Current = _current;
    }

    public override string ToString()
    {
        return Current.ToString();
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    static public LimitedValue operator+(LimitedValue a, LimitedValue b)
    {
        CompareBorders(a,b);
        return new LimitedValue(a.Current + b.Current, a.Max, a.Min);
    }

    static public LimitedValue operator-(LimitedValue a, LimitedValue b)
    {
        CompareBorders(a, b);
        return new LimitedValue(a.Current - b.Current, a.Max, a.Min);
    }

    static public LimitedValue operator *(LimitedValue a, LimitedValue b)
    {
        CompareBorders(a, b);
        return new LimitedValue(a.Current * b.Current, a.Max, a.Min);
    }

    static public LimitedValue operator /(LimitedValue a, LimitedValue b)
    {
        CompareBorders(a, b);
        return new LimitedValue(a.Current / b.Current, a.Max, a.Min);
    }

    static public LimitedValue operator +(LimitedValue a, float b) => new LimitedValue(a.Current + b, a.Max, a.Min);
    static public LimitedValue operator -(LimitedValue a, float b) => new LimitedValue(a.Current - b, a.Max, a.Min);
    static public LimitedValue operator *(LimitedValue a, float b) => new LimitedValue(a.Current * b, a.Max, a.Min);
    static public LimitedValue operator /(LimitedValue a, float b) => new LimitedValue(a.Current / b, a.Max, a.Min);


    static public float operator +(float a, LimitedValue b) => a + b.Current;
    static public float operator -(float a, LimitedValue b) => a - b.Current;
    static public float operator *(float a, LimitedValue b) => a * b.Current;
    static public float operator /(float a, LimitedValue b) => a / b.Current;

    static public bool operator ==(float a, LimitedValue b) => a == b.Current;
    static public bool operator !=(float a, LimitedValue b) => a != b.Current;
    static public bool operator ==(LimitedValue a, float b) => a.Current == b;
    static public bool operator !=(LimitedValue a, float b) => a.Current != b;
    static public bool operator ==(LimitedValue a, LimitedValue b) => a.Current == b.Current;
    static public bool operator !=(LimitedValue a, LimitedValue b) => a.Current != b.Current;

    static public bool operator >(LimitedValue a, LimitedValue b) => a.Current > b.Current;
    static public bool operator <(LimitedValue a, LimitedValue b) => a.Current < b.Current;
    static public bool operator >(float a, LimitedValue b) => a > b.Current;
    static public bool operator <(float a, LimitedValue b) => a < b.Current;
    static public bool operator >(LimitedValue a, float b) => a.Current > b;
    static public bool operator <(LimitedValue a, float b) => a.Current < b;

    static public bool operator >=(LimitedValue a, LimitedValue b) => a.Current >= b.Current;
    static public bool operator <=(LimitedValue a, LimitedValue b) => a.Current <= b.Current;   
    static public bool operator >=(float a, LimitedValue b) => a >= b.Current;
    static public bool operator <=(float a, LimitedValue b) => a <= b.Current;    
    static public bool operator >=(LimitedValue a, float b) => a.Current >= b;
    static public bool operator <=(LimitedValue a, float b) => a.Current <= b;

    static private bool IsIdenticalBorders(LimitedValue a, LimitedValue b)
    {
        return (a.Min == b.Min && a.Max == a.Max);
    }

    static private void CompareBorders(LimitedValue a, LimitedValue b)
    {
        if(IsIdenticalBorders(a,b) == false)
        {
            throw new Exception("Borders must of the limited value be identity");
        }
    }
}