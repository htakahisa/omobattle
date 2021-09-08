using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamisamahonkiex : Charactor {

    private int hp = 25000;
    private int kougeki = 2000;
    private int speed = 9000;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "神様本気EX";
    private Type type = Type.DENSETU;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.DORAGONSTAR);
        jumonTypeList.Add(JumonType.GOUGOUGOUGOGOUN);
        jumonTypeList.Add(JumonType.SPAMD);
        jumonTypeList.Add(JumonType.RYUNOIBUKI);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name, this.type);
    }
}
