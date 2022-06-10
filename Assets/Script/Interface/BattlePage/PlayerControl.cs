using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Unit unit;
    public GameObject field;
    public List<GameObject> target = new List<GameObject>();
    SkillData skilldata;
    public bool is_enemy_target= false;
    public bool is_friendly_target = false;
    public int number_target = 0;


    void OnEnable()
    {
        unit = this.GetComponent<Unit_Status>().unit;
        unit.name = "플레이어";
        unit.physical = 15;
        unit.psychic = 10;
        unit.max_HP = unit.physical * 10;
        unit.remain_HP = unit.max_HP;
        unit.max_SP = 100;
        unit.remain_SP = 100;
        unit.max_AP = 100;
        unit.pool_AP = 0;

        skilldata = GameObject.Find("DataManager").GetComponent<SkillData>();

        unit.skill_list.Add(skilldata.skill_list[0]);
    }
    //레이트업데이트를 사용해야 작동함
    void LateUpdate()
    {
        if (BattlePage.is_delay == false && BattlePage.is_pause == false)
        {
            unit.pool_AP += unit.physical;
            if (unit.pool_AP >= unit.max_AP)
            {
                BattlePage.is_pause = true;
            }
        }
    }

    public void Attack_Button()
    {
        is_enemy_target = true;
        target = new List<GameObject>();
        number_target = 1;
    }

    public void Attack_Confirm()
    {
        if (unit.pool_AP >= unit.max_AP && number_target == 0)
        {
            for(int i = 0; i < target.Count; i++)
            {
                target[0].GetComponent<Unit_Status>().unit.remain_HP -= unit.physical;
            }
            
            this.GetComponent<Unit_Status>().End_Turn();
        }
    }

    public void Action_Cancel()
    {
        is_enemy_target = false;
        is_friendly_target = false;
        target = new List<GameObject>();
        number_target = 0;
    }

    public void Targeting(string target_name)
    {
        if (number_target > 0)
        {
            if (is_enemy_target)
            {
                target.Add(field.transform.Find("Enemy").Find(target_name).gameObject);
                number_target--;
            }
            if (is_friendly_target)
            {
                target.Add(field.transform.Find("Enemy").Find(target_name).gameObject);
                number_target--;
            }
        }
    }
}
