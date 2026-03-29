using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] 
    Transform target;

    Vector3 velocity = Vector3.zero;

    [SerializeField]
    float smooth = 0.2f;

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPos = target.position;
            newPos.z = transform.position.z;
            transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smooth);
        }
    }
}
