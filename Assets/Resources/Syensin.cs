using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syensin : Charactor {

    private int hp = 18753;
    private int kougeki = 888;
    private int speed = 8888;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "シェンシン";
    private Type type = Type.DENSETU;
    
    private int bakenokawa = 1;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.DENSETUNOIKAZUTI);
        jumonTypeList.Add(JumonType.BEAATAKKU);
        jumonTypeList.Add(JumonType.GOUGOUGOUGOGOUN);
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
