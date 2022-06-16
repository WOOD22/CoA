using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    Data data;
    public Unit unit;
    public GameObject field;
    public List<GameObject> target;
    SkillData skilldata;
    public bool is_enemy_target= false;
    public bool is_friendly_target = false;

    public GameObject AttackBoard;
    public GameObject TargetBoard;

    public Text Skill_Text_0;

    void OnEnable()
    {
        data = GameObject.Find("DataManager").GetComponent<GameData>().data;
        skilldata = GameObject.Find("DataManager").GetComponent<SkillData>();
        unit = this.GetComponent<Unit_Status>().unit;

        unit.name = data.player.name;
        unit.physical = data.player.physical;
        unit.psychic = data.player.psychic;
        unit.max_HP = data.player.max_HP;
        unit.remain_HP = data.player.remain_HP;
        unit.max_SP = data.player.max_SP;
        unit.remain_SP = data.player.remain_SP;
        unit.max_AP = 100;
        unit.pool_AP = 0;

        target = this.GetComponent<Unit_Status>().target;
        skilldata = GameObject.Find("DataManager").GetComponent<SkillData>();
        unit.skill_list.Add(skilldata.skill_list[0]);

        Skill_Text_0.text = skilldata.skill_list[0].name;
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
        if (unit.pool_AP >= unit.max_AP)
        {
            AttackBoard.SetActive(true);
            is_enemy_target = true;
            target.Clear();
            this.GetComponent<Unit_Status>().number_target = 1;
        }
    }

    public void Attack_Confirm()
    {
        if (unit.pool_AP >= unit.max_AP && this.GetComponent<Unit_Status>().number_target == 0)
        {
            for(int i = 0; i < target.Count; i++)
            {
                target[0].GetComponent<Unit_Status>().unit.remain_HP -= unit.physical;
            }
            AttackBoard.SetActive(false);
            this.GetComponent<Unit_Status>().End_Turn();
        }
    }

    public void Action_Cancel()
    {
        is_enemy_target = false;
        is_friendly_target = false;
        target.Clear();
        this.GetComponent<Unit_Status>().number_target = 0;
    }

    public void Skill_Button(int num)
    {
        if (unit.pool_AP >= unit.max_AP)
        {
            TargetBoard.SetActive(true);
            if(unit.skill_list[num].target_type == "enemy")
            {
                is_enemy_target = true;
            }
            target.Clear();
            this.GetComponent<Unit_Status>().number_target = unit.skill_list[num].target_number;
        }
    }

    public void Skill_Confirm(int num)
    {
        if (unit.pool_AP >= unit.max_AP && this.GetComponent<Unit_Status>().number_target == 0)
        {
            this.gameObject.GetComponent<Use_Skill>().Using_Skill(unit.skill_list[num]);
            TargetBoard.SetActive(false);
            this.GetComponent<Unit_Status>().End_Turn();
        }
    }

    public void Skill_Cancel()
    {
        is_enemy_target = false;
        is_friendly_target = false;
        target.Clear();
        this.GetComponent<Unit_Status>().number_target = 0;
    }
}
