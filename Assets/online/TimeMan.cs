using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeMan : MonoBehaviour
{
    public Text textUI;
  
    // Start is called before the first frame update
    void Start()
    {
        StartButton SB = GameObject.Find("start").GetComponent<StartButton>();
        SB.time = 10;
    }

    // Update is called once per frame
    void Update()
    {

        
        StartButton SB = GameObject.Find("start").GetComponent<StartButton>();
            string str = SB.time.ToString();
        str.ToString();
        str = (SB.time).ToString("f1");
         if (SB.time <= 0) {
            textUI.text = "ミニゲームをplay可能!!";

        } else {
            textUI.text = "残り" + str + "秒"; 

               }
        
    }
}
