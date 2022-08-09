using UnityEngine;

public class DateEngine : MonoBehaviour
{
    [SerializeField] private int TimeMultiply = 1;
    private Date _date = new(60, 14, 20, Month.Waterfall, 44);
    public Date Date => _date;
    private void FixedUpdate()
    {
        _date.Seconds += Time.fixedDeltaTime * TimeMultiply;
    }
}
