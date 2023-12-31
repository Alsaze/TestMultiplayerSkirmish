using Mirror;
using UnityEngine;
using GameStates;

public class NetworkManagerCustom : NetworkManager
{
    private int _playerCountForGame = 3;//this count can vary depending on GameMode like(1x1|2x2|3x3|...)
    private int _playerCount = 0;
    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        base.OnServerConnect(conn);
        _playerCount++;
        
        if (_playerCount == _playerCountForGame)
        {
            GameStateManager.Instance.SetBehaviorPlayingEarlyGame();
        }
        else
        {
            Debug.Log("not enaught players to game");
        }
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        base.OnServerDisconnect(conn);
        _playerCount--;
    }
}
