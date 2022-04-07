using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private bool isGround = false;
    [SerializeField] private Transform groundCheker;

    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriterenderer;

    private  void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }


    public void Move(Vector2 direction)
    {

        switch (direction.x)
        {

            case 1: spriterenderer.flipX = false;
                break;
            case -1: spriterenderer.flipX = true;
                break;
        }   

        direction = direction * speed;
        rigidbody2D.position += direction * Time.deltaTime;



    }

    



}

