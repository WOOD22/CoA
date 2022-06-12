using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit_Status : MonoBehaviour
{
    public Unit unit;
    public List<GameObject> target = new List<GameObject>();
    public int number_target = 0;
    public GameObject HPbar, SPbar, APbar;

    private void Update()
    {
        HPbar.GetComponent<Image>().fillAmount = (float)unit.remain_HP / (float)unit.max_HP;
        SPbar.GetComponent<Image>().fillAmount = (float)unit.remain_SP / (float)unit.max_SP;
        APbar.GetComponent<Image>().fillAmount = (float)unit.pool_AP / (float)unit.max_AP;

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
        }
    }
}
