using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Werewolf : MonoBehaviour
{
    public Unit unit;
    public GameObject target;
    void OnEnable()
    {
        unit = this.GetComponent<Unit_Status>().unit;
        unit.name = "늑대인간";
        unit.physical = 5;
        unit.psychic = 1;
        unit.max_HP = 50;
        unit.remain_HP = 50;
        unit.max_SP = 10;
        unit.remain_SP = 10;
        unit.max_AP = 100;
        unit.pool_AP = 0;
    }
    //레이트업데이트를 사용해야 작동함
    void LateUpdate()
    {
        if (BattlePage.is_delay == false && BattlePage.is_pause == false)
        {
            unit.pool_AP += 15;
            if (unit.pool_AP >= unit.max_AP)
            {
                target.GetComponent<Unit_Status>().unit.remain_HP -= unit.physical;
                unit.pool_AP -= unit.max_AP;
            }
        }
    }
}
