using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVIMIENTO : MonoBehaviour
{
    public float JumpForce;
    public float Speed;

    private Rigidbody2D RigidBody2D;
    private float Horizontal;
    private bool Grounded;
    private Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-2.0f, 2.0f, 2.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        Animator.SetBool("running", Horizontal != 0.0f);

        Vector3 posicion = transform.position;
        posicion.x = posicion.x - 0.1f;
        Debug.DrawRay(posicion, Vector3.down * 0.55f, Color.red);
        if (Physics2D.Raycast(posicion, Vector3.down, 0.55f))
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
    }
}