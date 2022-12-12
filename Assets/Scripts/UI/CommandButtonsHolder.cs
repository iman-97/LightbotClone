using UnityEngine;
using Utilities;

namespace UI
{
    public class CommandButtonsHolder : MonoBehaviour
    {
        [SerializeField]
        private EventChannel _eventChannel;
        [SerializeField]
        private CanvasGroup _canvasGroup;

        private void Start()
        {
            _eventChannel.OnPlayStart += OnPlayStart;
            _eventChannel.OnPlayEnd += OnPlayEnd;
        }

        private void OnDestroy()
        {
            _eventChannel.OnPlayStart -= OnPlayStart;
            _eventChannel.OnPlayEnd -= OnPlayEnd;
        }

        private void OnPlayStart() => _canvasGroup.interactable = false;

        private void OnPlayEnd() => _canvasGroup.interactable = true;

    }
}