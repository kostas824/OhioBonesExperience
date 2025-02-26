using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class BatterySocket : MonoBehaviour
{
    public AudioSource electricSound; // � ���� ����������� ��� �������� ��� Battery Holder
    public ParticleSystem electricSparks; // �� Particle System ��� ���� ���������
    private XRSocketInteractor socketInteractor; // �� XR Socket Interactor

    // ��� AudioSource ��� �� ��������� GameObject �� ����������� ���
    public AudioSource externalElectricSound; // � ���� ��� �� ������ ��� ��������� GameObject

    public float delayBeforeExternalSound = 1f; // ����������� ���� �������� � ���� ��� externalElectricSound

    void Start()
    {
        // ��������� �� XRSocketInteractor ��� ������������
        socketInteractor = GetComponent<XRSocketInteractor>();
        socketInteractor.selectEntered.AddListener(OnBatteryInserted); // �������� Listener ��� ��� �������� ��� ���������
    }

    // ������� ��� �������� ���� � �������� ������� ��� ����
    private void OnBatteryInserted(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag("Battery")) // ��������� �� �� ����������� ����� ��������
        {
            // ������ ��� ��� ��� ����������� ��� Battery Holder
            electricSound.Play();

            // ������ �� Particle System ��� ���� ���������
            electricSparks.Play();

            // ������ ��� ��� ��� externalElectricSound ���� ��� ��� �����������
            if (externalElectricSound != null)
            {
                Invoke("PlayExternalElectricSound", delayBeforeExternalSound);
            }

            // ��������� �� Particle System ���� ��� 5 ������������
            Invoke("StopParticles", 5f); // �� �� ���������� ���� ��� 5 ������������
        }
    }

    // ������� ��� �� ������ � ���� ��� externalElectricSound �� �����������
    private void PlayExternalElectricSound()
    {
        externalElectricSound.Play();
    }

    // ������� ��� �� ���������� �� Particle System ���� ��� 5 ������������
    void StopParticles()
    {
        electricSparks.Stop(); // ��������� �� Particle System
    }
}








