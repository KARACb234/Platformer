using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _platformList;
    [SerializeField]
    private float _spawnRate;
    [SerializeField]
    private float minHight;
    [SerializeField]
    private float maxHight;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Spawner()
    {
        while (true)
        {
            float randomHight = Random.Range(minHight, maxHight);
            int randomIndex = Random.Range(0, _platformList.Length);
            Vector3 ramdomPosition = new Vector3(40, randomHight, 0);
            Instantiate(_platformList[randomIndex], ramdomPosition, Quaternion.identity);
            yield return new WaitForSeconds(_spawnRate);
        }

    }
}
