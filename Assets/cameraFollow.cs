using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

void FixedUpdate()
{
    FollowTarget();
}

void FollowTarget()
{
    if (target == null)
    {
        Debug.LogWarning("CameraFollow: Target is not assigned!");
        return;
    }

    Vector3 desiredPosition = target.position + offset;
    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);
    transform.position = smoothedPosition;
}


    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public void SetOffset(Vector3 newOffset)
    {
        offset = newOffset;
    }

    public void SetSmoothSpeed(float newSmoothSpeed)
    {
        smoothSpeed = newSmoothSpeed;
    }
}
