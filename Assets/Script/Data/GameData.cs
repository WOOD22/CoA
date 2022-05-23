using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class GameData : MonoBehaviour
{
    public Data data;
    /*  세이브  */
    public void Save_File(string file_name)
    {
        if (!Directory.Exists(Application.persistentDataPath + "/Save"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Save");
        }

        string save = JsonUtility.ToJson(data, true);
        string path = Path.Combine(Application.persistentDataPath + "/Save", file_name + ".json");
        File.WriteAllText(path, save);
    }
    /*  로드  */
    public void Load_File(string file_name)
    {
        string path = Path.Combine(Application.persistentDataPath + "/Save", file_name + ".json");
        string save = File.ReadAllText(path);
        data = JsonUtility.FromJson<Data>(save);
    }
}
/*  게임 데이터  */
[Serializable]
public class Data
{
    /*  년, 월, 일  */
    public int year, month, day;
    public Vampire player;
}
/*  뱀파이어  */
[Serializable]
public class Vampire
{
    /*  이름  */
    public string name;
    /*  혈족  */
    public string clan;
    /*  계급  */
    public string caste;
    /*  체력  */
    public int max_HP, remain_HP;
    /*  능력치(육체, 이능)  */
    public int physical, psychic;
    /*  스킬리스트  */
    public List<Skill> skill_list = new List<Skill>();
}
/*  스킬  */
[Serializable]
public class Skill
{
    /*  스킬의 코드, 이름, 설명  */
    public string code, name, info;
    /*  스킬 최대 레벨, 레벨, 경험치, 난이도  */
    public int max_level, level, exp, difficulty;
    /*  필요한 사용에 필요한 자원(sp, 오행)  */
    public int sp, wood, fire, earth, metal, water;
    /*  스킬 사용 시 효과  */
    public List<string> effect;
}