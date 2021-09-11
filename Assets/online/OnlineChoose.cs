using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineChoose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void choose() {


        string nameStr = PlayerPrefs.GetString("choose");
        string[] names = nameStr.Split(',');

        if (names.Length == 3) {
            return;
        }


        foreach (string name in names) {
            if (name.Equals(gameObject.name)) {
                Debug.Log(nameStr);
                return;
            }
        }

        if (nameStr != null) {
            nameStr += ",";
        }
        nameStr += gameObject.name;

        PlayerPrefs.SetString("choose", nameStr);
        Debug.Log(nameStr);

    }
}
