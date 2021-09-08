using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hensei : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {


        SpriteRenderer[] l = GameObject.Find("Canvas").GetComponentsInChildren<SpriteRenderer>();
        string a = "";
        foreach (SpriteRenderer bax in l) {
            a += bax.name + " ";
        }
        Debug.Log(a);


        if (GameObject.Find("status") == null) {
            return;
        }
        Status status = GameObject.Find("status").GetComponent<Status>();
        status.kimetaList = new List<string>();
    }

    // Update is called once per frame
    void Update() {
       

    }

    public void To() {
        SceneManager.LoadScene("hensei");
    }
}
