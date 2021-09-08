using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatimaki : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void tasuki() {
        Status status = GameObject.Find("status").GetComponent<Status>();
        status.tasuki += 1;
        GameObject.Find("tasuki").SetActive(false);
    }

    }
