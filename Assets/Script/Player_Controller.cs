using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private BoxCollider2D boxCol;
    [SerializeField] private Rigidbody2D rig2D;

    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;
    [SerializeField] public float Speed;
    [SerializeField] public float Jump;
    //grounded features

    private bool isGrounded = true;
    

    //layer mask for the ground
    //box offset
    //box size  

    [Header("Ground Check Settings")]
    [SerializeField] private LayerMask groundLayer;

    [Header("Scale The Ground Collider")]
    [SerializeField] private Vector2 boxSize = new Vector2(0.6f, 0.1f);
    [SerializeField] private Vector2 boxOffset = new Vector2(0f, -1.1f);
    
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
        float vertical = Input.GetAxisRaw("Jump");
        bool isCrouch = Input.GetKey(KeyCode.LeftControl);

        
        PlayMoveAnim(horizontal, vertical);
        CracterMove(horizontal, vertical);

        //PlayJumpAnim(vertical);

        PlayCrouchAnim(isCrouch);
    }

    //FixedUpdate(){isGrounded = Physics2D.OverlapBox();}
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapBox((Vector2)transform.position + boxOffset, boxSize, 0f, groundLayer);
    }
    public void CracterMove(float horizontal, float vertical)
    {
        Vector2 position = transform.position;
        position.x += horizontal * Speed * Time.deltaTime;
        transform.position = position;  

        if (vertical > 0 && isGrounded)
        {
            rig2D.AddForce(new Vector2(0f, Jump),ForceMode2D.Force);
        }
    }
    public void PlayMoveAnim(float horizontal, float vertical)
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


        //move this thing into the coroutine
        //in here call the StartCoroutine(JumpCoroutine());
        public void PlayJumpAnim(float vertical)
        {
           if (vertical > 0f && isGrounded)
           {
               StartCoroutine(JumpCoroutine()); 
           }
        }

        private System.Collections.IEnumerator JumpCoroutine()
        {
            playerAnimator.SetBool("Jump", true);
            yield return new WaitForSeconds(0.01f); 
            playerAnimator.SetBool("Jump", false);
    }

    public void PlayCrouchAnim(bool isCrouch)
    {
        if (isCrouch == true)
        {
            float offX = -0.0978f;
            float offY = 0.5947f;

            float sizeX = 0.6988f;
            float sizeY = 1.3398f;

            boxCol.size = new Vector2(sizeX, sizeY);
            boxCol.offset = new Vector2(offX, offY);

        }
        else
        {
            //Reset collider to initial values
            boxCol.size = boxColInitSize;
            boxCol.offset = boxColInitOffset;
        }

       
    
        playerAnimator.SetBool("Crouch", isCrouch);

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube((Vector2)transform.position + boxOffset, boxSize);
    }
    
}
