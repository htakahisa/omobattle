using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButton : MonoBehaviour
{

    private GameObject[] changes;
    private Boolean[] alive = { true, true, true };
    // Start is called before the first frame update
    void Start()
    {
        changes = GameObject.FindGameObjectsWithTag("change");
        if (changes == null || changes.Length == 0) {
            return;
        }
        string[] characters = PlayerPrefs.GetString("choose").Split(',');

        changes[0].GetComponent<UnityEngine.UI.Image>().sprite =
            Resources.Load<Sprite>(Characters.of().getName(long.Parse(characters[0])));
        changes[1].GetComponent<UnityEngine.UI.Image>().sprite =
            Resources.Load<Sprite>(Characters.of().getName(long.Parse(characters[1])));
        changes[2].GetComponent<UnityEngine.UI.Image>().sprite =
            Resources.Load<Sprite>(Characters.of().getName(long.Parse(characters[2])));

        //foreach (GameObject c in changes) {

        //    c.SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showChangeList() {

        int index = 0;
        foreach (GameObject c in changes) {
            if (alive[index]) {
                c.GetComponent<UnityEngine.UI.Image>().color = new Color(1f,1f, 1f, 1f);
            }
            index++;
        }
    }

    public void disabledChangeList() {
        int index = 0;
        foreach (GameObject c in changes) {
            c.GetComponent<UnityEngine.UI.Image>().color = new Color(0f, 0f, 0f, 0f);

        }
    }


        public void updateAliveToFalse(long characterId) {
        string[] characters = PlayerPrefs.GetString("choose").Split(',');

        int index = 0;
        foreach (string c in characters) {
            if (long.Parse(c) == characterId) {
                alive[index] = false;
                index++;
            }
        }
    }

    public void updateAliveToFalse(bool b1, bool b2, bool b3) {
        this.alive[0] = b1;
        this.alive[1] = b2;
        this.alive[2] = b3;
    }
}
