using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Images : MonoBehaviour{

    public Sprite i_1;
    public Sprite i_2;
    public Sprite i_3;
    public Sprite i_4;
    public Sprite i_5;
    public Sprite i_6;
    public Sprite i_7;
    public Sprite i_8;
    public Sprite i_9;
    public Sprite i_10;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setSprite() {

        List<Sprite> spriteList = new List<Sprite>();
        spriteList.Add(i_1);
        spriteList.Add(i_2);
        spriteList.Add(i_3);
        spriteList.Add(i_4);
        spriteList.Add(i_5);
        spriteList.Add(i_6);
        spriteList.Add(i_7);
        spriteList.Add(i_8);
        spriteList.Add(i_9);
        spriteList.Add(i_10);


        GameObject[] changeButtons = GameObject.FindGameObjectsWithTag("change");

        string[] characters = PlayerPrefs.GetString("choose").Split(',');

        changeButtons[0].GetComponent<Image>().sprite = spriteList[int.Parse(characters[0])-1];
        changeButtons[1].GetComponent<Image>().sprite = spriteList[int.Parse(characters[1])-1];
        changeButtons[2].GetComponent<Image>().sprite = spriteList[int.Parse(characters[2])-1];

    }
}
