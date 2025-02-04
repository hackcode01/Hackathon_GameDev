using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _vectorMovement;

    [SerializeField] private float speed;

    [SerializeField] private float jumpTime;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private float jumpPower;
    [SerializeField] private float fallMultiplier;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Vector2 _vectorGravity;

    private bool _isJumping;
    private float _jumpCounter;

    private void Awake()
    {
        _vectorGravity = new(0, -Physics2D.gravity.y);
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new(_vectorMovement.x * speed, _rigidbody.velocity.y);

        if (_rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity -= _vectorGravity * fallMultiplier * Time.deltaTime;
        }

        if (_rigidbody.velocity.y > 0 && _isJumping)
        {
            _jumpCounter += Time.deltaTime;

            if (_jumpCounter > jumpTime)
            {
                _isJumping = false;
            }

            float time = _jumpCounter / jumpTime;
            float currentJumpMovement = jumpMultiplier;

            if (time > 0.5f)
            {
                currentJumpMovement = jumpMultiplier * (1 - time);
            }

            _rigidbody.velocity += _vectorGravity * currentJumpMovement * Time.deltaTime;
        }
    }

    private void Flip()
    {
        if (_vectorMovement.x < -0.01f)
        {
            transform.localScale = new(-1, 1, 1);
        }

        if (_vectorMovement.x > 0.01f)
        {
            transform.localScale = new(1, 1, 1);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new(1.8f, 0.3f),
            CapsuleDirection2D.Horizontal, 0, groundLayer);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started && IsGrounded())
        {
            _rigidbody.velocity = new(_rigidbody.velocity.x, jumpPower);
            _isJumping = true;
            _jumpCounter = 0f;
        }
        else if (context.started)
        {
            _isJumping = false;
            _jumpCounter = 0;

            if (_rigidbody.velocity.y > 0)
            {
                _rigidbody.velocity = new(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.6f);
            }
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        _vectorMovement = context.ReadValue<Vector2>();
        Flip();
    }
}
