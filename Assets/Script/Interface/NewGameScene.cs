using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameScene : MonoBehaviour
{
    Data data;

    public GameObject choice_1, choice_2, choice_3, choice_4, choice_5;
    public new Text name;


    private void Start()
    {
        data = GameObject.Find("DataManager").GetComponent<GameData>().data;
    }

    public void Check_Choice_1(string answer)
    {
        data.player.gender = answer;
    }

    public void Dicision_Choice_1()
    {
        if(data.player.gender != "")
        {
            choice_2.SetActive(true);
            choice_1.SetActive(false);
        }
    }

    public void Check_Choice_2(string answer)
    {
        data.player.prev_job = answer;
    }

    public void Dicision_Choice_2()
    {
        if (data.player.prev_job != "")
        {
            choice_3.SetActive(true);
            choice_2.SetActive(false);
        }
    }

    public void Check_Choice_3(string answer)
    {
        data.player.desire = answer;
    }

    public void Dicision_Choice_3()
    {
        if (data.player.desire != "")
        {
            choice_4.SetActive(true);
            choice_3.SetActive(false);
        }
    }

    public void Check_Choice_4(string answer)
    {
        data.player.clan = answer;
    }

    public void Dicision_Choice_4()
    {
        if (data.player.desire != "")
        {
            choice_5.SetActive(true);
            choice_4.SetActive(false);
        }
    }

    public void Dicision_Choice_5()
    {
        if (name.text != "")
        {
            data.player.name = name.text;
            data.year = 1950;
            data.month = 1;
            data.day = 1;
            choice_1.SetActive(true);
            choice_5.SetActive(false);
            GameObject.Find("DataManager").GetComponent<GameData>().Save_File("1");
            GameObject.Find("SceneManager").GetComponent<SceneChanger>().SceneChange("GameScene");
        }
    }
}
