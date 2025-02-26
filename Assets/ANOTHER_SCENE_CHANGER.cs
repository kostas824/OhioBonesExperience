using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneAutoChange : MonoBehaviour
{
    [SerializeField] private int sceneIndex; // Scene to load
    [SerializeField] private float delayBeforeLoad = 5f; // Time before changing the scene

    private void Start()
    {
        StartCoroutine(ChangeSceneAfterDelay());
    }

    private IEnumerator ChangeSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoad);
        SceneManager.LoadScene(sceneIndex);
    }
}
