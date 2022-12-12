using Commands;
using Managers;
using UnityEngine;

namespace UI
{
    public class CommandListItem : MonoBehaviour
    {
        private Command _command;

        public void Initialize(Command command) => _command = command;

        public void RemoveFromList()
        {
            GameManager.Instance.RemoveCommandFromActiveList(_command, gameObject);
        }

    }
}