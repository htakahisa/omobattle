using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mudai : Charactor {
    private int hp = 20000;
    private int kougeki = 200;
    private int speed = 80;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "無題";

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.ANKOKUU);
        jumonTypeList.Add(JumonType.WARAWASERU);
        jumonTypeList.Add(JumonType.GOUN);
        jumonTypeList.Add(JumonType.KURION);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name);
    }

    // Update is called once per frame
    void Update() {


    }
}
