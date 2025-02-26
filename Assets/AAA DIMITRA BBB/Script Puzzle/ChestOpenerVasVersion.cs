using UnityEngine;
using UnityEngine.Events;

public class ChestOpener2 : MonoBehaviour
{
    
    public Animator chestAnimator;  
    public AudioSource chestOpenAudio;  
    private int KeyCount;

    private void Start()
    {
        KeyCount = 0; 
    }

    public void OnKeyPlaced()
    {
        KeyCount++;  

        if (KeyCount == 3)
        {
            OpenChest2();
        }
    }

    public void OnKeyRemoved()
    {
        KeyCount--;
    }

    private void OpenChest2()
    {
        if (chestOpenAudio != null)
        {
            chestOpenAudio.Play();
        }

        chestAnimator.SetTrigger("OpenChestTrigger");
        onPuzzleCompletion.Invoke(); 
    }

    [Header("Completion Events")] 
    public UnityEvent onPuzzleCompletion; 

}






























































