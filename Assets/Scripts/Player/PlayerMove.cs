using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float horizontal;
    float vertical;
    Rigidbody2D rb;
    public float speed;
    public float maxSpeed;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        maxSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(horizontal, vertical) * speed;

        if(horizontal != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
