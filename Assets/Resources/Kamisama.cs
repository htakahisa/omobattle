using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamisama : Charactor {

    private int hp = 7350;
    private int kougeki = 350;
    private int speed = 80;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "神様";
    private Type type = Type.HIKARI;
    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.GOUGOUGOUGOGOUN);
        jumonTypeList.Add(JumonType.WARAWASERU);
        jumonTypeList.Add(JumonType.TENBATU);
        jumonTypeList.Add(JumonType.KAMIWONAGAKUSURU);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name);
    }
}
