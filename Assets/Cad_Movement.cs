using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cad_Movement : MonoBehaviour
{
    public float JumpForce;
    public float Speed;

    private Rigidbody2D RigidBody2D;
    private float Horizontal;
    private bool Grounded;
    // Start is called before the first frame update
    void Start()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");


        Debug.DrawRay(transform.position, Vector3.down * 1, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 1))
        {
            Grounded = true;
        }
        else { Grounded = false; }

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }
    }
    private void Jump()
    {
        RigidBody2D.AddForce(Vector2.up * JumpForce);
    }
    private void FixedUpdate()
    {
        RigidBody2D.velocity = new Vector2(Horizontal * Speed, RigidBody2D.velocity.y);
        Physics2D.IgnoreLayerCollision(6, 7,false);

    }
}
