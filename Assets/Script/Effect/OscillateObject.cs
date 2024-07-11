using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillateObject : MonoBehaviour
{
    public GameObject targetObject; // ��ȣ�ۿ��� ������Ʈ

    private bool interactFlag = false;

    public float shakeDuration = 0.5f; // ��鸲 ���� �ð�
    public float shakeMagnitude = 0.1f; // ��鸲 ����

    public float moveDistance = 0.1f; // �̵� �Ÿ�
    public float moveDuration = 0.1f; // �̵� �ð�

    void Update()
    {
        if (interactFlag)
        {
            // E Ű �Է� ����
            if (Input.GetKeyDown(KeyCode.E) && targetObject != null)
            {
                MoveLeftRight();
            }
        }
    }

    // Ʈ���� ������ ���� ��
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactFlag = true;
        }
    }

    // Ʈ���� �������� ������ ��
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactFlag = false;
        }
    }

    public void MoveLeftRight()
    {
        StartCoroutine(MoveLeftRightCoroutine());
    }

    private IEnumerator MoveLeftRightCoroutine()
    {
        Vector3 originalPosition = targetObject.transform.localPosition;

        // �·� �̵�
        Vector3 leftPosition = new Vector3(originalPosition.x - moveDistance, originalPosition.y, originalPosition.z);
        yield return MoveToPosition(leftPosition);

        // ��� �̵�
        Vector3 rightPosition = new Vector3(originalPosition.x + moveDistance, originalPosition.y, originalPosition.z);
        yield return MoveToPosition(rightPosition);

        // ���� ��ġ�� ����
        yield return MoveToPosition(originalPosition);
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        float elapsedTime = 0;
        Vector3 startingPosition = targetObject.transform.localPosition;

        while (elapsedTime < moveDuration)
        {
            targetObject.transform.localPosition = Vector3.Lerp(startingPosition, targetPosition, (elapsedTime / moveDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        targetObject.transform.localPosition = targetPosition;
    }
}
