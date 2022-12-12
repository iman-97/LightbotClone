using System;
using UnityEngine;

namespace Utilities
{
    [CreateAssetMenu(menuName = "Event Channel")]
    public class EventChannel : ScriptableObject
    {
        public event Action OnReset, OnPlayStart, OnPlayEnd, OnRewind;

        public void ResetGame() => OnReset?.Invoke();

        public void PlayStartEvent() => OnPlayStart?.Invoke();

        public void PlayEndEvent() => OnPlayEnd?.Invoke();

        public void RewindEvent() => OnRewind?.Invoke();

    }
}