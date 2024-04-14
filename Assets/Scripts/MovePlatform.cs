using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovePlatform : MonoBehaviour
{
    [SerializeField]
    private Vector3 _startPoint;
    [SerializeField]
    private Vector3 _endPoint;
    [SerializeField]
    private float _duration;
    // Start is called before the first frame update
    void Start()
    {
        MoveToStartPoint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveToStartPoint()
    {
        transform.DOMove(_startPoint, _duration).SetEase(Ease.Linear).OnComplete(MoveToEndPoint);
    }
       private void MoveToEndPoint()
    {
        transform.DOMove(_endPoint, _duration).SetEase(Ease.Linear).OnComplete(MoveToStartPoint);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }


}
