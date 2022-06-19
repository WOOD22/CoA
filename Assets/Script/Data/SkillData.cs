using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillData : MonoBehaviour
{
    List<Dictionary<string, object>> skill_table;
    public List<Skill> skill_list;

    void Start()
    {
        skill_table = CSVReader.Read("Language/KR/Skill_Table");

        for (int i = 0; i < skill_table.Count; i++)
        {
            Skill skill = new Skill();
            skill.code = skill_table[i]["code"].ToString();
            skill.name = skill_table[i]["name"].ToString();
            skill.info = skill_table[i]["info"].ToString();
            skill.target_type = skill_table[i]["target_type"].ToString();
            skill.target_number = int.Parse(skill_table[i]["target_number"].ToString());

            //효과 태그화
            string effect = skill_table[i]["effect"].ToString();
            
            skill.effect = new List<string>();

            while (effect.Contains("#") == true)
            {
                int string_cut = effect.LastIndexOf("#", effect.Length);
                string tag_effect = effect.Substring(string_cut);
                tag_effect = tag_effect.Replace("#", "");
                effect = effect.Replace(effect.Substring(string_cut), "");
                skill.effect.Add(tag_effect);
            }
            skill.effect.Reverse();

            skill_list.Add(skill);
        }
    }
}
