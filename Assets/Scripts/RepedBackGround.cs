using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepedBackGround : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Vector3 _startPosition;
    private float _center;
    // Start is called before the first frame update
    void Start()
    {
        
        _startPosition = transform.position;
        _center = GetComponent<BoxCollider2D>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
        if(transform.position.x < _startPosition.x - _center)
        {
            transform.position = _startPosition;
        }
    }
}
