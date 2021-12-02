using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
    
    // Start is called before the first frame update
    public AudioClip sound;
    

    public float time = 10;

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        this.time -= Time.deltaTime;

     

        
            
        
    }

    public async void start() {
        GetComponent<AudioSource>().PlayOneShot(sound);
        await System.Threading.Tasks.Task.Delay(1300);
        // 画面遷移
        Status status = GameObject.Find("status").GetComponent<Status>();
        status.gameMode = GameMode.BATTLE;
        SceneManager.LoadScene("buttle");
    }

    public async void dimax() {
        GetComponent<AudioSource>().PlayOneShot(sound);
        await System.Threading.Tasks.Task.Delay(1300);
        // 画面遷移
        Status status = GameObject.Find("status").GetComponent<Status>();
        status.gameMode = GameMode.DAIMAX;
        SceneManager.LoadScene("map");

    }
    public async void dimax2() {
        GetComponent<AudioSource>().PlayOneShot(sound);
        await System.Threading.Tasks.Task.Delay(1300);
        // 画面遷移
        Status status = GameObject.Find("status").GetComponent<Status>();
        status.gameMode = GameMode.DAIMAX2;
        SceneManager.LoadScene("map2");
    }

    public async void dimax3() {
        GetComponent<AudioSource>().PlayOneShot(sound);
        await System.Threading.Tasks.Task.Delay(1300);
        // 画面遷移
        Status status = GameObject.Find("status").GetComponent<Status>();
        status.gameMode = GameMode.DAIMAX3;
        SceneManager.LoadScene("map3");
    }
    public async void dimax4() {
        GetComponent<AudioSource>().PlayOneShot(sound);
        await System.Threading.Tasks.Task.Delay(1300);
        // 画面遷移
        Status status = GameObject.Find("status").GetComponent<Status>();
        status.gameMode = GameMode.DAIMAX4;
        SceneManager.LoadScene("map4");
    }

    public async void sutegi1() {
        GetComponent<AudioSource>().PlayOneShot(sound);
        await System.Threading.Tasks.Task.Delay(1300);
        // 画面遷移
        Status status = GameObject.Find("status").GetComponent<Status>();
        status.gameMode = GameMode.SUTEGI1;
        SceneManager.LoadScene("sutegi" + status.stage);
    }

    public async void Kabu() {
        GetComponent<AudioSource>().PlayOneShot(sound);
        await System.Threading.Tasks.Task.Delay(1300);
        // 画面遷移
        Status status = GameObject.Find("status").GetComponent<Status>();
        status.gameMode = GameMode.SUTEGI1;
        SceneManager.LoadScene("Trade");
    }



    public async void opening() {
        GetComponent<AudioSource>().PlayOneShot(sound);
        await System.Threading.Tasks.Task.Delay(1300);
        SceneManager.LoadScene("opening");
    }
    public async void Game() {
       if(this.time <= 0) { 
        
            GetComponent<AudioSource>().PlayOneShot(sound);
            await System.Threading.Tasks.Task.Delay(1300);
            SceneManager.LoadScene("minigame");

            this.time = 10;
        }


        }

}