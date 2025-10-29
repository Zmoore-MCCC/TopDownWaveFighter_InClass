using UnityEngine;

//attached to player
//handles physics to move player up, down, left, and right
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //we will use update to get user input
    //update is called once per frame and is dependent on frame rate
    void Update()
    {
        //get input from the user
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        flipSprite(moveX);
        moveInput = new Vector2(moveX, moveY).normalized;
        moveVelocity = moveInput * moveSpeed;
    }

    //we will use fixedupdate to apply physics
    //fixedupdate is called a fixed number of times per second
    private void FixedUpdate()
    {
        //apply the physics to the player
        rb.linearVelocity = moveVelocity;
    }

    private void flipSprite(float moveX)
    {
        //I know moveX will be positive or negative
        //depending on if the player is moving left or right.
        if(moveX > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(moveX < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
