using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferMap : MonoBehaviour
{
    public Transform targetLocation; // 이동할 목표 위치
    private bool playerInRange = false; // 플레이어가 포탈 위에 있는지 여부

    private AudioSource audioSource; // AudioSource 컴포넌트
    public AudioClip openDoorSound; // 방문 여는 사운드
    public AudioClip closeDoorSound; // 방문 닫는 사운드

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
            // 플레이어를 목표 위치로 이동
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = targetLocation.position;
                PlayOpenDoorSound(); // 방문 사운드 재생
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
                Debug.Log("음원 파일이 존재하지 않거나, 잘못된 태그로 설정되었습니다.");
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
