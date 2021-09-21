using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacterButton : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(0f, 0f, 0f, 0f); // 透明

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * 選択したキャラに変更
     * */
    public void selectChange(string characterId) {
        if (characterId == "" || characterId == null || characterId == "0") {
            return;
        }
        Battle battle = GameObject.Find("battle").GetComponent<Battle>();


        string[] characters = PlayerPrefs.GetString("choose").Split(',');

        battle.selectedCharacterId = long.Parse(characters[(long.Parse(characterId) - 1)]);

        //foreach (GameObject c in GameObject.FindGameObjectsWithTag("change")) {
        //    c.SetActive(false);
        //}

    }





}
