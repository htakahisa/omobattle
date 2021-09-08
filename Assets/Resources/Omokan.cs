using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Omokan : Charactor {

    private int hp = 12345;
    private int kougeki = 1234;
    private int speed = 1234;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "おもかん";
    private Type type = Type.DENSETU;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.DORAGONSTAR);
        jumonTypeList.Add(JumonType.GOUGOGOUN);
        jumonTypeList.Add(JumonType.SPAMD);
        jumonTypeList.Add(JumonType.RYUNOIBUKI);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name, this.type);
    }
}
