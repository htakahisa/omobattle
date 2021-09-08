using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Image img = this.gameObject.GetComponent<Image>();
        Text text = this.gameObject.GetComponentInChildren<Text>();
        Status status = GameObject.Find("status").GetComponent<Status>();
        if (status.level == 0) {
            img.color = Color.white;
            text.text = "ノーマルモード";
        } else if (status.level == 10) {
            img.color = Color.red;
            text.text = "ハードモード";
        } else if (status.level == 40) {
            img.color = Color.black;
            text.text = "不可能";
        } else if (status.level == 100) {
            img.color = Color.clear;
            text.text = "シークレットモード";
        } else if (status.level == 0.01f) {
            img.color = Color.cyan;
            text.text = "簡単";
        }

    }

    public void modeChange() {
        Status status = GameObject.Find("status").GetComponent<Status>();

        if (status.level == 0) {
            status.level = 10;
        } else if (status.level == 10) {
            status.level = 40;
        } else if (status.level == 40) {
            status.level = 100;
        } else if (status.level == 100) {
            status.level = 0.01f;
        } else if (status.level == 0.01f) {
            status.level = 0;
        }

    }
}
