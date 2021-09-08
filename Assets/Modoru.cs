using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Modoru : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClock() {
        if (GameObject.Find("status") != null) {
            Status status = GameObject.Find("status").GetComponent<Status>();
            status.tasuki = 0;
        }

        SceneManager.LoadScene("opening");
    }

    public void mochimono() {
        

        SceneManager.LoadScene("mochimono");

    }


    public void battle() {
        Status status = GameObject.Find("status").GetComponent<Status>();
        //if (status.kimetaList.Count >= 4) {
            SceneManager.LoadScene("buttle");
       
        //}
        
    }
}
