using Unity.Netcode;
using UnityEngine;

public class NetworkUI : MonoBehaviour
{
    [SerializeField] private GameObject _connectInterface;
    [SerializeField] private GameObject _playerList;

    public void Connect()
    {
        NetworkManager.Singleton.StartClient();
        HideInterface();
    }

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        HideInterface();
    }

    private void HideInterface()
    {
        _connectInterface.SetActive(false);
        _playerList?.SetActive(true);
    }
}
