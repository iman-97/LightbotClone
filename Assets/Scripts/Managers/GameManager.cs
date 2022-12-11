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

        private byte _targetCount, _listId, _mainL, _procL;

        private List<Command> _mainCommands = new();
        private List<Command> _procCommands = new();

        public void AddCommandToActiveList(Command command, CommandListItem visual)
        {
            if (_listId == 0)
                AddCommandToMain(command, visual);
            else
                AddCommandToProc(command, visual);
        }

        public void RemoveCommandFromActiveList(Command command)
        {
            if (_listId == 0)
                RemoveCommandFromMain(command);
            else
                RemoveCommandFromProc(command);
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

        public void AddCommandToProc(Command command, CommandListItem visual)
        {
            if (_procCommands.Count >= _maxProcCommands)
            {
                Debug.Log("Proc command list is full");
                return;
            }
            Debug.Log("Add command to proc");
            _procCommands.Add(command);
            UIManager.Instance.AddVisualToProc(command, visual);
        }

        public void RemoveCommandFromProc(Command command)
        {
            if (_procCommands.Contains(command) == false)
            {
                Debug.Log("The following command is not awailabe in Proc commands");
                return;
            }
            Debug.Log("remove command from proc");
            _procCommands.Remove(command);
        }

        public void CleanCommands()
        {
            _mainCommands.Clear();
            _procCommands.Clear();
        }

        public void RunMainCommands()
        {
            //OnPlayStarts?.Invoke();

            //StartCoroutine(Run());

            //IEnumerator Run()
            //{
            //    foreach (var command in _mainCommands)
            //    {
            //        command.Execute();
            //        yield return new WaitForSeconds(.5f);
            //    }

            //    OnPLayEnds?.Invoke();
            //}

            Run();
        }

        public void Run()
        {
            if(_mainL >= _mainCommands.Count)
            {
                //main commands ends
                Debug.Log("Main commands end");
                _mainL = 0;
                return;
            }

            _mainCommands[_mainL].Execute();
            _mainL++;
            //StartCoroutine(Delay());

            //IEnumerator Delay()
            //{
            //    yield return new WaitForSeconds(.5f);
                Run();
            //}
        }

        public void RunProc()
        {
            if (_procL >= _procCommands.Count)
            {
                //proc commands ends
                Debug.Log("Proc commands end");
                _procL = 0;
                return;
            }

            _procCommands[_procL].Execute();
            _procL++;
            //StartCoroutine(Delay());

            //IEnumerator Delay()
            //{
            //    yield return new WaitForSeconds(.5f);
                RunProc();
            //}
        }

        public void RunProcCommands()
        {
            //StartCoroutine(Run());

            //IEnumerator Run()
            //{
            //    foreach (var command in _procCommands)
            //    {
            //        command.Execute();
            //        yield return new WaitForSeconds(.5f);
            //    }
            //}

            RunProc();
        }

        public void SetTargetCount(byte count)
        {
            CleanCommands();
            _targetCount = count;
        }

        public void ActiveList(byte id) => _listId = id;

        public void ActiveMainList() => _listId = 0;

        public void ActiveProc() => _listId = 1;

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
