using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;

    public float followSpeed = 0.125f;
    public Vector3 offset;

    private void Start()
    {
        FindThePlayer();
    }
    private void LateUpdate()
    {
        if(!target)
        {
            FindThePlayer();
        }

        Vector3 desiredPosition = target.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(target.transform.position, desiredPosition, followSpeed);
        transform.position = smoothedPosition;
    }

    private void FindThePlayer()
    {
        target = GameObject.Find("Player(Clone)");
    }
}
