using System;
using UnityEngine;

namespace Utilities
{
    [CreateAssetMenu(menuName = "Event Channel")]
    public class EventChannel : ScriptableObject
    {
        public event Action OnReset;

        public void OnResetGame() => OnReset?.Invoke();

    }
}