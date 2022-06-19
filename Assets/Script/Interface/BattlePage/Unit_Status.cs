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

    private void Update()
    {
        HPbar.GetComponent<Image>().fillAmount = (float)unit.remain_HP / (float)unit.max_HP;
        SPbar.GetComponent<Image>().fillAmount = (float)unit.remain_SP / (float)unit.max_SP;
        APbar.GetComponent<Image>().fillAmount = (float)unit.pool_AP / (float)unit.max_AP;
        hp_text.text = unit.remain_HP + "/" + unit.max_HP;
        sp_text.text = unit.remain_SP + "/" + unit.max_SP;

        Dead();
    }

    public void End_Turn()
    {
        unit.pool_AP -= unit.max_AP;
        BattlePage.is_pause = false;
    }

    public void Dead()
    {
        if(unit.remain_HP <= 0)
        {
            this.gameObject.SetActive(false);
            if(this.transform.parent.name == "Enemy")
            {
                BattlePage.enemy_death_count++;
            }
        }
    }
}
