using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mochimono : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 選択したキャラクター表示
        Status status = GameObject.Find("status").GetComponent<Status>();
        status.itemList = new List<ItemType>();


        List<Image> pokeImgList = new List<Image>();
        pokeImgList.Add(GameObject.Find("poke1").GetComponent<Image>());
        pokeImgList.Add(GameObject.Find("poke2").GetComponent<Image>());
        pokeImgList.Add(GameObject.Find("poke3").GetComponent<Image>());
        pokeImgList.Add(GameObject.Find("poke4").GetComponent<Image>());

        




        for (int i = 0; i < 4; i++) {

            if (i < status.kimetaList.Count) {
                Sprite sprite = Resources.Load<Sprite>(status.kimetaList[i]);
                pokeImgList[i].sprite = sprite;
                
            } else {
                pokeImgList[i].enabled = false;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
