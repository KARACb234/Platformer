using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrapScript : MonoBehaviour
{
    [SerializeField]
    private float _rotationDuration;

    public void Start()
    {
        TweenCallback action = () => { transform.eulerAngles = Vector3.zero; };
        transform.DORotate(Vector3.forward * 359, _rotationDuration, RotateMode.WorldAxisAdd).SetEase(Ease.Linear).OnComplete(action).SetLoops(-1);
    }
}