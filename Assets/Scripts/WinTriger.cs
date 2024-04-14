using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTriger : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private AudioClip _winClip;
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
        if (collision.gameObject.CompareTag("Player"))

        {
            gameManager.PlaySound(_winClip);
            gameManager.Win();
        }
    }
}
