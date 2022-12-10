using Managers;
using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{
    //[SerializeField]
    //private PlayerBridgeSO _playerBridge;
    [SerializeField]
    private int _playerInitialRotaion;
    [SerializeField]
    private Vector3 _playerInitialPosition;
    [SerializeField]
    private byte _targetInLevel;

    private void Start()
    {
        //_playerBridge.InitPlayer(_playerInitialPosition, _playerInitialRotaion);
        Player.Instance.Initialize(_playerInitialPosition, _playerInitialRotaion);
        GameManager.Instance.SetTargetCount(_targetInLevel);
    }
}
