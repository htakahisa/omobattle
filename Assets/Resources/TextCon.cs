using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextCon : MonoBehaviour {

    public Text Qtext;
    bool a_flag;
    float a_color;
    // Use this for initialization
    void Start() {
        a_flag = false;
        a_color = 0;
    }

    // Update is called once per frame
    void Update() {
        //左クリックでa_flagをTrueにする
        if (Input.GetMouseButtonDown(0)) {
            a_flag = true;
            a_color = 1;
        }
        //a_flagがtrueの間実行する
        if (a_flag) {
            //テキストの透明度を変更する
            Qtext.color = new Color(0, 0, 0, a_color);
            a_color -= Time.deltaTime;
            //透明度が0になったら終了する。
            if (a_color < 0) {
                a_color = 0;
                a_flag = false;
                SceneManager.LoadScene("opening");
            }
        }
    }
}