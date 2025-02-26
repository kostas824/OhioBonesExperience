using UnityEngine;

public class ChestOpener : MonoBehaviour
{
    public KeyLockInteraction[] keyLockScripts;  // �� ����������
    public Animator chestAnimator;  // � Animator ��� Chest
    public AudioSource chestOpenAudio;  // ���� ����������
    private int correctKeyCount = 0;

    private void Start()
    {
        correctKeyCount = 0; // Reset ���� ��� ������
    }

    public void OnCorrectKeyPlaced()
    {
        correctKeyCount++;  // ��������� �� �������

        Debug.Log($"[ChestOpener] ������� ��� ���� ����: {correctKeyCount}/{keyLockScripts.Length}");

        if (correctKeyCount == keyLockScripts.Length)
        {
            OpenChest();
        }
    }

    private void OpenChest()
    {
        if (chestOpenAudio != null)
        {
            chestOpenAudio.Play();
        }

        Debug.Log("[ChestOpener] ������� ����������!");
        chestAnimator.SetTrigger("OpenChestTrigger");
    }
}