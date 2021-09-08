using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MochimonoIdou : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void back() {
        SceneManager.LoadScene("hensei");
    }

    public void battle() {


        Status status = GameObject.Find("status").GetComponent<Status>();

        for (int i = 0; i < 4; i++) {
            if (status.itemList.Count < 4) {
                status.itemList.Add(ItemType.NON);
            }
        }



        SceneManager.LoadScene("buttle");


    }
}
