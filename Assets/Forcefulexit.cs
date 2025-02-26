using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneAutoExit : MonoBehaviour
{
    [SerializeField] private float delayBeforeLoad = 5f; // Time before changing the scene

    private void Start()
    {
        StartCoroutine(ChangeSceneAfterDelay());
    }

    private IEnumerator ChangeSceneAfterDelay()
    {
        print("START COUNTING");
        yield return new WaitForSeconds(delayBeforeLoad);
        print("exit");
        Application.Quit();
   

}
}
