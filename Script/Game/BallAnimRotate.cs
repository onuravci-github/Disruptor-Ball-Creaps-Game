using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAnimRotate : MonoBehaviour
{
    Mouse mouse;
    Animator animator;

    Vector3 vectorZero = new Vector3(0f,0f,0f);
    Vector3 vectorScale = new Vector3(0.8f,0.8f,1f);
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        mouse = this.GetComponentInParent<Mouse>();
        //animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(mouse.speed != 0) {
            animator.enabled = true;
            this.transform.localScale = vectorScale;
        }
        else {
            //animator.enabled = false;
            this.transform.localScale = vectorZero;
        }

        this.transform.rotation = Quaternion.Euler(0f, 0f, 180 + Mathf.Atan2(mouse.rigidBody.velocity.y,mouse.rigidBody.velocity.x)*180/Mathf.PI);
    }
}