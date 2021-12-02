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

        BattleAction ba = GameObject.Find("battleAction").GetComponent<BattleAction>();
        ba.wazaId = this.wazaId;


    }






}
