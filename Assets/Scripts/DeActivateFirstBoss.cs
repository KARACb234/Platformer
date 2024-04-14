using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeActivateFirstBoss : MonoBehaviour
{
    [SerializeField]
    private GameObject firstWall;
    [SerializeField]
    private GameObject secondWall;
    [SerializeField]
    private BosController bosController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bosController.isBossDie == true)
        {
            firstWall.SetActive(false);
            secondWall.SetActive(false);
        }
    }
}
