using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingPage : MonoBehaviour
{
    Data data;

    void Start()
    {
        data = GameObject.Find("DataManager").GetComponent<GameData>().data;
    }

    public void Training()
    {
        
    }
}
