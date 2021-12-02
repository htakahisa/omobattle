using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Daimax4 : MonoBehaviour
{
    public GameObject button;
    public AudioClip sound;

    // Start is called before the first frame update
    void Start() { }



// Update is called once per frame
void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) {
            Status status = GameObject.Find("status").GetComponent<Status>();
            if (status.okane >= 100000) {
                GetComponent<AudioSource>().PlayOneShot(sound);
                button.SetActive(true);
                status.okane -= 100000;
            }  
        }
    }
}
