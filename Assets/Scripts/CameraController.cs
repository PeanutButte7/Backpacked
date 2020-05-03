using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followTransform;
    
    void FixedUpdate()
    {
        if (followTransform == null)
        {
            return;
        }
        
        transform.position = new Vector3(followTransform.position.x, followTransform.position.y, transform.position.z);
    }
}
