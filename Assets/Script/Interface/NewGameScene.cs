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
    //마지막 결정 모든 결정들을 종합하여 능력치를 정한다.
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

            switch (data.player.gender)
            {
                case "Male":
                    data.player.physical += 4;
                    data.player.psychic += 1;
                    break;
            }

            switch (data.player.prev_job)
            {
                case "Police":
                    data.player.physical += 4;
                    data.player.psychic += 1;
                    break;
            }

            switch (data.player.desire)
            {
                case "Power":
                    data.player.physical += 2;
                    data.player.psychic += 3;
                    break;
            }

            switch (data.player.clan)
            {
                case "Vladimir":
                    data.player.physical += 3;
                    data.player.psychic += 2;
                    break;
            }

            data.player.max_HP = data.player.physical * 10;
            data.player.remain_HP = data.player.max_HP;
            data.player.max_SP = data.player.psychic * 10;
            data.player.remain_SP = data.player.max_SP;
            data.player.caste = "Servant";

            GameObject.Find("DataManager").GetComponent<GameData>().Save_File("1");
            GameObject.Find("SceneManager").GetComponent<SceneChanger>().SceneChange("GameScene");
        }
    }
}
