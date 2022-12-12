using UnityEngine;
using Utilities;

namespace Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField]
        private EventChannel _eventChannel;
        [SerializeField]
        private GameObject _nextLevelButton, _playButton, _rewindButton, _procPanel;

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

        public void PlayButton() => GameManager.Instance.RunMainCommands();

        public void ResetButton() => _eventChannel.ResetGame();

        public void RewindButton()
        {
            _eventChannel.RewindEvent();
            DefaultSetup();
        }

        public void BackToLevelSelectButton() => LevelManager.Instance.LoadLevelSelect();

        public void NextLevelButton()
        {
            DefaultSetup();
            LevelManager.Instance.LoadNextLevel();
        }

        public void ShowNextLevelButton() => _nextLevelButton.SetActive(true);

        public void HideNextLevelButton() => _nextLevelButton.SetActive(false);

        public void ShowProcedurePanel() => _procPanel.SetActive(true);

        public void HideProcedurePanel() => _procPanel.SetActive(false);

        private void OnPlayEnd() => _rewindButton.SetActive(true);

        private void OnPlayStart() => _playButton.SetActive(false);

        private void DefaultSetup()
        {
            HideNextLevelButton();
            _rewindButton.SetActive(false);
            _playButton.SetActive(true);
        }

    }
}