using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kusuri : MonoBehaviour {
    public int kouka = 1;
    public int kounyuu = 100;
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
            status.okane = status.okane - kounyuu;
            status.katta += this.kouka;
        }
    }
}
