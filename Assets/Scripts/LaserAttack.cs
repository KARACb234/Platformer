using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack : MonoBehaviour
{
    [SerializeField]
    private LineRenderer laserSprite;
    [SerializeField]
    private Collider2D laserCollider;
    [SerializeField]
    private int count;
    [SerializeField]
    private float duration;
    public void StartLaserAttack()
    {
      StartCoroutine(Attack());
    }
    private IEnumerator Attack()
    {
        for(int i = 0; i < count; i++)
        {
            StartCoroutine(StartAttack());
            yield return new WaitForSeconds(duration);
        }
    }
    void Update()
    {
        
    }
    private IEnumerator  StartAttack()
    {
        yield return new WaitForSeconds(1);
        laserSprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        laserSprite.enabled = false;
        yield return new WaitForSeconds(1.5f);
        laserSprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        laserSprite.enabled = false;
        yield return new WaitForSeconds(1);
        laserSprite.enabled = true;
        laserCollider.enabled = true;
        yield return new WaitForSeconds(4);
        laserSprite.enabled = false;
        laserCollider.enabled = false;
    }
}
