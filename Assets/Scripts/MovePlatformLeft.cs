using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformLeft : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float xBorder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
        if(transform.position.x < xBorder)
        {
            Destroy(gameObject);
        }
    }
}
