using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kayboardinput : MonoBehaviour
{
    private Movement movement;
    private Jumping jumping;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        jumping = GetComponent<Jumping>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");

        movement.Move(new Vector2(horizontal, 0));

        if (Input.GetButton("Jump"))
        {
            jumping.JumpStart();
        }
    }

}
