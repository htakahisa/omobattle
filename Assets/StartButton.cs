using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void start() {
        // 画面遷移
        Status status = GameObject.Find("status").GetComponent<Status>();
        status.gameMode = GameMode.BATTLE;
        SceneManager.LoadScene("buttle");
    }

    public void dimax() {
        // 画面遷移
        Status status = GameObject.Find("status").GetComponent<Status>();
        status.gameMode = GameMode.DAIMAX;
        SceneManager.LoadScene("map");

    }
    public void dimax2() {
        // 画面遷移
        Status status = GameObject.Find("status").GetComponent<Status>();
        status.gameMode = GameMode.DAIMAX2;
        SceneManager.LoadScene("map2");
    }

    public void dimax3() {
        // 画面遷移
        Status status = GameObject.Find("status").GetComponent<Status>();
        status.gameMode = GameMode.DAIMAX3;
        SceneManager.LoadScene("map3");
    }
    public void dimax4() {
        // 画面遷移
        Status status = GameObject.Find("status").GetComponent<Status>();
        status.gameMode = GameMode.DAIMAX4;
        SceneManager.LoadScene("map4");
    }

    public void sutegi1() {
        // 画面遷移
        Status status = GameObject.Find("status").GetComponent<Status>();
        status.gameMode = GameMode.SUTEGI1;
        SceneManager.LoadScene("sutegi" + status.stage);
    }



    public void opening() {
        SceneManager.LoadScene("opening");
    }

}