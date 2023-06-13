using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Infrastructure
{
    public abstract class EntryPoint<TInstaller, TAssets> : MonoBehaviour where TInstaller : Object, IInstaller<TAssets>
    {
        [SerializeField] private TAssets _assets;
        [SerializeField] private string _appSceneName;
    
        private void Awake()
        {
            var mono = new GameObject(nameof(MonoCached), typeof(MonoCached));
        
            DontDestroyOnLoad(mono);

            MonoCached.StartCustomCoroutine(LoadScene());
        }
    
        private IEnumerator LoadScene()
        {
            yield return SceneManager.LoadSceneAsync(_appSceneName);

            var gameInstaller = FindObjectOfType<TInstaller>();
        
            gameInstaller.Install(_assets);
        }
    }
}