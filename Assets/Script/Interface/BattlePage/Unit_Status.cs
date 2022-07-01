using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit_Status : MonoBehaviour
{
    public Unit unit;
    public List<GameObject> target = new List<GameObject>();
    public int target_number = 0;
    public GameObject HPbar, SPbar, APbar;
    public Text hp_text, sp_text;

    public GameObject dmg_num_text;

    private void Update()
    {
        HPbar.GetComponent<Image>().fillAmount = (float)unit.remain_HP / (float)unit.max_HP;
        SPbar.GetComponent<Image>().fillAmount = (float)unit.remain_SP / (float)unit.max_SP;
        APbar.GetComponent<Image>().fillAmount = (float)unit.pool_AP / (float)unit.max_AP;
        hp_text.text = unit.remain_HP + "/" + unit.max_HP;
        sp_text.text = unit.remain_SP + "/" + unit.max_SP;

        Dead();
    }

    void LateUpdate()
    {
        if (BattlePage.is_delay == false && BattlePage.is_pause == false)
        {
            unit.pool_AP += unit.physical;
            if (unit.pool_AP >= unit.max_AP)
            {
                //BattlePage.is_pause = true;
            }
        }
    }

    public void End_Turn()
    {
        unit.pool_AP -= unit.max_AP;
        BattlePage.is_pause = false;
    }

    public void Get_Damage(float dmg)
    {
        GameObject dmg_num = this.transform.Find("Dmg_Num").gameObject;
        bool new_text = true;
        for(int i = 0; i < dmg_num.transform.childCount; i++)
        {
            if (dmg_num.transform.GetChild(i).gameObject.activeSelf == false)
            {
                new_text = false;
                dmg_num.transform.GetChild(i).GetComponent<Text>().text = ((int)dmg).ToString();
                dmg_num.transform.GetChild(i).gameObject.SetActive(true);
                break;
            }
            else
            {
                new_text = true;
            }
        }

        if (new_text)
        {
            GameObject instance = Instantiate(dmg_num_text, dmg_num.transform);
            instance.GetComponent<Dmg_Num_Effect>().active_effect = dmg_num.transform.childCount;
            instance.GetComponent<Text>().text = ((int)dmg).ToString();
        }
        unit.remain_HP -= (int)dmg;
    }

    public void Dead()
    {
        if(unit.remain_HP <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
