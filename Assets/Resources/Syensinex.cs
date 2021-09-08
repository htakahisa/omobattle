using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Syensinex : Charactor {

    private int hp = 19700;
    private int kougeki = 1000;
    private int speed = 10000;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "シェンシンEX";
    private Type type = Type.DENSETU;

    private int bakenokawa = 3;
    
    void Start() {

        jumonTypeList.Add(JumonType.DENSETUNOIKAZUTI);
        jumonTypeList.Add(JumonType.GOUGOUGOUGOGOUN);
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
