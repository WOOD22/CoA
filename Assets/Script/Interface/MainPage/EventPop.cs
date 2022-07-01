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

        //������ �ߴ� �� �̺�Ʈ üũ
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
