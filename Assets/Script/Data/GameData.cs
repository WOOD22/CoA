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
        FileInfo fileInfo = new FileInfo(path);
        if(fileInfo.Exists)
        {
            string save = File.ReadAllText(path);
            data = JsonUtility.FromJson<Data>(save);
        }
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
public class Vampire : Unit
{
    /*  혈족  */
    public string clan;
    /*  계급  */
    public string caste;
    /*  성별  */
    public string gender;
    /*  이전 직업  */
    public string prev_job;
    /*  욕망  */
    public string desire;
}
/*  유닛  */
[Serializable]
public class Unit
{
    /*  이름  */
    public string name = "";
    /*  이미지  */
    public string image_name;
    /*  체력  */
    public int max_HP, remain_HP;
    /*  SP  */
    public int max_SP, remain_SP;
    /*  AP  */
    public int max_AP, pool_AP;
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
    /*  스킬 사용 대상  */
    public string target_type;
    /*  스킬 사용 대상 수  */
    public int target_number;
    /*  스킬 기본 효과  */
    public List<string> effect;
    /*  스킬 업그레이드, 업그레이드 한계  */
    public int upgrade, upgrade_limit;
}