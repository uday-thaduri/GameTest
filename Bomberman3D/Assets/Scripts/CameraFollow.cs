using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;

    Vector3 camOffset;
    [Range(0.01f,1.0f)]
    public float smoothingValue=0.5f;
    // Start is called before the first frame update
    void Start()
    {
        camOffset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = camOffset + playerTransform.position;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothingValue);
    }
}
