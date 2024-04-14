using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpForce;
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private LayerMask _ignoringMask;
    [SerializeField]
    private float _gravitation;
    [SerializeField]
    private float _distance; 
    [SerializeField]
    private float _leftDistance;    
    [SerializeField]
    private float _rightDistance;
    [SerializeField]
    private Vector2 _leftHandPosition;
    [SerializeField]
    private Vector2 _rightHandPosition;
    [SerializeField]
    private GameManager gameManager;
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _jumpClip;
    [SerializeField]
    private GameObject explosionPrefab;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (gameManager.isGameOver == false)
        {
            Move();
            Jump();
        }
    }
    
    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if(horizontalInput < 0 && CheckLeftSide() == true)
        {
            horizontalInput = 1;
        }   
        if(horizontalInput > 0 && CheckRightSide() == true)
        {
            horizontalInput = -1;
        }

        _rigidbody2D.velocity = new Vector2(_speed * horizontalInput, _rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (CheckGround() == true))
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
            _audioSource.PlayOneShot(_jumpClip);
        }
    }

    public bool CheckGround()
    {
        
        if(CheckFootGroundLeft() || CheckFootGroundRight() == true)
        {

            return true;
        }
        else
        {
            return false;
        }
    }  
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector2 distance= transform.TransformDirection(_rightHandPosition) * _distance;
        Gizmos.DrawRay(transform.position, distance);
        Vector2 distance1 = transform.TransformDirection(_leftHandPosition) * _distance;
        Gizmos.DrawRay(transform.position, distance1); 
        Gizmos.DrawRay(transform.position, Vector3.left * _leftDistance);
        Gizmos.DrawRay(transform.position, Vector3.right * _rightDistance);
    }

    public bool CheckFootGroundLeft()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _leftHandPosition, _distance, _ignoringMask);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }
    public bool CheckFootGroundRight()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _rightHandPosition, _distance, _ignoringMask);
        if (hit.collider != null)
        {
            return true;
        }
        return false;

    }
    public bool CheckLeftSide()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, _leftDistance, _ignoringMask);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }  
    public bool CheckRightSide()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, _rightDistance, _ignoringMask);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Trap"))
        {
            Die();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Lazer"))
        {
            Die();
        }
    }
    public void Die()
    {
        gameManager.GameOver();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}