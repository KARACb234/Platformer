using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    [SerializeField]
    private GameObject gameOverCanvas;
    [SerializeField]
    private GameObject winCanvas;
    [SerializeField]
    private GameObject gameCanvas;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private int _score;
    private AudioSource _audioSource;
    [SerializeField]
    private GameObject exitCanvas;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenPanel();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverCanvas.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Win() 
    {
        isGameOver = true;
        winCanvas.SetActive(true);
        PlayerPrefs.SetInt("SAVE_LEVEL", SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.Save();
    }

    public void AddScore()
    {
        _score++;
        UpdateText();
    }
    private void UpdateText()
    {
        scoreText.text = "Coins: " + _score;
    }

    public void PlaySound(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
    private void OpenPanel()
    {
        exitCanvas.SetActive(true);
        Time.timeScale = 0.1f;
    }
    public void ClosePanel()
    {
        exitCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
