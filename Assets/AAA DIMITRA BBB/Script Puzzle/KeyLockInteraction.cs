using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class KeyLockInteraction : MonoBehaviour
{
    public string correctKeyName; // Το σωστό όνομα του κλειδιού
    public AudioSource errorAudioSource; // Ήχος λάθους

    private XRSocketInteractor socketInteractor;

    private void Start()
    {
        socketInteractor = GetComponentInChildren<XRSocketInteractor>();

        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.AddListener(OnObjectPlacedInSocket);
        }
        else
        {
            Debug.LogError("[KeyLockInteraction] Δεν βρέθηκε το XRSocketInteractor!");
        }
    }

    private void OnObjectPlacedInSocket(SelectEnterEventArgs args)
    {
        GameObject placedObject = args.interactableObject.transform.gameObject;
        Debug.Log($"[KeyLockInteraction] Αντικείμενο που τοποθετήθηκε: {placedObject.name}");

        if (placedObject.name != correctKeyName)
        {
             errorAudioSource.Play();
            Debug.Log("[KeyLockInteraction] error, wrong key");
        }
    }

    private void OnDestroy()
    {
        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.RemoveListener(OnObjectPlacedInSocket);
        }
    }
}