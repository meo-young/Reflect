using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferMap : MonoBehaviour
{
    public Transform targetLocation; // �̵��� ��ǥ ��ġ
    private bool playerInRange = false; // �÷��̾ ��Ż ���� �ִ��� ����

    private AudioSource audioSource; // AudioSource ������Ʈ
    public AudioClip openDoorSound; // �湮 ���� ����
    public AudioClip closeDoorSound; // �湮 �ݴ� ����

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Z))
        {
            // �÷��̾ ��ǥ ��ġ�� �̵�
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = targetLocation.position;
                PlayOpenDoorSound(); // �湮 ���� ���
            }
        }
    }

    private void PlayOpenDoorSound()
    {
        if (audioSource != null)
        {
            if (CompareTag("OpenDoor") && openDoorSound != null)
            {
                audioSource.clip = openDoorSound;
                audioSource.Play();
            }
            else if (CompareTag("CloseDoor") && closeDoorSound != null)
            {
                audioSource.clip = closeDoorSound;
                audioSource.Play();
            }
            else
            {
                Debug.Log("���� ������ �������� �ʰų�, �߸��� �±׷� �����Ǿ����ϴ�.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("InPortal");
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
