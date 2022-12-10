using UnityEngine;

[CreateAssetMenu(menuName = "Player Bridge")]
public class PlayerBridgeSO : ScriptableObject
{
    private Player _player;
    private GameObject _gameObject;

    public Player Player { get => _player; set => _player = value; }

    public void SetPlayer(GameObject player) => _gameObject = player;

    public void InitPlayer(Vector3 position, int rotation)
    {
        //_player = Instantiate(_playerPrefab, position, Quaternion.Euler(0, rotation, 0));
        _player.Initialize(position, rotation);
    }

    public void DeletePlayerOnGameEnd() => Destroy(_player);

}
