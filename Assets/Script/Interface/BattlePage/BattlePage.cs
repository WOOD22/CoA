using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePage : MonoBehaviour
{
    public List<GameObject> player_team = new List<GameObject>();
    public List<GameObject> enemy_team = new List<GameObject>();

    static float turn_speed = 0.1f;
    public static bool is_pause;
    public static bool is_delay;

    void OnEnable()
    {
        is_pause = false;
        is_delay = false;
    }

    void Update()
    {
        if (is_delay == false && is_pause == false)
        {
            StartCoroutine(Turn_Gone());
        }
    }

    IEnumerator Turn_Gone()
    {
        is_delay = true;
        yield return new WaitForSeconds(turn_speed);
        Debug.Log("0");
        is_delay = false;
    }

    public static void Pause_Button()
    {
        is_pause = true;
    }
    public static void Play_Button()
    {
        is_pause = false;
        turn_speed = 0.2f;
    }
}
