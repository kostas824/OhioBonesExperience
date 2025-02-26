using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SceneManagerL : MonoBehaviour
{
    public static SceneManagerL Instance;

    [SerializeField]
    private float minimumDelay = 1f; // Default value in case it's not assigned

    [SerializeField]
    private Scene homeScene;

    [SerializeField]
    private bool loadAdditive;
    [SerializeField]
    private bool loadAsync;

    [SerializeField]
    private UnityEvent SceneLoadStarted;

    [SerializeField]
    private UnityEvent SceneLoadFinished;

    [SerializeField]
    private UnityEvent<float> SceneLoadStartedE;

    [SerializeField]
    private UnityEvent AppQuitStarted;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [ContextMenu("ReloadScene")]
    public void ReloadScene()
    {
        ChangeScene(SceneManager.GetActiveScene().buildIndex);
    }

    [ContextMenu("ChangeSceneToHome")]
    public void ChangeSceneToHome()
    {
        ChangeScene(homeScene.buildIndex);
    }

    public void ChangeScene(int index)
    {
        if (loadAsync)
        {
            StartCoroutine(AsyncLoadWithMinWait(index));
        }
        else
        {
            SceneLoadStarted?.Invoke();
            SceneManager.LoadScene(index);
        }
    }

    private IEnumerator AsyncLoadWithMinWait(int index)
    {
        SceneLoadStarted?.Invoke();
        SceneLoadStartedE?.Invoke(minimumDelay);

        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(minimumDelay);

        AsyncOperation async = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        yield return new WaitUntil(() => async.isDone);

        Debug.Log("Scene loaded");
        SceneLoadFinished?.Invoke();
    }

    [ContextMenu("ApplicationQuit")]
    public void ApplicationQuit()
    {
        AppQuitStarted?.Invoke();
        StartCoroutine(WaitAndQuit());
    }

    private IEnumerator WaitAndQuit()
    {
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(minimumDelay);
        Application.Quit();

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
