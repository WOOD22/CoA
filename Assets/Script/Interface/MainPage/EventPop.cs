using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPop : MonoBehaviour
{
    public GameObject battle_event_pop;
    public void BattleEvent()
    {
        if (Random.Range(0, 100) < 10)
        {
            battle_event_pop.SetActive(true);
            DateUI.Pause_Button();
        }
    }
}
