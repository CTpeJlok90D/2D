using UnityEngine;
using TMPro;

public class CashView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textField;
    [SerializeField] private Cash _cash;
    
    public void UpdateText() 
    {
        _textField.text = $"x{_cash.Current}";
    }
}
