using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    public float jumpTime;
    public float fallSpeed;

    private Animator _playerAnimator;
    private Transform _playerTransform;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private bool _isJumping;
    float currentTime = 0;

    private BoxCollider2D playerCollider;
    private Rigidbody2D rb;


    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        _playerTransform = GetComponent<Transform>();
        _playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 velocity = rb.velocity;

        // Horizontal movement using Input.GetKey
        if (Input.GetKey("a"))
        {
            velocity.x = -moveSpeed;
            _playerTransform.localScale = new Vector3(-1,1,1);
            if (_isGrounded)
            {
                _playerAnimator.SetBool("IsRunning", true);
            }
        }
        else if (Input.GetKey("d"))
        {
            velocity.x = moveSpeed;
            _playerTransform.localScale = new Vector3(1, 1, 1);
            if (_isGrounded)
            {
                _playerAnimator.SetBool("IsRunning", true);
            }
        }
        else
        {
            velocity.x = 0;
            _playerAnimator.SetBool("IsRunning", false);
        }

        // Jumping logic
        if (Input.GetKey("space") && _isGrounded)
        {
            _isJumping = true;
            currentTime = 0;
        }

        if (_isJumping)
        {
            _isGrounded = false;
            if (currentTime < jumpTime)
            {
                currentTime += Time.deltaTime;
                velocity.y = jumpSpeed;
            }
            else
            {
                _isJumping = false;
            }
        }

        if (!_isJumping && !_isGrounded)
        {
            velocity.y = -fallSpeed;
        }

        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Ground") && collision.otherCollider is BoxCollider2D)
        {
            _isGrounded = true;
            Debug.Log("_isGrounded true");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && collision.otherCollider is BoxCollider2D)
        {
            _isGrounded = false;
            _playerAnimator.SetBool("IsRunning", false);
            Debug.Log("_isGrounded false");
        }
    }
}
