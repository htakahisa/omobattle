using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map2 : MonoBehaviour {
    private GameObject touyamaomoko;

    private GameObject daiyourantoyama;

    public static int step = 0;

    private bool moved;

    private float time;

    // Start is called before the first frame update
    void Start() {
        touyamaomoko = GameObject.Find("touyamaomoko");
        daiyourantoyama = GameObject.Find("daikyourantoyama");



    }

    // Update is called once per frame
    void Update() {
        Status status = GameObject.Find("status").GetComponent<Status>();
        step = status.map2Step;

        // 最初に今いる地点まで移動する
        if (step == 1) {
            if (!this.moved) {
                this.touyamaomoko.GetComponent<RectTransform>().localPosition = new Vector3(27, -276, 0);
                this.moved = true;
            }
        }
        if (step == 2) {
            if (!this.moved) {
                this.touyamaomoko.GetComponent<RectTransform>().localPosition = new Vector3(-68, 179, 0);
                this.moved = true;
            }
        }
        if (step == 3) {
            if (!this.moved) {
                this.touyamaomoko.GetComponent<RectTransform>().localPosition = new Vector3(478, -273, 0);
                this.moved = true;
            }
        }
        if (step == 4) {
            if (!this.moved) {
                this.touyamaomoko.GetComponent<RectTransform>().localPosition = new Vector3(438, -113, 0);
                this.moved = true;
            }
        }

        this.time += Time.deltaTime;
        if (this.time < 2f) {
            return;
        }

        if (step == 0) {
            if (this.touyamaomoko.GetComponent<RectTransform>().localPosition.x <= -100) {
                this.moveTo1();
            } else {
                SceneManager.LoadScene("buttle");

            }
        }
        if (step == 1) {
            if (this.touyamaomoko.GetComponent<RectTransform>().localPosition.y <= -98) {
                this.moveTo2();
            } else {
                SceneManager.LoadScene("buttle");

            }
        }
        if (step == 2) {
            if (this.touyamaomoko.GetComponent<RectTransform>().localPosition.y >= -220) {
                this.moveTo3();
            } else {
                SceneManager.LoadScene("buttle");

            }
        }
        if (step == 3) {
            if (this.touyamaomoko.GetComponent<RectTransform>().localPosition.y <= 143) {
                this.moveTo4();
            } else {
                SceneManager.LoadScene("buttle");

            }
        }
        if (step == 4) {
            SceneManager.LoadScene("win");
        }
    }



    private void moveTo1() {
        this.touyamaomoko.GetComponent<RectTransform>().localPosition += new Vector3(3, 0, 0);
    }

    private void moveTo2() {
        this.touyamaomoko.GetComponent<RectTransform>().localPosition += new Vector3(0, 3, 0);
    }

    private void moveTo3() {
        this.touyamaomoko.GetComponent<RectTransform>().localPosition += new Vector3(3, -3, 0);
    }

    private void moveTo4() {
        this.touyamaomoko.GetComponent<RectTransform>().localPosition += new Vector3(0, 3, 0);
    }
}
