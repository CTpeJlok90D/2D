using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Lobby : NetworkBehaviour
{
    [SerializeField] private Transform playerUIList;
    [SerializeField] private PlayerListElement playerUIListElementPrefab;
    [SerializeField] private NicknameStorage _storage;

    [SerializeField] private List<PlayerNetwork> _playerList = new();

    private void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += OnConnectedServerRPC;
    }

    [ServerRpc]
    private void OnConnectedServerRPC(ulong clientID)
    {
        AddPlayerServerRPC(clientID, "name");
    }

    [ServerRpc]
    public void AddPlayerServerRPC(ulong clientID, string playerNickname)
    {
        PlayerNetwork playerNetwork = NetworkManager.Singleton.ConnectedClients[clientID].PlayerObject.GetComponent<PlayerNetwork>();
        playerNetwork.Nickname = playerNickname;
        _playerList.Add(playerNetwork);
    }
}
