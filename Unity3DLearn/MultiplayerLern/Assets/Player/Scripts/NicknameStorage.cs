using Unity.Netcode;
using UnityEngine;

public class NicknameStorage : MonoBehaviour
{
    [SerializeField] private string _nickname = "Player";
    [SerializeField] private Lobby _lobby;

    public string Nickname => _nickname;

    public void SetNickname(string newNickname)
    {
        if (newNickname == "")
        {
            _nickname = "Player";
            return;
        }
        _nickname = newNickname;
    }
}
