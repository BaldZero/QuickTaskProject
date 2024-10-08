using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 10f;
    private float flip = -1;
    public float jump = 10;

    public Rigidbody2D playerRb;
    public BoxCollider2D playerCollider;
    
    private bool isFacingRight;
    private bool isOnGround;

    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        isFacingRight = true;
        isOnGround = true;
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        playerRb.velocity = new Vector2(horizontalInput * speed, 0);

        if(horizontalInput > 0 && !isFacingRight)
        {
            Flip();
            
        }

        if (horizontalInput < 0 && isFacingRight)
        {
            Flip(); 
        }

        if (Input.GetKey(KeyCode.Space) && isOnGround )
        {
           
            playerRb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        } 
    }



    private void Flip()
    {
        Vector3 localScale = gameObject.transform.localScale;
        localScale.x *= flip;
        gameObject.transform.localScale = localScale;
        isFacingRight = !isFacingRight; 

    }
     


}
