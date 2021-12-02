using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotCoin : MonoBehaviour {
    public GameObject text;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    async void Update() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            Status status = GameObject.Find("status").GetComponent<Status>();
            if (status.okane >= 100000) {
            } else {
                text.SetActive(true);
                await System.Threading.Tasks.Task.Delay(3000);
                text.SetActive(false);
            }
        }
    }
}
