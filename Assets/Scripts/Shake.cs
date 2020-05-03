using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Animator animator;
    
    public void CameraShake()
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            animator.SetTrigger("shake1");   
        } else if (rand == 1)
        {
            animator.SetTrigger("shake2");
        }
    }
}
