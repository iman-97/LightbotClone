using Commands;
using UI;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField]
        private Transform _mainListHolder, _procListHolder;
        [SerializeField]
        private GameObject _nextLevelButton;

        public void PlayButton()
        {
            GameManager.Instance.RunMainCommands();
        }

        public void ResetButton()
        {

        }

        public void BackToLevelSelectButton() => LevelManager.Instance.LoadLevelSelect();

        public void NextLevelButton() => LevelManager.Instance.LoadNextLevel();

        public void AddVisualToMain(Command command, CommandListItem visual)
        {
            Instantiate(visual, _mainListHolder).Initialize(command);
        }

        public void AddVisualToProc(GameObject visual)
        {
            Instantiate(visual, _procListHolder);
        }

        public void ShowNextLevelButton() => _nextLevelButton.SetActive(true);

        public void HideNextLevelButton() => _nextLevelButton.SetActive(false);

    }
}