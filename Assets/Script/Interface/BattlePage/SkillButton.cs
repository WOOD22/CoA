using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillButton : MonoBehaviour
{
    public Text skill_text;
    public GameObject unit;
    public int num;
    public Skill skill;

    void OnEnable()
    {
        skill = unit.GetComponent<Unit_Status>().unit.skill_list[num];
        skill_text.text = skill.name;
    }

    public void Use_Skill()
    {
        //need 처리
        for(int i = 0; i < skill.need.Count; i++)
        {
            if(skill.need[i] == "SP")
            {
                unit.GetComponent<Unit_Status>().unit.remain_SP -= int.Parse(skill.need[i + 1]);
            }
        }

        //effect 처리
        for (int i = 0; i < skill.effect.Count; i++)
        {
            if (skill.effect[i] == "DMGPSY")
            {
                
            }
        }
    }
}
