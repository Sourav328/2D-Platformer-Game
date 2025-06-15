using System;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private BoxCollider2D boxCol;
    [SerializeField] private Rigidbody2D rig2D;
    [SerializeField] private Score_Controller scoreController;

    [Header("Movement Settings")]
    [SerializeField] public float speed;
    [SerializeField] public float jump;
    [SerializeField] public float doubleJump;

    [Header("Ground Check Settings")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector2 boxSize = new Vector2(0.6f, 0.1f);
    [SerializeField] private Vector2 boxOffset = new Vector2(0f, -1.1f);

    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;

    private bool isGrounded = false;
    private bool canDoubleJump = false;
    private bool hasDoubleJumpPower = true; 

    private void Start()
    {
        boxColInitSize = boxCol.size;
        boxColInitOffset = boxCol.offset;
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        bool isCrouch = Input.GetKey(KeyCode.LeftControl);

        PlayerMoveAnim(horizontal);
        PlayerJumpAnim();
        CracterMove(horizontal);
        HandleJump(); 
        PlayCrouchAnim(isCrouch);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox((Vector2)transform.position + boxOffset, boxSize, 0f, groundLayer);

        if (isGrounded)
        {
            canDoubleJump = true; // ✅ Reset only when grounded
        }
    }

    public void CracterMove(float horizontal)
    {
        Vector2 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rig2D.velocity = new Vector2(rig2D.velocity.x, 0f);
                rig2D.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
                canDoubleJump = true;
            }
            else if (hasDoubleJumpPower && canDoubleJump)
            {
                rig2D.velocity = new Vector2(rig2D.velocity.x, 0f);
                rig2D.AddForce(Vector2.up * doubleJump, ForceMode2D.Impulse);
                canDoubleJump = false; 
            }
        }
    }

    public void PlayerMoveAnim(float horizontal)
    {
        playerAnimator.SetFloat("horizontal", Mathf.Abs(horizontal));

        Vector2 scale = transform.localScale;

        if (horizontal < 0)
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }

    public void PlayerJumpAnim()
    {
        playerAnimator.SetBool("Jump", !isGrounded);
    }

    public void PlayCrouchAnim(bool isCrouch)
    {
        if (isCrouch)
        {
            boxCol.size = new Vector2(0.6988f, 1.3398f);
            boxCol.offset = new Vector2(-0.0978f, 0.5947f);
        }
        else
        {
            boxCol.size = boxColInitSize;
            boxCol.offset = boxColInitOffset;
        }

        playerAnimator.SetBool("Crouch", isCrouch);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube((Vector2)transform.position + boxOffset, boxSize);
    }

    public void PickUpKey()
    {
        scoreController.UpdateScore(10);
    }

    public Rigidbody2D GetRigBody() { return rig2D; }
}
