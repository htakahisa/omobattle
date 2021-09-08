using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamisamatyottohonki : Charactor {

    private int hp = 142222;
    private int kougeki = 500;
    private int speed = 80;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "ちょっと本気の神様";
    private Type type = Type.HIKARI;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.IKAZUTI);
        jumonTypeList.Add(JumonType.GOUGOUGOUGOGOUN);
        jumonTypeList.Add(JumonType.WARAWASERU);
        jumonTypeList.Add(JumonType.BEASUTORAIKU);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name);
    }
}
