using TMPro;
using UnityEngine;

public class TimeMover : MonoBehaviour
{
    [SerializeField] private float _timeMultiply = 1;
    [SerializeField] private ClockView _minutsClockView;
    [SerializeField] private ClockView _hoursClockView;
    [SerializeField] private TMP_Text _dateText;

    private Date _date = new(60, 14, 20, Month.Waterfall, 44);
    public Date Date => _date;
    public void SetTimeMultiply(float value)
    {
        _timeMultiply = value;
    }
    private void FixedUpdate()
    {
        _date.Seconds += Time.fixedDeltaTime * _timeMultiply;
    }
    private void Update()
    {
        _minutsClockView.ApplyValue((float)_date.Minuts / Date.MinutsInHour);
        _hoursClockView.ApplyValue((float)_date.Hour / Date.HoursInDay);
        _dateText.text = GetDate(_date);
    }
    private string GetDate(Date date)
    {
        return $"{date.Year} year\n{date.Day} {date.Month}\n{date.Hour}:{date.Minuts}";
    }
}
