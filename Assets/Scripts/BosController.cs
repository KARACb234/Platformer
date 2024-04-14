using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BosController : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private float smoothTime;
    [SerializeField]
    private SpriteRenderer bosSpriteRenderer;
    [SerializeField]
    private float lifeTime;
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField] private float yOffset;
    public bool isBossDie;
    // Start is called before the first frame update
    void Start()
    {
        bosSpriteRenderer.DOColor(Color.red, lifeTime).OnComplete(Die);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null )
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(playerTransform.position.x, playerTransform.position.y +  yOffset, transform.position.z), smoothTime * Time.deltaTime);
        }
    }

    private void Die()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        isBossDie = true;
    }
}
