using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class CubePlaitInteraction : MonoBehaviour
{
    public string correctCubeName; // �� ����� ����� ��� �����
    public AudioSource correctAudioSource; // ���� ���������
    public AudioSource errorAudioSource; // ���� ������
    public GameObject objectToShow;
    public AudioSource VentingMachine; // ����������� ��� �� ����������

    private XRSocketInteractor socketInteractor;
    private static int correctCubesPlaced = 0; // �������� ��� ���� ������� ������

    private void Start()
    {
        socketInteractor = GetComponentInChildren<XRSocketInteractor>();

        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.AddListener(OnObjectPlacedInSocket);
        }
        else
        {
            Debug.LogError("[CubePlaitInteraction] ��� ������� �� XRSocketInteractor!");
        }

        // ������ �������� �� ����������� ��� ������ �� ����������
        if (objectToShow != null)
        {
            objectToShow.SetActive(false);
        }
    }

    private void OnObjectPlacedInSocket(SelectEnterEventArgs args)
    {
        GameObject placedObject = args.interactableObject.transform.gameObject;
        Debug.Log($"[CubePlaitInteraction] ����������� ��� ������������: {placedObject.name}");

        // ��������� �� � ������������� ����� ����� � ������
        if (placedObject.name == correctCubeName)
        {
            if (correctAudioSource != null) correctAudioSource.Play();
            Debug.Log($"[CubePlaitInteraction] ������ �����: {correctCubeName}");
            correctCubesPlaced++;

            // ��������� �� ���� �� ������ ����� �������������
            if (correctCubesPlaced == 4)
            {
                ShowObject(); // ����������� �� �����������
            }
        }
        else
        {
            if (errorAudioSource != null) errorAudioSource.Play();
            Debug.Log("[CubePlaitInteraction] ����� �����");
        }
    }

    private void ShowObject()
    {
        // ����������� �� �����������
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



