using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using Utilities;

namespace Managers
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField]
        private AssetReference _levelSelectScene, _mainScene;
        [SerializeField]
        private GameObject _loading;

        private int _currentLevelIndex;
        private SceneInstance _currentLevel;

        private void Start() => LoadLevelSelect();

        public void LoadLevelSelect()
        {
            if (_mainScene.IsValid() == true)
            {
                _mainScene.UnLoadScene();
                Addressables.UnloadSceneAsync(_currentLevel);
            }

            _levelSelectScene.LoadSceneAsync(LoadSceneMode.Additive);
        }

        public void UnloadLevelSelect() => _levelSelectScene.UnLoadScene();

        public void LoadLevel(int level)
        {
            UnloadLevelSelect();

            _currentLevelIndex = level;
            _mainScene.LoadSceneAsync(LoadSceneMode.Additive);
            Addressables.LoadSceneAsync($"Level {_currentLevelIndex}", LoadSceneMode.Additive).Completed += obj =>
            {
                _currentLevel = obj.Result;
            };
        }

        public void LoadNextLevel()
        {
            _currentLevelIndex++;

            if (_currentLevelIndex == 10)
                _currentLevelIndex = 1;

            Addressables.UnloadSceneAsync(_currentLevel);
            Addressables.LoadSceneAsync($"Level {_currentLevelIndex}", LoadSceneMode.Additive).Completed += obj =>
            {
                _currentLevel = obj.Result;
            };
        }

    }
}