using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    static public CameraManager instance;

    public GameObject target;
    public float moveSpeed;
    private Vector3 targetPosition;

    public BoxCollider2D currentBound;

    private Vector3 minBound;
    private Vector3 maxBound;

    private float halfWidth;
    private float halfHeight;

    private Camera theCamera;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        theCamera = GetComponent<Camera>();
        minBound = currentBound.bounds.min;
        maxBound = currentBound.bounds.max;
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            UpdateCurrentBound();
            UpdateCameraPosition();
        }
    }

    private void UpdateCurrentBound()
    {
        Collider2D[] colliders = Physics2D.OverlapPointAll(target.transform.position);
        foreach (var collider in colliders)
        {
            if (collider is BoxCollider2D && collider.CompareTag("Camera"))
            {
                SetBound(collider as BoxCollider2D);
                break;
            }
        }
    }

    private void UpdateCameraPosition()
    {
        if (currentBound != null)
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);

            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);

            float clampedX = Mathf.Clamp(this.transform.position.x, minBound.x + halfWidth, maxBound.x - halfWidth);
            float clampedY = Mathf.Clamp(this.transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);

            this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z);
        }
    }

    public void SetBound(BoxCollider2D newBound)
    {
        currentBound = newBound;
        minBound = currentBound.bounds.min;
        maxBound = currentBound.bounds.max;
    }
}
