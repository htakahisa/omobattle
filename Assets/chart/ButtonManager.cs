using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void back() {
        if (GameObject.Find("status") != null) {
            Status status = GameObject.Find("status").GetComponent<Status>();
            status.okane = (int)GameObject.Find("TradeManager").GetComponent<TradeManager>().getOkane();
        }
        SceneManager.LoadScene("opening");
    }


    public void p1() {
        this.plus(10000);
    }
    public void p5() {
        this.plus(50000);
    }
    public void p10() {
        this.plus(100000);
    }
    public void m1() {
        this.plus(-10000);
    }
    public void m5() {
        this.plus(-50000);
    }
    public void m10() {
        this.plus(-100000);
    }


    public void plus(int addValue) {
        int i = 0;
        bool isNum = int.TryParse(GameObject.Find("input").GetComponent<InputField>().text, out i);
        if (!isNum) {
            return;
        }
        int value = int.Parse(GameObject.Find("input").GetComponent<InputField>().text);

        if (addValue < 0 && value < Math.Abs(addValue)) {
            addValue = value * -1;
        }

        GameObject.Find("input").GetComponent<InputField>().text = (value + addValue).ToString();
    }

    public void clear() {
        GameObject.Find("input").GetComponent<InputField>().text = "0";
    }

}
