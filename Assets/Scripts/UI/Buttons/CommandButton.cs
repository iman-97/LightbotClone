using Commands;
using Managers;
using UnityEngine;

namespace UI.Buttons
{
    public abstract class CommandButton : MonoBehaviour
    {
        [SerializeField]
        protected CommandListItem listVisual;

        protected Command command;

        public void AddCommand()
        {
            GameManager.Instance.AddCommandToActiveList(command, listVisual);
        }

    }
}