using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoPage : MonoBehaviour
{
    public GameObject player_info_page;
    public Text info_text;
    public Vampire player;

    public void Open_PlayerInfoPage()
    {
        player = GameObject.Find("DataManager").GetComponent<GameData>().data.player;
        player_info_page.SetActive(true);
        info_text.text = "이름 : " + player.name + "\n"
                       + "혈족 : " + player.clan + "\n"
                       + "HP : " + player.remain_HP + "/" + player.max_HP + "\n"
                       + "SP : " + player.remain_SP + "/" + player.max_SP + "\n"
                       + "육체 : " + player.physical + "\n"
                       + "이능 : " + player.psychic;
    }
}
