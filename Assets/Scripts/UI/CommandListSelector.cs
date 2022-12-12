using Managers;
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
        [SerializeField]
        private Transform _itemHolder;
        [SerializeField]
        private Button _button;
        [SerializeField]
        private byte id;

        private bool _isActive;

        public void Select()
        {
            if (_isActive == true)
                return;

            _isActive = true;
            _outline.enabled = true;
            _canvasGroup.interactable = true;
            GameManager.Instance.ActiveList(id);
        }

        public void UnSelect()
        {
            if (_isActive == false)
                return;

            _isActive = false;
            _outline.enabled = false;
            _canvasGroup.interactable = false;
        }

        public void AddCommandVisual(Transform visual)
        {
            visual.parent = _itemHolder;
            visual.localScale = Vector3.one;
        }

        public void ClearVisuals()
        {
            for (int i = 0; i < _itemHolder.childCount; i++)
            {
                Destroy(_itemHolder.GetChild(i).gameObject);
            }
        }

        public void BlockTouch()
        {
            _button.interactable = false;
            _canvasGroup.interactable = false;
        }

        public void AllowTouch()
        {
            _button.interactable = true;
            _canvasGroup.interactable = true;
        }

    }
}