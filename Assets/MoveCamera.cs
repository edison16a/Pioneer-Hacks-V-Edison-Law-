using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float height = 3.0f;
    public float damping = 100.0f;
    public bool smoothRotation = false;
    public bool followBehind = true;

    private void LateUpdate()
    {
        Vector3 wantedPosition;
        if (followBehind)
        {
            wantedPosition = target.TransformPoint(0, height, -distance);
        }
        else
        {
            wantedPosition = target.TransformPoint(0, height, distance);
        }
        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

        if (smoothRotation)
        {
            Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * damping);
        }
        else
        {
            transform.LookAt(target, target.up);
        }
    }
}