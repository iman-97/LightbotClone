using Managers;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public void StartLevel(int level) => LevelManager.Instance.LoadLevel(level);
}
