using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text MaxScoreText;
    public static MenuManager Instance;
    public InputField input;
    new public string name;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadJSON();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        name = input.text;
        SceneManager.LoadScene(1);
    }

    [System.Serializable]
    class SaveData
    {
        public int maxScore;
        public string champion;
    }

    public void LoadJSON()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            MaxScoreText.text = $"Best Score: {data.maxScore} - {data.champion}";
        }
    }
}
