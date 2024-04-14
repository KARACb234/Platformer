using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class ActivateFirstBos : MonoBehaviour
{
    [SerializeField]
    private GameObject firstWall;
    [SerializeField]
    private GameObject secondWall;
    [SerializeField]
    private float atackHight;
    [SerializeField]
    private GameObject boss;
    [SerializeField]
    private BosController bosController;
    [SerializeField]
    private LaserAttack laserAttack;
    [SerializeField]
    private CircleWall leftWall;
    [SerializeField]
    private CircleWall rightWall;
    [SerializeField]
    private CircleWall upWallLeft;
    [SerializeField]
    private CircleWall upWallRight;
    private bool isActive;
    [SerializeField]
    private GameObject leftPlatform;
    [SerializeField]
    private GameObject rightPlatform;
    [SerializeField]
    private GameObject midlePlatform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bosController.isBossDie == false)
        {
            if (collision.transform.CompareTag("Player"))
            {
                ActivateBoss();
            }
        }
    }

    private void ActivateBoss()
    {
        firstWall.SetActive(true);
        secondWall.SetActive(true);
        if (isActive == true) return;
        isActive = true;

        boss.SetActive(true);
        boss.transform.DOMoveY(atackHight, 5);
        StartCoroutine(Attack());
    }
    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(5);
        laserAttack.StartLaserAttack();
        RandomActivatePlatform();
        yield return StartCoroutine(WallAtack(rightWall.wallPrefab, rightWall.spawnPosition, 3));
        yield return StartCoroutine(WallAtack(leftWall.wallPrefab, leftWall.spawnPosition, 3));
        yield return new WaitForSeconds(3);
        RandomActivatePlatform();
        yield return StartCoroutine(WallAtack(upWallLeft.wallPrefab, upWallLeft.spawnPosition, 5));
        laserAttack.StartLaserAttack();
        yield return StartCoroutine(WallAtack(rightWall.wallPrefab, rightWall.spawnPosition, 3));
        yield return StartCoroutine(WallAtack(leftWall.wallPrefab, leftWall.spawnPosition, 3));
        yield return new WaitForSeconds(3);
        RandomActivatePlatform();
        yield return StartCoroutine(WallAtack(upWallRight.wallPrefab, upWallRight.spawnPosition, 5));
        laserAttack.StartLaserAttack();
        yield return StartCoroutine(WallAtack(rightWall.wallPrefab, rightWall.spawnPosition, 3));
        yield return StartCoroutine(WallAtack(leftWall.wallPrefab, leftWall.spawnPosition, 3));
        yield return new WaitForSeconds(3);
        RandomActivatePlatform();
        yield return StartCoroutine(WallAtack(upWallLeft.wallPrefab, upWallLeft.spawnPosition, 3));
        laserAttack.StartLaserAttack();
        yield return StartCoroutine(WallAtack(rightWall.wallPrefab, rightWall.spawnPosition, 3));
        yield return StartCoroutine(WallAtack(leftWall.wallPrefab, leftWall.spawnPosition, 3));
        yield return new WaitForSeconds(3);
        RandomActivatePlatform();
        yield return StartCoroutine(WallAtack(upWallRight.wallPrefab, upWallRight.spawnPosition, 3));
        laserAttack.StartLaserAttack();
        yield return StartCoroutine(WallAtack(rightWall.wallPrefab, rightWall.spawnPosition, 3));
        yield return StartCoroutine(WallAtack(leftWall.wallPrefab, leftWall.spawnPosition, 3));
        yield return StartCoroutine(WallAtack(upWallLeft.wallPrefab, upWallLeft.spawnPosition, 3));
        yield return new WaitForSeconds(3);
        RandomActivatePlatform();
        laserAttack.StartLaserAttack();
        yield return StartCoroutine(WallAtack(rightWall.wallPrefab, rightWall.spawnPosition, 3));
        yield return StartCoroutine(WallAtack(leftWall.wallPrefab, leftWall.spawnPosition, 3));
        yield return new WaitForSeconds(3);
        RandomActivatePlatform();
        yield return StartCoroutine(WallAtack(upWallRight.wallPrefab, upWallRight.spawnPosition, 3));
    }
    private void RandomActivatePlatform()
    {
        leftPlatform.SetActive(false);
        rightPlatform.SetActive(false);
        midlePlatform.SetActive(false);
        int randomPlatformIndex = UnityEngine.Random.Range(0, 100);
        if(randomPlatformIndex <= 33)
        {
            leftPlatform.SetActive(true);
        }
        else if (randomPlatformIndex <= 66)
        {
            midlePlatform.SetActive(true);
        }
        else
        {
            rightPlatform.SetActive(true);
        }
    }
    private IEnumerator WallAtack(GameObject wallPrefab, Vector3 wallSpawnPoint, float time)
    {
        Instantiate(wallPrefab, wallSpawnPoint, Quaternion.identity);
        yield return new WaitForSeconds(time);
    }
}


[Serializable]
public class CircleWall
{
    public GameObject wallPrefab;
    public Vector3 spawnPosition;
}

