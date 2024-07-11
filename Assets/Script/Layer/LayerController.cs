using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    private SpriteRenderer targetRenderer; // Ÿ�� ������Ʈ�� SpriteRenderer
    private SpriteRenderer playerRenderer; // �÷��̾� ������Ʈ�� SpriteRenderer
    private Animator playerAnim; // �÷��̾� ������Ʈ�� Rigidbody2D
    private GameObject player;

    void Start()
    {
        // Ÿ�� ������Ʈ�� SpriteRenderer ������Ʈ�� �����ɴϴ�.
        targetRenderer = GetComponent<SpriteRenderer>();

        // "Player" �±׸� ���� ������Ʈ�� SpriteRenderer�� Rigidbody2D ������Ʈ�� �����ɴϴ�.
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerRenderer = player.GetComponent<SpriteRenderer>();
            playerAnim = player.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("Player ������Ʈ�� ã�� �� �����ϴ�. 'Player' �±׸� Ȯ���ϼ���.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (playerRenderer == null || playerAnim == null) return;

        if (other.CompareTag("Player"))
        {
            //Debug.Log("�ٿ�� ����");
            //Debug.Log(playerAnim.GetFloat("DirY"));
            // �÷��̾��� �̵� ������ �Ʒ������� �������� Ȯ���մϴ�.
            if (playerAnim.GetFloat("DirY") < 0)
            {
                //�÷��̾ �Ʒ� �������� �̵� ���̸�
                //Debug.Log("�Ʒ� ����");
                targetRenderer.sortingOrder = playerRenderer.sortingOrder - 1;
            }
            else if (playerAnim.GetFloat("DirY") > 0)
            {
                //�÷��̾ �� �������� �̵� ���̸�
                //Debug.Log("�� ����");
                targetRenderer.sortingOrder = playerRenderer.sortingOrder + 1;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (playerRenderer == null || playerAnim == null) return;

        if (other.CompareTag("Player"))
        {
            //Debug.Log("�ٿ�� �ƿ�");
            //Debug.Log(playerAnim.GetFloat("DirY"));
            // �÷��̾��� �̵� ������ �Ʒ������� �������� Ȯ���մϴ�.
            if (playerAnim.GetFloat("DirY") < 0)
            {
                //�÷��̾ �Ʒ� �������� �̵� ���̸�
                //Debug.Log("�Ʒ� ����");
                targetRenderer.sortingOrder = playerRenderer.sortingOrder - 1;
            }
            else if (playerAnim.GetFloat("DirY") > 0)
            {
                //�÷��̾ �� �������� �̵� ���̸�
                //Debug.Log("�� ����");
                targetRenderer.sortingOrder = playerRenderer.sortingOrder + 1;
            }
        }
    }
}
