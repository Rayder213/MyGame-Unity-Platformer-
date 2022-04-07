using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    [SerializeField] private AnimationCurve _jumpTracy;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheker;
    [SerializeField] private LayerMask _maskChecker;
    [SerializeField] private float _gravity;

    private bool _jumping = false;
    private float _jumpStepAnimation = 0.01f;
    private float _jumpLife = 0.2f;
    private float _jumpAnimationCurrent = 0f;
    private Rigidbody2D _rigidbody;
    private float _distanceCheckerToGround = 0.5f;
    private bool _permissionToJump = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Physics2D.OverlapCircle(_groundCheker.position, _distanceCheckerToGround, _maskChecker) != null)
        {
            _permissionToJump = true;
        }
        else
        {
            _permissionToJump = false;
        }
    }

    private void FixedUpdate()
    {
        if (!_jumping && !_permissionToJump)
            _rigidbody.velocity = new Vector2(0f, _gravity);
    }

    public void JumpStart()
    {
        if (_permissionToJump && !_jumping)
        {
            InvokeRepeating("Jump", 0.1f, _jumpStepAnimation);
            _jumping = true;
        }
    }

    private void Jump()
    {
        _jumpAnimationCurrent += _jumpStepAnimation;

        if (_jumpAnimationCurrent > _jumpLife)
        {
            CancelInvoke("Jump");
            _jumping = false;
            _jumpAnimationCurrent = 0f;
        }

        _rigidbody.velocity = new Vector2(0f, _jumpForce * _jumpTracy.Evaluate(_jumpAnimationCurrent));

    }
}