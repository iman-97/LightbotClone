using Managers;
using System.Collections;
using UnityEngine;
using Utilities;

public class Player : Singleton<Player>
{
    [SerializeField]
    private EventChannel _eventChannel;

    private Material _material;
    private Vector3 _currentPosition;
    private int _cuurentRotation;

    private void Start()
    {
        _material = GetComponentInChildren<MeshRenderer>().material;
        _eventChannel.OnRewind += SetupPlayer;
    }

    private void OnDestroy() => _eventChannel.OnRewind -= SetupPlayer;

    public void Initialize(Vector3 position, int rotation)
    {
        _currentPosition = position;
        _cuurentRotation = rotation;
        SetupPlayer();
    }

    public void MoveForward()
    {
        if (CheckForwardDown() == false)
            return;

        transform.position = transform.position + transform.right;
    }

    public void RotateLeft() => transform.Rotate(Vector3.up, -90f);

    public void RotateRight() => transform.Rotate(Vector3.up, 90f);

    public void Jump()
    {
        if (CheckForwardDown() == false)
        {
            if (CheckJumpDown() == false)
                return;
            else
            {
                transform.position = transform.position + new Vector3(0, -0.5f, 0) + transform.right;
                return;
            }
        }

        if (CheckForward() == false)
            return;

        if (CheckForDoublePLate() == false)
            return;

        transform.position = transform.position + transform.right + new Vector3(0f, 0.5f, 0);
    }

    public void LightOn()
    {
        Ray ray = new Ray(transform.position + new Vector3(0, .5f, 0), Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 0.25f))
        {
            if (hit.transform.CompareTag("Target") == false)
                Debug.Log("This plate is not target");
            else
                hit.transform.GetComponent<TargetPlate>().Activate();
        }
        else
            Debug.Log("light check faild");

        _material.color = Color.yellow;
        StartCoroutine(Delay());

        IEnumerator Delay()
        {
            yield return new WaitForSeconds(.2f);
            LightOff();
        }
    }

    public void LightOff() => _material.color = Color.green;

    private void SetupPlayer()
    {
        transform.SetPositionAndRotation(_currentPosition, Quaternion.Euler(0, _cuurentRotation, 0));
    }

    private bool CheckForwardDown()
    {
        Ray ray = new Ray(transform.position + new Vector3(0, .4f, 0) + transform.right, Vector3.down);
        if (Physics.Raycast(ray, .6f) == false)
        {
            Debug.Log("there is no plate in front of player");
            return false;
        }

        return true;
    }

    private bool CheckForward()
    {
        Ray ray = new Ray(transform.position + new Vector3(0, 0.7f, 0), transform.right);
        if (Physics.Raycast(ray, 1f) == false)
        {
            Debug.Log("there is no plate for jump");
            return false;
        }

        return true;
    }

    private bool CheckForDoublePLate()
    {
        Ray ray = new Ray(transform.position + new Vector3(0, 1f, 0), transform.right);
        if (Physics.Raycast(ray, 1f) == true)
        {
            Debug.Log("Its Too high cant jump");
            return false;
        }

        return true;
    }

    private bool CheckJumpDown()
    {
        Ray ray = new Ray(transform.position - new Vector3(0, .5f, 0), transform.right);
        if (Physics.SphereCast(ray, .2f) == false)
        {
            Debug.Log("cant jump down");
            return false;
        }

        return true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Ray ray = new Ray(transform.position + new Vector3(0, .4f, 0) + transform.right, Vector3.down);
        Gizmos.DrawRay(ray);
        ray = new Ray(transform.position + new Vector3(0, 0.7f, 0), transform.right);
        Gizmos.DrawRay(ray);
        ray = new Ray(transform.position + new Vector3(0, 1f, 0), transform.right);
        Gizmos.DrawRay(ray);
        Gizmos.DrawSphere(transform.position - new Vector3(0, .5f, 0) + transform.right, .2f);
    }

}
