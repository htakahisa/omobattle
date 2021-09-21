using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WazaButton : MonoBehaviour
{

    private string wazaId;
    private string wazaName;





    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void setWaza(string wazaId) {


        this.wazaId = wazaId;
    }

    public void select() {

        Battle battle = GameObject.Find("battle").GetComponent<Battle>();
        battle.waza = this.wazaId;

    }






}
