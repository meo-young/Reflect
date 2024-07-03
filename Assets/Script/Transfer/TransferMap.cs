using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransferMap : MonoBehaviour
{
    public Text text;   

    public Transform targetLocation; // �̵��� ��ǥ ��ġ
    private bool playerInRange = false; // �÷��̾ ��Ż ���� �ִ��� ����

    private AudioSource audioSource; // AudioSource ������Ʈ
    public AudioClip openDoorSound; // �湮 ���� ����
    public AudioClip closeDoorSound; // �湮 �ݴ� ����

    void Start()
    {
        text = GameObject.Find("Tag").GetComponent<Text>();
        if (text == null)
        {
            Debug.LogError("OpenText UI �ؽ�Ʈ�� ã�� �� �����ϴ�.");
            return;
        }
        text.enabled = false;

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
    
    private void ShowText()
    {
        text.enabled = true;
        text.transform.position = transform.position + new Vector3(0, 1, 0);
        if (CompareTag("OpenDoor"))
        {
            text.text = "����";
        }
        else if (CompareTag("CloseDoor"))
        {
            text.text = "�ݱ�";
        }
    }

    private void HideText()
    {
        text.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowText();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HideText();
            playerInRange = false;
        }
    }
}
