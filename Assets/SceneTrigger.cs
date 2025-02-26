using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.Collections;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private int sceneIndex; // Scene index to load
    [SerializeField] private VideoPlayer videoPlayer; // Reference to VideoPlayer
    [SerializeField] private float delayBeforeLoad = 0f; // Optional delay after video

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the Player enters the trigger
        {
            if (videoPlayer != null)
            {
                StartCoroutine(WaitForVideoAndLoadScene());
            }
            else
            {
                StartCoroutine(LoadSceneWithDelay());
            }
        }
    }

    private IEnumerator WaitForVideoAndLoadScene()
    {
        videoPlayer.Play(); // Start the video
        while (videoPlayer.isPlaying)
        {
            Debug.Log("Video is still playing...");
            yield return null; // Wait one frame
        }

        yield return new WaitForSeconds(delayBeforeLoad); // Optional extra delay
        LoadScene();
    }

    private IEnumerator LoadSceneWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoad);
        LoadScene();
    }

    private void LoadScene()
    {
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogWarning("Invalid scene index set in the Inspector!");
        }
    }
}
