using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeCharacterButton : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(0f, 0f, 0f, 0f); // 透明

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
        BattleAction battle = GameObject.Find("battleAction").GetComponent<BattleAction>();


        string[] characters = PlayerPrefs.GetString("choose").Split(',');

        battle.selectedCharacterId = long.Parse(characters[(long.Parse(characterId) - 1)]);




    }





}
