using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMove : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float placeOfRemovalY;
    private bool isMove;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void StartMove()
    {
        isMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove == true)
        {
            _rigidbody2D.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Impulse);
        }
        if (transform.position.y <= placeOfRemovalY)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerController>().Die();
            Destroy(gameObject);
        }
    }

}
