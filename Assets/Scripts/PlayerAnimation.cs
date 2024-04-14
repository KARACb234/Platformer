using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private SpriteRenderer _playerRenderer;
    private Animator _animator;
    private PlayerController _playerController;
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _playerRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _playerRenderer.flipX = true;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                _playerRenderer.flipX = false;
            }
        }
        if(Mathf.Abs(_rigidbody.velocity.x) < 0.0000001f)
        {
            _animator.SetBool("IsRun", false);
        }

        else
        {
            _animator.SetBool("IsRun", true);
        }
        if(_playerController.CheckGround() == true)
        {
            _animator.SetBool("OnGround", false);
        }
        else
        {
            _animator.SetBool("OnGround", true);
        }
    }
}
