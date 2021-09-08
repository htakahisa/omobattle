using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Husiginakousui : MonoBehaviour {
    public int kouka = 55;
    public int kounyuu = 2345;
    int tomato = 0;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnClock() {
        Status status = GameObject.Find("status").GetComponent<Status>();

        if (status.okane < kounyuu) {
            // お金が足りないので買えない
        } else {

            status.okane -= kounyuu;
            status.katta += this.kouka;
            this.tomato += 1;

            if (this.tomato >= 3) {
                // 消す
                gameObject.SetActive(false);
            }
        }
    }
}
