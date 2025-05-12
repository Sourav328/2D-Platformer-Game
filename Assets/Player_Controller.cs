using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Animator animator;
   
    

    private void Awake()
    {
        Debug.Log("Player Controller Awake");
    }

    void Start()
    {
       
    }

    void Update()
    {
        // Horizontal Movement & Animation
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));

        // Jumping
        float jump = Input.GetAxisRaw("Vertical");
        animator.SetBool("Jump", jump > 0);

        // Player flipping based on direction
        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }

        // Crouching
        bool isCrouching = Input.GetKey(KeyCode.LeftControl);
        animator.SetBool("isCrouching", isCrouching);
     
    }
}
