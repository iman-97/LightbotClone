using Commands;
using UI;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField]
        private EventChannel _eventChannel;
        [SerializeField]
        private Transform _mainListHolder, _procListHolder;
        [SerializeField]
        private GameObject _nextLevelButton;

        private void Start() => _eventChannel.OnReset += CleanUp;

        private void OnDestroy() => _eventChannel.OnReset -= CleanUp;

        public void PlayButton() => GameManager.Instance.RunMainCommands();

        public void ResetButton() => _eventChannel.OnResetGame();

        public void BackToLevelSelectButton() => LevelManager.Instance.LoadLevelSelect();

        public void NextLevelButton()
        {
            HideNextLevelButton();
            CleanUp();
            LevelManager.Instance.LoadNextLevel();
        }

        public void AddVisualToMain(Command command, CommandListItem visual)
        {
            Instantiate(visual, _mainListHolder).Initialize(command);
        }

        public void AddVisualToProc(Command command, CommandListItem visual)
        {
            Instantiate(visual, _procListHolder).Initialize(command);
        }

        public void ShowNextLevelButton() => _nextLevelButton.SetActive(true);

        public void HideNextLevelButton() => _nextLevelButton.SetActive(false);

        private void CleanUp()
        {
            for (int i = 0; i < _mainListHolder.childCount; i++)
            {
                Destroy(_mainListHolder.GetChild(i).gameObject);
            }

            for (int i = 0; i < _procListHolder.childCount; i++)
            {
                Destroy(_procListHolder.GetChild(i).gameObject);
            }
        }

    }
}