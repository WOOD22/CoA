using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Werewolf : MonoBehaviour
{
    public Unit unit;
    public GameObject target;
    void OnEnable()
    {
        unit = this.GetComponent<Unit_Status>().unit;
        unit.name = "늑대인간";
        unit.image_name = "Werewolf";
        this.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprite/Unit/" + unit.image_name);
        unit.physical = 5;
        unit.psychic = 1;
        unit.max_HP = 50;
        unit.remain_HP = 50;
        unit.max_SP = 10;
        unit.remain_SP = 10;
        unit.max_AP = 100;
        unit.pool_AP = 0;
    }
    
    void LateUpdate()
    {
        if (BattlePage.is_delay == false && BattlePage.is_pause == false)
        {
            if (unit.pool_AP >= unit.max_AP)
            {
                target.GetComponent<Unit_Status>().Get_Damage(unit.physical);
                unit.pool_AP -= unit.max_AP;
            }
        }
    }
}
