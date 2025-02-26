using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerAnimationOnButtonPress : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable button;  // Assign the button
    public Animator animator;         // Assign the Animator component
    public string animationTriggerName = "PlayAnimation"; // Animation trigger name

    private void Start()
    {
        if (button != null)
        {
            button.activated.AddListener(OnButtonPressed);
        }
    }

    private void OnButtonPressed(ActivateEventArgs args)
    {
        if (animator != null)
        {
            animator.SetTrigger("PlayAnimation");
        }
    }

    private void OnDestroy()
    {
        if (button != null)
        {
            button.activated.RemoveListener(OnButtonPressed);
        }
    }
}