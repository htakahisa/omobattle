using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class XP : MonoBehaviour
{ 
    private float huetabun = 0;
    public float countup;
    public Text timeText;
    

    // Start is called before the first frame update
    void Start()
    {

        this.huetabun = (int)0;
    }

    // Update is called once per frame
    void Update()
    {
        Status status = GameObject.Find("status").GetComponent<Status>();

        huetabun += Time.deltaTime * 0.5f * status.katta;


        if ((int)huetabun > 0) {
            status.okane = status.okane + (int)huetabun;
            huetabun = 0;
        }
        timeText.text = status.okane + "GEM";

    }
   
   
}
