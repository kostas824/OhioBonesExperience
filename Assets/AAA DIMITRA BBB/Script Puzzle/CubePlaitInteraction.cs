using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class CubePlaitInteraction : MonoBehaviour
{
    public string correctCubeName; // Το σωστό όνομα του κύβου
    public AudioSource correctAudioSource; // Ήχος επιτυχίας
    public AudioSource errorAudioSource; // Ήχος λάθους
    public GameObject objectToShow;
    public AudioSource VentingMachine; // Αντικείμενο που θα εμφανιστεί

    private XRSocketInteractor socketInteractor;
    private static int correctCubesPlaced = 0; // Μετρητής για τους σωστούς κύβους

    private void Start()
    {
        socketInteractor = GetComponentInChildren<XRSocketInteractor>();

        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.AddListener(OnObjectPlacedInSocket);
        }
        else
        {
            Debug.LogError("[CubePlaitInteraction] Δεν βρέθηκε το XRSocketInteractor!");
        }

        // Αρχικά κρύβουμε το αντικείμενο που πρέπει να εμφανιστεί
        if (objectToShow != null)
        {
            objectToShow.SetActive(false);
        }
    }

    private void OnObjectPlacedInSocket(SelectEnterEventArgs args)
    {
        GameObject placedObject = args.interactableObject.transform.gameObject;
        Debug.Log($"[CubePlaitInteraction] Αντικείμενο που τοποθετήθηκε: {placedObject.name}");

        // Ελέγχουμε αν ο τοποθετημένος κύβος είναι ο σωστός
        if (placedObject.name == correctCubeName)
        {
            if (correctAudioSource != null) correctAudioSource.Play();
            Debug.Log($"[CubePlaitInteraction] Σωστός κύβος: {correctCubeName}");
            correctCubesPlaced++;

            // Ελέγχουμε αν όλοι οι σωστοί κύβοι τοποθετήθηκαν
            if (correctCubesPlaced == 4)
            {
                ShowObject(); // Εμφανίζουμε το αντικείμενο
            }
        }
        else
        {
            if (errorAudioSource != null) errorAudioSource.Play();
            Debug.Log("[CubePlaitInteraction] Λάθος κύβος");
        }
    }

    private void ShowObject()
    {
        // Εμφανίζουμε το αντικείμενο
        if (objectToShow != null)
        {
            VentingMachine.Play();
            objectToShow.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        if (socketInteractor != null)
        {
            VentingMachine.Play();
            socketInteractor.selectEntered.RemoveListener(OnObjectPlacedInSocket);
        }
    }
}



