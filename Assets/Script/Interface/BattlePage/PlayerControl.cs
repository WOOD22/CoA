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
        unit.image_name = "Vampire";
        unit.physical = data.player.physical;
        unit.psychic = data.player.psychic;
        unit.max_HP = data.player.max_HP;
        unit.remain_HP = data.player.remain_HP;
        unit.max_SP = data.player.max_SP;
        unit.remain_SP = data.player.remain_SP;
        unit.max_AP = 100;
        unit.pool_AP = 0;

        target = this.GetComponent<Unit_Status>().target;

        for(int i = 0; i < data.player.skill_list.Count; i++)
        {
            unit.skill_list.Add(data.player.skill_list[i]);
        }

        Skill_Text_0.text = skilldata.skill_list[0].name;
    }
    
    void LateUpdate()
    {
        if (BattlePage.is_delay == false && BattlePage.is_pause == false)
        {
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
            for (int i = 0; i < this.GetComponent<Unit_Status>().target.Count; i++)
            {
                this.GetComponent<Unit_Status>().target[i].transform.Find("Targeting").gameObject.SetActive(false);
            }
            AttackBoard.SetActive(true);
            is_enemy_target = true;
            target.Clear();
            this.GetComponent<Unit_Status>().target_number = 1;
        }
    }

    public void Attack_Confirm()
    {
        if (unit.pool_AP >= unit.max_AP)
        {
            for (int i = 0; i < target.Count; i++)
            {
                target[0].GetComponent<Unit_Status>().Get_Damage(unit.physical);
            }
            for (int i = 0; i < this.GetComponent<Unit_Status>().target.Count; i++)
            {
                this.GetComponent<Unit_Status>().target[i].transform.Find("Targeting").gameObject.SetActive(false);
            }
            AttackBoard.SetActive(false);
            this.GetComponent<Unit_Status>().End_Turn();
        }
    }

    public void Action_Cancel()
    {
        for (int i = 0; i < this.GetComponent<Unit_Status>().target.Count; i++)
        {
            this.GetComponent<Unit_Status>().target[i].transform.Find("Targeting").gameObject.SetActive(false);
        }
        is_enemy_target = false;
        is_friendly_target = false;
        target.Clear();
        this.GetComponent<Unit_Status>().target_number = 0;
    }

    public void Skill_Button(int num)
    {
        if (unit.pool_AP >= unit.max_AP)
        {
            TargetBoard.SetActive(true);
            for (int i = 0; i < this.GetComponent<Unit_Status>().target.Count; i++)
            {
                this.GetComponent<Unit_Status>().target[i].transform.Find("Targeting").gameObject.SetActive(false);
            }
            if (unit.skill_list[num].target_type == "enemy")
            {
                is_enemy_target = true;
            }
            target.Clear();
            this.GetComponent<Unit_Status>().target_number = unit.skill_list[num].target_number;
        }
    }

    public void Skill_Confirm(int num)
    {
        if (unit.pool_AP >= unit.max_AP)
        {
            for (int i = 0; i < this.GetComponent<Unit_Status>().target.Count; i++)
            {
                this.GetComponent<Unit_Status>().target[i].transform.Find("Targeting").gameObject.SetActive(false);
            }
            this.gameObject.GetComponent<Use_Skill>().Using_Skill(unit.skill_list[num]);
            TargetBoard.SetActive(false);
            this.GetComponent<Unit_Status>().End_Turn();
        }
    }

    public void Skill_Cancel()
    {
        for (int i = 0; i < this.GetComponent<Unit_Status>().target.Count; i++)
        {
            this.GetComponent<Unit_Status>().target[i].transform.Find("Targeting").gameObject.SetActive(false);
        }
        is_enemy_target = false;
        is_friendly_target = false;
        target.Clear();
        this.GetComponent<Unit_Status>().target_number = 0;
    }
}
