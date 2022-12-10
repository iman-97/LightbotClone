using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CommandListSelector : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;
        [SerializeField]
        private Outline _outline;

        private bool _isActive;

        public void Select()
        {
            if (_isActive == true)
                return;

            _isActive = true;
            _outline.enabled = true;
            _canvasGroup.interactable = true;
            //set active list in game manager
        }

        public void UnSelect()
        {
            if (_isActive == false)
                return;

            _isActive = false;
            _outline.enabled = false;
            _canvasGroup.interactable = false;
        }

    }
}