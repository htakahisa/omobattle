﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("roomId");
        PlayerPrefs.DeleteKey("choose");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
