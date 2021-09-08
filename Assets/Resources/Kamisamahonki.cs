using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamisamahonki : Charactor {

    private int hp = 44444;
    private int kougeki = 444;
    private int speed = 44;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "本気の神様";
    private Type type = Type.DENSETU;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.DENSETUNOIKAZUTI);
        jumonTypeList.Add(JumonType.GOUGOUGOUGOGOUN);
        jumonTypeList.Add(JumonType.KAMINOKAMI);
        jumonTypeList.Add(JumonType.BEASUTORAIKU);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name, this.type);
    }
}
