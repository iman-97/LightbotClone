using Commands;
using System.Collections.Generic;
using System.Collections;
using Utilities;
using UnityEngine;
using UI;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField]
        private int _maxMainCommands = 12, _maxProcCommands = 8;
        //[SerializeField]
        //private PlayerBridgeSO _playerBridge;
        //[SerializeField]
        //private GameObject _player;

        private byte _targetCount;

        private List<Command> _mainCommands = new();
        private List<Command> _procCommands = new();

        private void Start()
        {
            //_playerBridge.SetPlayer(_player);
        }

        public void AddCommandToActiveList(Command command, CommandListItem visual)
        {
            AddCommandToMain(command, visual);
        }

        public void RemoveCommandFromActiveList(Command command)
        {
            RemoveCommandFromMain(command);
        }

        public void AddCommandToMain(Command command, CommandListItem visual)
        {
            if (_mainCommands.Count >= _maxMainCommands)
            {
                Debug.Log("Main command list is full");
                return;
            }
            Debug.Log("Add command to main");
            _mainCommands.Add(command);
            UIManager.Instance.AddVisualToMain(command, visual);
        }

        public void RemoveCommandFromMain(Command command)
        {
            if (_mainCommands.Contains(command) == false)
            {
                Debug.Log("The following command is not awailabe in Main commands");
                return;
            }
            Debug.Log("remove command from main");
            _mainCommands.Remove(command);
        }

        public void AddCommandToProc(Command command)
        {
            if (_procCommands.Count >= _maxProcCommands)
            {
                Debug.Log("Proc command list is full");
                return;
            }

            _procCommands.Add(command);
        }

        public void RemoveCommandFromProc(Command command)
        {
            if (_procCommands.Contains(command) == false)
            {
                Debug.Log("The following command is not awailabe in Proc commands");
                return;
            }

            _procCommands.Remove(command);
        }

        public void RunMainCommands()
        {
            StartCoroutine(Run());

            IEnumerator Run()
            {
                foreach (var command in _mainCommands)
                {
                    command.Execute();
                    yield return new WaitForSeconds(.5f);
                }
            }

        }

        public void RunProcCommands()
        {
            StartCoroutine(Run());

            IEnumerator Run()
            {
                foreach (var command in _procCommands)
                {
                    command.Execute();
                    yield return new WaitForSeconds(.5f);
                }
            }
        }

        public void SetTargetCount(byte count) => _targetCount = count;

        public void CheckWin()
        {
            _targetCount--;

            if(_targetCount == 0)
            {
                //win
                Debug.Log("Win");
                UIManager.Instance.ShowNextLevelButton();
            }
        }

    }
}
