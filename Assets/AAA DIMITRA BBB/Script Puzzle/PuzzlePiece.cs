using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private PuzzleManager linkedPuzzleManager;
    [SerializeField] private Transform CorrectPuzzlePiece;
    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;

    
    private void Awake() => socket = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();
    private void OnEnable()
    {
        socket.selectEntered.AddListener(ObjectSnapped);
        socket.selectExited.AddListener(ObjectRemoved);
    }
    private void OnDisable()
    {
        socket.selectEntered.AddListener(ObjectSnapped);
        socket.selectExited.AddListener(ObjectRemoved);
    }

    private void ObjectSnapped(SelectEnterEventArgs arg0)
    {
        var snappedObjectname = arg0.interactableObject;
        if(snappedObjectname.transform.name == CorrectPuzzlePiece.name)
        {
            linkedPuzzleManager.CompletedPuzzleTask();
        }
    }
    private void ObjectRemoved(SelectExitEventArgs arg0)
    {
        var removedObjectname = arg0.interactableObject;
        if (removedObjectname.transform.name == CorrectPuzzlePiece.name)
        {
            linkedPuzzleManager.PuzzlePieceRemoved();
        }
    }
}