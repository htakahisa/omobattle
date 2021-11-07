using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageAction : Actions
{

    private string msg;

    private float time = 0;
    private float interval = 2.0f;


    public MessageAction(string msg) {
        this.msg = msg;
    }

    public MessageAction(string msg, float interval) {
        this.msg = msg;
        this.interval = interval;
    }

    public bool doAction()
    {

        if (time == 0) {
            // メッセージ表示
            Text msg = GameObject.Find("msg").GetComponent<Text>();
            msg.text = this.msg;

        }
        this.time += Time.deltaTime;

        return time > interval;
        
    }


}
