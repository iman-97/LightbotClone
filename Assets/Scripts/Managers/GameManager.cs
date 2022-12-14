using Commands;
using System.Collections;
using Utilities;
using UnityEngine;
using UI;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField]
        private EventChannel _eventChannel;
        [SerializeField]
        private CommandController _mainCommandController;
        [SerializeField]
        private CommandController[] _procedureCommands;

        private byte _targetCount;
        private bool _isProc, _noDelay;
        private CommandController _currentCommandController;

        private void Start()
        {
            _currentCommandController = _mainCommandController;
        }

        public void AddCommandToActiveList(Command command, CommandListItem visual)
        {
            _currentCommandController.AddCommand(command, visual);
        }

        public void RemoveCommandFromActiveList(Command command, GameObject visual)
        {
            _currentCommandController.RemoveCommand(command, visual);
        }

        public void CleanCommands()
        {
            _mainCommandController.ClearCommands();

            foreach (var controller in _procedureCommands)
                controller.ClearCommands();

        }

        public void RunMainCommands()
        {
            _currentCommandController = _mainCommandController;
            _eventChannel.PlayStartEvent();
            RunCommands();
        }

        public void RunProcCommands(byte procNumber)
        {
            _currentCommandController = _procedureCommands[procNumber];
            _isProc = true;
            _noDelay = true;
        }

        public void SetTargetCount(byte count) => _targetCount = count;

        /// <summary>
        /// sets the active CommandController
        /// </summary>
        /// <param name="id">id of CommandController</param>
        public void SetActiveList(byte id)
        {
            if (id == 0)
                _currentCommandController = _mainCommandController;
            else
                _currentCommandController = _procedureCommands[id - 1];
        }

        /// <summary>
        /// checks the win state
        /// </summary>
        public void CheckWin()
        {
            _targetCount--;

            if(_targetCount == 0)
            {
                Debug.Log("Win");
                UIManager.Instance.ShowNextLevelButton();
            }
        }
        
        /// <summary>
        /// Execute commands available in command lists
        /// </summary>
        private void RunCommands()
        {
            var com = _currentCommandController.ActiveCommand();

            if(com == null)
            {
                if (_isProc == true)
                {
                    _currentCommandController = _mainCommandController;
                    _isProc = false;
                    RunCommands();
                    return;
                }
                else
                {
                    //end of main commands
                    _eventChannel.PlayEndEvent();
                    return;
                }
            }

            com.Execute();
            StartCoroutine(Delay());

            IEnumerator Delay()
            {
                if (_noDelay == true)
                {
                    _noDelay = false;
                    yield return null;
                }
                else
                    yield return new WaitForSeconds(.5f);

                RunCommands();
            }
        }

    }
}
