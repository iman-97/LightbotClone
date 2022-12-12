using Managers;
using UnityEngine;
using Utilities;

public class TargetPlate : MonoBehaviour
{
    [SerializeField]
    private EventChannel _eventChannel;

    private bool _isActive;
    private Material _material;

    private void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
        _eventChannel.OnReset += Deactive;
        _eventChannel.OnRewind += Deactive;
    }

    private void OnDestroy()
    {
        _eventChannel.OnReset -= Deactive;
        _eventChannel.OnRewind -= Deactive;
    }

    public void Activate()
    {
        if (_isActive == true)
            return;

        _isActive = true;
        _material.color = Color.yellow;
        GameManager.Instance.CheckWin();
    }

    private void Deactive()
    {
        _isActive = false;
        _material.color = Color.cyan;
    }

}
