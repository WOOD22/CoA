using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
                    if (results[i].gameObject.name == "Enemy" && player.GetComponent<Unit_Status>().number_target != 0)
                    {
                        player.GetComponent<Unit_Status>().number_target--;
                        player.GetComponent<Unit_Status>().target.Add(results[i].gameObject);
                        Debug.Log("Enemy");
                        results[i].gameObject.transform.Find("Targeting").gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}
