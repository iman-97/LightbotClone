using Managers;
using UnityEngine;
using Utilities;

public class LevelInitializer : MonoBehaviour
{
    [SerializeField]
    private EventChannel _eventChannel;
    [SerializeField]
    private int _playerInitialRotaion;
    [SerializeField]
    private Vector3 _playerInitialPosition;
    [SerializeField]
    private byte _targetInLevel;

    private void Start()
    {
        InitializeLevel();
       _eventChannel.OnReset += InitializeLevel;
    }

    private void OnDestroy() => _eventChannel.OnReset -= InitializeLevel;

    /// <summary>
    /// Setup player and game manager for this level
    /// </summary>
    private void InitializeLevel()
    {
        Player.Instance.Initialize(_playerInitialPosition, _playerInitialRotaion);
        GameManager.Instance.SetTargetCount(_targetInLevel);
    }

}
