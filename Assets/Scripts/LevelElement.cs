using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelElement : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private Button clickButton;
    public void Initialize(string nameLevel, bool isActive)
    {
        nameText.text = nameLevel;
        clickButton.interactable = isActive;
    }

    public void OnClick()
    {
        SceneManager.LoadScene(nameText.text);
    }
}
