using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public enum JumpState
    {
        shortJump,
        longJump,
        dontJump
    }

    Rigidbody2D rb;
    Animator animator;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask platformLayerMask;
    [SerializeField] float jumpTime;
    [SerializeField] CameraMovement cam;

    [HideInInspector] public float horizontal;
    [HideInInspector] public bool isJumping;
    [HideInInspector] public float jumpTimeCounter;
    [HideInInspector] public JumpState jumpState;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (rb.velocity.y < 0)
        {
            animator.SetBool("isJump", false);
        }
    }

    void FixedUpdate()
    {
        if (horizontal != 0)
        {
            Walk();
        }
        else
        {
            animator.SetBool("isWalk", false);
        }
    }

    private void Walk()
    {
        rb.position += Vector2.right * horizontal * speed * Time.deltaTime;
        transform.localScale = new Vector3(horizontal, 1, 1);
        animator.SetBool("isWalk", true); 
    }

    public void JumpingController()
    {
        if(jumpState == JumpState.shortJump)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            Jump();
        }
        if(jumpState == JumpState.longJump)
        {
            if(jumpTimeCounter > 0)
            {
                Jump();
                jumpTimeCounter -= Time.deltaTime;
            }
            else    
                isJumping = false;           
        }
        if(jumpState == JumpState.dontJump)
            isJumping = false;       
    }

    public void Jump()
    {
        rb.velocity = jumpForce * Vector2.up;
        animator.SetBool("isJump", true);
    }

    public bool IsGrounded()
    {
        Collider2D coll = Physics2D.OverlapCircle(transform.position + Vector3.down * 0.25f, 0.08f, platformLayerMask);

        //yerdeyse
        if (coll != null)
        {
            animator.SetBool("isGround", true);
            return true;
        }
        else
        {
            animator.SetBool("isGround", false);
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + Vector3.down * 0.25f, 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("CamUp"))
        {
            cam.targetSpeedFactor = 3f;
        }
        else if(collision.CompareTag("CamDown"))
        {
            cam.targetSpeedFactor = 0.5f;
        }
        else if(collision.CompareTag("CamBorder"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
