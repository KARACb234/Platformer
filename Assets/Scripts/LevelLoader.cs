using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private string[] _levelList;
    [SerializeField]
    private LevelElement _levelElementPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Loader();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void Loader()
    {
        int saveLevel = 1;
        if(PlayerPrefs.HasKey("SAVE_LEVEL"))
        {
            saveLevel = PlayerPrefs.GetInt("SAVE_LEVEL");
        }

        for(int i = 0;i < _levelList.Length; i++)
        {
            bool isActive = saveLevel > i;
            LevelElement element = Instantiate(_levelElementPrefab, transform);
            element.Initialize(_levelList[i], isActive);
        }
    }
}
