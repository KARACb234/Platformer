using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField]
    private AudioClip _coinClip;
    private void Start()
    {
        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        _gameManager = gameManagerObject.GetComponent<GameManager>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _gameManager.PlaySound(_coinClip);
            Destroy(gameObject);
            _gameManager.AddScore();
        }
    }
}
