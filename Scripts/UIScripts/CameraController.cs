using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = target.position.x;
        temp.y = target.position.y;
        transform.position = temp;
    }
}
