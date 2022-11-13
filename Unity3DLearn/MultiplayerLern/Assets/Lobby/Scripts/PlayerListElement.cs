using TMPro;
using Unity.Netcode;
using UnityEngine;

public class PlayerListElement : NetworkBehaviour
{
    [SerializeField] private TMP_Text textField;

    public PlayerListElement Init(string Nickname)
    {
        textField.text = Nickname;
        return this;
    }
}
