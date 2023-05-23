using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_mov : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float moveSpeed;
    public float jumpForce;
    private bool isjumping;
    private InputManager inputManager;
    private Animator animator;

    private bool FacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        isjumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        //moveHorizontal = inputManager.horizontalMoveAxis;
        //moveVertical = inputManager.verticalMoveAxis;
        

        SetupInput();

        
    }

    private void FixedUpdate()
    {
        jump();
        if (inputManager.horizontalMoveAxis > 0.1f || inputManager.horizontalMoveAxis < -0.1f)
        {
            //rb2d.AddForce(new Vector2(inputManager.horizontalMoveAxis * moveSpeed, 0f), ForceMode2D.Impulse);
            rb2d.velocity = new Vector2(inputManager.horizontalMoveAxis * moveSpeed, 0f);
        }
        //if (!isjumping && inputManager.verticalMoveAxis > 0.1f)
        //{
        //    rb2d.AddForce(new Vector2(0f, inputManager.verticalMoveAxis * jumpForce), ForceMode2D.Impulse);
        //    rb2d.velocity = new Vector2(0f, inputManager.verticalMoveAxis * jumpForce);
        //}


        if (inputManager.horizontalMoveAxis > 0 && !FacingRight)
        {
            Flip();
        }
        else if (inputManager.horizontalMoveAxis < 0 && FacingRight)
        {
            Flip();
        }

        animator.SetBool("run", inputManager.horizontalMoveAxis != 0);

        //if(inputManager.horizontalMoveAxis > 0)
        //{
        //    gameObject.transform.localScale = new Vector3(1, 1, 1);
        //}
        //else if (inputManager.horizontalMoveAxis < 0)
        //{
        //    gameObject.transform.localScale = new Vector3(-1, 1, 1);
        //}
    }
    private void SetupInput()
    {
        if (inputManager == null)
        {
            inputManager = InputManager.instance;
        }
        if (inputManager == null)
        {
            Debug.LogWarning("There is no player input manager in the scene, there needs to be one for the Controller to work");
        }
    }

    void jump()
    {
        if(!isjumping && inputManager.verticalMoveAxis > 0.1f)
        {
            rb2d.AddForce(new Vector2(0f, inputManager.verticalMoveAxis * jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isjumping = false;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isjumping = true;
        }
    }

    void Flip()
    {
        //Vector3 currentScale = gameObject.transform.localScale;
        //currentScale.x *= -1;
        //gameObject.transform.localScale = currentScale;
        transform.Rotate(0f, 180f, 0f);

        FacingRight = !FacingRight;
    }

    

    public bool canAttack()
    {
        return inputManager.horizontalMoveAxis == 0 && isjumping;
    }

}
