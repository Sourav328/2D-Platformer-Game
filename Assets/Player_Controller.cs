using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;

    private void Awake()
    {
        Debug.Log("Player Controller Awake");
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool isCrouch = Input.GetKey(KeyCode.LeftControl);

        PlayMoveAnim(horizontal);
        PlayJumpAnim(vertical);
        PlayCrouchAnim(isCrouch);
    }

    public void PlayMoveAnim(float horizontal)
    {
        playerAnimator.SetFloat("horizontal", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;

        if (horizontal < 0)
        {
            scale.x = -Mathf.Abs(scale.x); // Face left
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x); // Face right
        }

        transform.localScale = scale;
    }

    public void PlayJumpAnim(float vertical)
    {
        bool isJumping = vertical > 0.01f;
        playerAnimator.SetBool("Jump", isJumping);
    }

    public void PlayCrouchAnim(bool isCrouch)
    {
        playerAnimator.SetBool("Crouch", isCrouch);
    }
}
