using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonChange : MonoBehaviour
{
    GameObject moon;
    public int day;
    public Sprite[] moon_sprites;

    void Start()
    {
        moon = this.gameObject;
        moon_sprites = Resources.LoadAll<Sprite>("Sprite/Moon");
    }

    void Update()
    {
        day = GameObject.Find("DataManager").GetComponent<GameData>().data.day;
        moon.GetComponent<Image>().sprite = moon_sprites[day - 1];
    }
}
