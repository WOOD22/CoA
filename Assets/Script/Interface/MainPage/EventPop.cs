using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPop : MonoBehaviour
{
    public GameObject battle_event_pop;
    public GameObject moon;

    public void BattleEvent()
    {
        if (Random.Range(0, 100.0f) < 0.5f)
        {
            battle_event_pop.SetActive(true);
            DateUI.Pause_Button();
        }

        //보름달 뜨는 밤 이벤트 체크
        if (moon.GetComponent<MoonChange>().day == 14)
        {
            if (Random.Range(0, 100.0f) < 25f)
            {
                battle_event_pop.SetActive(true);
                DateUI.Pause_Button();
            }
        }
    }
}
