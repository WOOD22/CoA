using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Targeting : MonoBehaviour
{
    public GameObject player;

    GraphicRaycaster tagray;
    PointerEventData tagped;

    private void Start()
    {
        tagray = GameObject.Find("Canvas").GetComponent<GraphicRaycaster>();
        tagped = new PointerEventData(null);
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tagped.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            tagray.Raycast(tagped, results);

            if (results.Count > 0)
            {
                for (int i = 0; i < results.Count; i++)
                {

                    if (results[i].gameObject.name == "Enemy"
                        && !player.GetComponent<Unit_Status>().target.Contains(results[i].gameObject))
                    {
                        player.GetComponent<Unit_Status>().target.Add(results[i].gameObject);
                        Debug.Log("Enemy");
                        if (player.GetComponent<Unit_Status>().target_number < player.GetComponent<Unit_Status>().target.Count)
                        {
                            player.GetComponent<Unit_Status>().target[0].transform.Find("Targeting").gameObject.SetActive(false);
                            player.GetComponent<Unit_Status>().target.Remove(player.GetComponent<Unit_Status>().target[0]);
                            Debug.Log(player.GetComponent<Unit_Status>().target.Count);
                        }
                    }
                    else if (results[i].gameObject.name == "Enemy"
                        && player.GetComponent<Unit_Status>().target.Contains(results[i].gameObject))
                    {
                        results[i].gameObject.transform.Find("Targeting").gameObject.SetActive(false);
                        player.GetComponent<Unit_Status>().target.Remove(results[i].gameObject);
                    }

                        if (player.GetComponent<Unit_Status>().target.Contains(results[i].gameObject))
                    {
                        results[i].gameObject.transform.Find("Targeting").gameObject.SetActive(true);
                    }

                }
            }
        }
    }
}
