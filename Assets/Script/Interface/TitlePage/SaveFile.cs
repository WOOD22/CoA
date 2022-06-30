using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class SaveFile : MonoBehaviour
{
    GameData gamedata;
    public Text file_name_text;
    public string file_name;

    private void OnEnable()
    {
        gamedata = GameObject.Find("DataManager").GetComponent<GameData>();

        string path = Path.Combine(Application.persistentDataPath + "/Save", file_name + ".json");
        FileInfo fileInfo = new FileInfo(path);
        if (!fileInfo.Exists)
        {
            file_name_text.text = "새로운 게임";
        }
        else
        {
            gamedata.Load_File(file_name);
            file_name_text.text = gamedata.data.player.name;
        }
    }
    
    public void Load_or_New()
    {
        gamedata.Load_File(file_name);

        string path = Path.Combine(Application.persistentDataPath + "/Save", file_name + ".json");
        FileInfo fileInfo = new FileInfo(path);
        if (!fileInfo.Exists)
        {
            GameObject.Find("SceneManager").GetComponent<SceneChanger>().SceneChange("NewGameScene");
        }
        else
        {
            GameObject.Find("SceneManager").GetComponent<SceneChanger>().SceneChange("GameScene");
        }
    }
    public void Delete_Save()
    {
        GameObject.Find("SceneManager").GetComponent<SceneChanger>().SceneChange("NewGameScene");
    }
}
