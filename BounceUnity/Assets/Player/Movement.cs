using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [Header ("Movement Parameters")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 7f;

    [Header ("Ground Check")]
    public LayerMask checkMask;
    [SerializeField] private float checkRad = 0.4f;
    private CircleCollider2D circleCol;
    private Rigidbody2D rb;
    private float dir;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCol = GetComponent<CircleCollider2D>();
    }

    void Update() {

        if (Input.GetButtonDown("Jump")){
            Jump();
        }
        
    }
    
    void  FixedUpdate()
    {
       Move();
    }

    private void Move(){
        float moveX = Input.GetAxis("Horizontal") + dir;

        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
    }

    public void Jump(){
        if (isGrounded()){

            rb.velocity = Vector2.up * jumpForce;

        }
    }

    private bool isGrounded(){
        return Physics2D.Raycast( circleCol.bounds.center, Vector2.down, checkRad, checkMask);
    }

    public void ButtonUp(){
        dir = 0;
    }
    public void LeftButton(){
        dir = -1;
    }
    public void RightButton(){
        dir = 1;
    }
}
