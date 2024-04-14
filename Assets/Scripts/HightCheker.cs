using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HightCheker : MonoBehaviour
{
    [SerializeField]
    private float yPosition;
    [SerializeField]
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < yPosition)
        {
            gameManager.GameOver();
        }
    }
}
