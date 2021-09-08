using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    AudioSource audoisorce;
    public Text text;

    private float seigenJikan = 30;
    private float time = 0;

    private bool isStart = false;


    private AudioSource bgm;

    // Start is called before the first frame update
    void Start()
    {
        this.bgm = GameObject.Find("warn").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isStart) {
            this.time += Time.deltaTime;

            text.text = "残り " + (int)(this.seigenJikan - this.time) + "秒";
            this.bgm.Stop();
        }

        if (this.time >= 20) {
            text.color = Color.red;//textのColorを、赤色の変更
            
            if (!this.bgm.isPlaying) {
                this.bgm.Play();
            }
        }
        if (this.time >= 30) {
            SceneManager.LoadScene("lose");
            
        }

    }

    public void stop() {
        this.isStart = false;
        text.text = "";
        this.time = 0;
    }

    public void start() {
        this.isStart = true;
        this.time = 0;
        text.color = Color.green;
    }
}
