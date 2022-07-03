using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateUI : MonoBehaviour
{
    public Text date_text;
    static float date_speed = 1.0f;
    static bool is_pause = true;
    static bool is_delay;
    Data data;

    void Start()
    {
        GameObject.Find("DataManager").GetComponent<GameData>().Load_File("1");
        data = GameObject.Find("DataManager").GetComponent<GameData>().data;
    }

    void Update()
    {
        date_text.text = data.year.ToString() + "." + data.month.ToString() + "." + data.day.ToString();
        if (is_delay == false && is_pause == false)
        {
            data.day++;
            if (data.day > 30)
            {
                data.day = 1;
                data.month++;
            }
            if (data.month > 12)
            {
                data.month = 12;
                data.year++;
            }
            //¿Ã∫•∆Æ
            this.GetComponent<EventPop>().BattleEvent();

            StartCoroutine(Time_Gone());
        }
    }

    IEnumerator Time_Gone()
    {
        is_delay = true;
        yield return new WaitForSeconds(date_speed);
        is_delay = false;
    }

    public static void Pause_Button()
    {
        is_pause = true;
    }
    public static void Play_Button()
    {
        is_pause = false;
        date_speed = 1.0f;
    }
    public static void Fast_Button()
    {
        is_pause = false;
        date_speed = 0.1f;
    }
}
