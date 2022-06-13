using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    Unit_Status Unit_Status;

    private void Start()
    {
        Unit_Status = this.GetComponent<Unit_Status>();
    }

    public void Use_Skill(Skill skill)
    {
        //need 처리
        for(int i = 0; i < skill.need.Count; i++)
        {
            if(skill.need[i] == "SP")
            {
                Unit_Status.unit.remain_SP -= int.Parse(skill.need[i + 1]);
            }
        }

        //effect 처리
        for (int i = 0; i < skill.effect.Count; i++)
        {
            if (skill.effect[i] == "DMGPSY")
            {
                for(int t = 0; t < Unit_Status.target.Count; t++)
                {
                    Unit_Status.target[t].GetComponent<Unit_Status>().unit.remain_HP -= Unit_Status.unit.psychic * int.Parse(skill.effect[i + 1]);
                }
            }
        }
    }
}
