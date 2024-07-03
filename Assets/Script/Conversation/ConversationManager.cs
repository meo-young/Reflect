using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ConversationManager : MonoBehaviour
{
    public Canvas UI;
    public Text targetText;
    public string fullText = "��ī�� ���ָӴϴ� �� �輼�� ?\n �ư��� ��� ? ������ ?";
    public float delay = 0.1f; // �� ���� ������ ���� �ð�

    private bool conversationFlag = false;


    void Update()
    {
        if (conversationFlag)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                StartCoroutine(ActivateCanvas());
            }
        }
    }

    private IEnumerator ActivateCanvas()
    {
        targetText.text = ""; // �ؽ�Ʈ �ʱ�ȭ

        UI.gameObject.SetActive(true);
        foreach (char letter in fullText.ToCharArray())
        {
            targetText.text += letter;
            yield return new WaitForSeconds(delay); // ���� �ð� ���
        }
    }

    private void InactiveCanvas()
    {
        UI.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("conversation In");
            conversationFlag = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("conversation Out");
            InactiveCanvas();
            conversationFlag = false;
        }
    }
}
