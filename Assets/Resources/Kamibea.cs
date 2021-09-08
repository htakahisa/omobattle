using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamibea : Charactor {

    private int hp = 1000;
    private int kougeki = 43500;
    private int speed = 100;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "サイコデル";
    private Type type = Type.DENSETU;

    private int bakenokawa = 1;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.DENSETUNOIKAZUTI);
        jumonTypeList.Add(JumonType.HAKAI);
        jumonTypeList.Add(JumonType.HAKAI);
        jumonTypeList.Add(JumonType.DORAGONSTAR);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name);
    }
    override public bool damage(int damage) {


        if (this.bakenokawa > 0) {
            msg(name + " の化けの皮が身代わりになり、化けの皮がはがれた!");

            this.bakenokawa--;
            return false;
        } else {
            return base.damage(damage);
        }

    }
}
