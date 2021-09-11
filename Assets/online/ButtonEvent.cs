using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("inputName") != null) {
            GameObject.Find("inputName").GetComponent<InputField>().text = PlayerPrefs.GetString("inputName");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /**
     * online対戦ボタン
     */
    public void online() {
        PlayerPrefs.DeleteKey("choose");

        SceneManager.LoadScene("onlineName");
    }


    /**
     * 名前入力後、選択画面に移動
     */
    public void choose() {
        InputField inputName = GameObject.Find("inputName").GetComponent<InputField>();

        if (inputName.text == "") {
            return;
        }

        PlayerPrefs.SetString("inputName", inputName.text);
        PlayerPrefs.Save();

        SceneManager.LoadScene("onlineChoose");
    }

    public void battle() {

        SceneManager.LoadScene("onlineBattle");
    }
}
