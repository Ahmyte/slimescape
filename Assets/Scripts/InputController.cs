using UnityEngine;

public class InputController : MonoBehaviour
{
    
    PlayerMovement playerMovement;
    PlayerHide playerHide;

    void Start()
    {
        playerHide = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHide>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        playerMovement.horizontal = Input.GetAxisRaw("Horizontal");

        if (playerMovement.IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            playerMovement.jumpState = PlayerMovement.JumpState.shortJump;
            playerMovement.JumpingController();
        }

        if(Input.GetKey(KeyCode.Space) && playerMovement.isJumping)
        {
            playerMovement.jumpState = PlayerMovement.JumpState.longJump;
            playerMovement.JumpingController();
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            playerMovement.jumpState = PlayerMovement.JumpState.dontJump;
            playerMovement.JumpingController();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (playerHide.isHiding)
            {
                playerHide.isHiding = false;
                playerHide.gameObject.SetActive(true);

            }
            else if (playerHide.isCanHide)
            {
                playerHide.isHiding = true;
                playerHide.gameObject.SetActive(false);
            }
        }
    }
}
