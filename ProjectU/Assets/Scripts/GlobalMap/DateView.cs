using TMPro;
using UnityEngine;

public class DateView : MonoBehaviour
{
    [SerializeField] private DateEngine _timeEngine;
    [SerializeField] private TMP_Text _dateText;
    private void FixedUpdate()
    {
        _dateText.text = GetDate(_timeEngine.Date);
    }
    private string GetDate(Date date)
    {
        return $"{date.Year} year\n{date.Day} {date.Month}\n{date.Hour}:{date.Minuts}:{date.Seconds}";
    }
}