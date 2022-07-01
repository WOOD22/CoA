using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePage : MonoBehaviour
{
    public List<GameObject> player_team = new List<GameObject>();
    public List<GameObject> enemy_team = new List<GameObject>();

    public int enemy_count;

    public GameObject field;

    static float turn_speed = 0.1f;
    public static bool is_pause;
    public static bool is_delay;

    void OnEnable()
    {
        is_pause = false;
        is_delay = false;

        Open_BattlePage();
    }

    void Update()
    {
        if (is_delay == false && is_pause == false)
        {
            StartCoroutine(Turn_Gone());
        }

        Transform enemy_side = field.transform.Find("Enemy");
        enemy_count = 0;
        for (int i = 0; i < enemy_side.childCount; i++)
        {
            if (enemy_side.GetChild(i).gameObject.activeSelf)
            {
                enemy_count++;
            }
        }
        if (enemy_count == 0)
        {
            End_Battle();
        }
    }

    IEnumerator Turn_Gone()
    {
        is_delay = true;
        yield return new WaitForSeconds(turn_speed);
        is_delay = false;
    }

    public static void Pause_Button()
    {
        is_pause = true;
    }

    public static void Play_Button()
    {
        is_pause = false;
        turn_speed = 0.1f;
    }

    public void Open_BattlePage()
    {
        int enemy_num = Random.Range(1, 4);
        Transform enemy_side = field.transform.Find("Enemy");

        for (int i = 0; i < enemy_num; i++)
        {
            enemy_side.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void End_Battle()
    {
        this.gameObject.SetActive(false);
    }
}
