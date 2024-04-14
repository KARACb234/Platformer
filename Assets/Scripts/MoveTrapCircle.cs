using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrapCircle : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Vector3 diraction;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 15);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(diraction * Time.deltaTime * _speed);
    }
}
