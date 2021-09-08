using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kaitoku : MonoBehaviour
{

    Text okane;

    // Start is called before the first frame update
    void Start()
    {
        okane = GameObject.Find("okane").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        Status status = GameObject.Find("status").GetComponent<Status>();


        okane.text = status.okane + " 円";
    }
}
