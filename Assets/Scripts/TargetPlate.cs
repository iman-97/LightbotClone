using Managers;
using UnityEngine;

public class TargetPlate : MonoBehaviour
{
    private bool _isActive;
    private Material _material;

    private void Start() => _material = GetComponent<MeshRenderer>().material;

    public void Activate()
    {
        if (_isActive == true)
            return;

        _isActive = true;
        _material.color = Color.yellow;
        GameManager.Instance.CheckWin();
    }

}
