using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private BoxCollider2D boxCol;



    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;
    private void Start()
    {
        boxColInitSize = boxCol.size;
        boxColInitOffset = boxCol.offset;
    }
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
        bool isJump = vertical > 0.001f; // Declare and assign before using
        playerAnimator.SetBool("Jump", isJump);

        if (vertical > 0.001f)
        {
            playerAnimator.SetBool("Jump", true);
        }
        else
        {
            playerAnimator.SetBool("Jump", false);
        }
    }

    public void PlayCrouchAnim(bool isCrouch)
    {
        if (isCrouch == true)
        {
            float offX = -0.0978f;     //Offset X
            float offY = 0.5947f;      //Offset Y

            float sizeX = 0.6988f;     //Size X
            float sizeY = 1.3398f;     //Size Y

            boxCol.size = new Vector2(sizeX, sizeY);   //Setting the size of collider
            boxCol.offset = new Vector2(offX, offY);   //Setting the offset of collider
        }

        else
        {
            //Reset collider to initial values
            boxCol.size = boxColInitSize;
            boxCol.offset = boxColInitOffset;
        }

       
    
        playerAnimator.SetBool("Crouch", isCrouch);

    }
}
