using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePage : MonoBehaviour
{
    public Text skill_text;
    Data data;
    public int upgrade_skill_num;
    public List<string> upgrade_list = new List<string>();

    void OnEnable()
    {
        data = GameObject.Find("DataManager").GetComponent<GameData>().data;
        Skill_Text();
    }

    public void Skill_Text()
    {
        skill_text.text = "스킬명 : " + data.player.skill_list[upgrade_skill_num].name + "\n" +
                          "스킬 설명 : " + data.player.skill_list[upgrade_skill_num].info + "\n";

        skill_text.text += "\n타겟 대상 : " + data.player.skill_list[upgrade_skill_num].target_type +
                           "\n타겟 수 : " + data.player.skill_list[upgrade_skill_num].target_number;
        for (int i = 0; i < data.player.skill_list[upgrade_skill_num].effect.Count; i++)
        {
            if (data.player.skill_list[upgrade_skill_num].effect[i] == "SP")
            {
                skill_text.text += "\nSP소모 : " + data.player.skill_list[upgrade_skill_num].effect[i + 1];
            }
            if (data.player.skill_list[upgrade_skill_num].effect[i] == "DMGPSY")
            {
                skill_text.text += "\n이능계수 : " + data.player.skill_list[upgrade_skill_num].effect[i + 1];
            }
        }
    }

    public void Skill_Upgrade(string effect)
    {
        upgrade_list = new List<string>();

        while (effect.Contains("#") == true)
        {
            int string_cut = effect.LastIndexOf("#", effect.Length);
            string tag_effect = effect.Substring(string_cut);
            tag_effect = tag_effect.Replace("#", "");
            effect = effect.Replace(effect.Substring(string_cut), "");
            upgrade_list.Add(tag_effect);
        }
        upgrade_list.Reverse();

        for (int i = 0; i < upgrade_list.Count; i++)
        {
            data.player.skill_list[upgrade_skill_num].first_Upgrade.Add(upgrade_list[i]);
        }

        for (int i = 0; i < data.player.skill_list[upgrade_skill_num].effect.Count; i++)
        {
            for (int j = 0; j < upgrade_list.Count; j++)
            {
                if (data.player.skill_list[upgrade_skill_num].effect[i] == "SP" && upgrade_list[j] == "SP")
                {
                    data.player.skill_list[upgrade_skill_num].effect[i + 1] = (float.Parse(data.player.skill_list[upgrade_skill_num].effect[i + 1]) + float.Parse(upgrade_list[j + 1])).ToString();
                }
                if (data.player.skill_list[upgrade_skill_num].effect[i] == "DMGPSY" && upgrade_list[j] == "DMGPSY")
                {
                    data.player.skill_list[upgrade_skill_num].effect[i + 1] = (float.Parse(data.player.skill_list[upgrade_skill_num].effect[i + 1]) + float.Parse(upgrade_list[j + 1])).ToString();
                }
            }
        }

        Skill_Text();
    }
}
