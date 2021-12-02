using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouletteCon : MonoBehaviour
{
  
    public AudioClip sound2;

    float rotSpeed = 0; //回転速度
    
    bool clicked = false;

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0) && !clicked) {
           

            clicked = true;

            this.rotSpeed = Random.Range(30, 130);
            
        }
        transform.Rotate(0, 0, this.rotSpeed);
       

        this.rotSpeed *= 0.96f;

        if (clicked && this.rotSpeed < 0.01 && rotSpeed != 0) {

            rotSpeed = 0;

            int point = 0;
            float angle = gameObject.transform.localEulerAngles.z;

            Debug.Log(angle);

            point = Mathf.CeilToInt((angle + 20) / 40);
            
            Debug.Log(point);

            Status status = GameObject.Find("status").GetComponent<Status>();

            status.okane += point * 1000;


            GameObject.Find("Text").GetComponent<Text>().text = (point * 1000 +("GEMをGET!!")).ToString();
            GetComponent<AudioSource>().PlayOneShot(sound2);
        }


    }
}
