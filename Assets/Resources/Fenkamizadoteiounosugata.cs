using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fenkamizadoteiounosugata : Charactor {

    private int hp = 25000;
    private int kougeki = 7385;
    private int speed = 350;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "フェ・ン・神ーザ";
    private Type type = Type.HONOO;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.SPAMD);
        jumonTypeList.Add(JumonType.GOUGOUGOUGOGOUN);
        jumonTypeList.Add(JumonType.HOWAKKUZUTI);
        jumonTypeList.Add(JumonType.SOUZOUSOSITEHAKAISOSITEIKAZUTI);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name);
    }
}
