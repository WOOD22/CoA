using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dmg_Num_Effect : MonoBehaviour
{
    Text dmg_num_text;
    Color alpha;
    public int active_effect = 0;
    // Start is called before the first frame update
    void OnEnable()
    {
        dmg_num_text = this.GetComponent<Text>();
        alpha = dmg_num_text.color;
        alpha.a = 1;

    }

    // Update is called once per frame
    void Update()
    {
        dmg_num_text.transform.localPosition = new Vector3(active_effect * 2, active_effect * 2, 0);
        transform.Translate(new Vector3(0, 10.0f * Time.deltaTime, 0));

        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * 2.0f);
        dmg_num_text.color = alpha;

        if(alpha.a < 0.1f && this.gameObject.activeSelf == true)
        {
            this.gameObject.SetActive(false);
            dmg_num_text.transform.localPosition = new Vector3(active_effect * 2, active_effect * 2, 0);
        }
    }
}
