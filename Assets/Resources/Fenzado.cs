using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fenzado : Charactor {

    private int hp = 4700;
    private int kougeki = 200;
    private int speed = 50;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "フェ・ン・ザード(黄昏の姿)";
    private Type type = Type.HONOO;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.RYUNOIBUKI);
        jumonTypeList.Add(JumonType.GOUGOGOUN);
        jumonTypeList.Add(JumonType.DORAGONSTAR);
        jumonTypeList.Add(JumonType.ANKOKUU);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name);
    }
    override public bool damage(int damage) {
        bool isDead = base.damage(damage);
        Status status = GameObject.Find("status").GetComponent<Status>();
        if (isDead && status.tasuki > 0) {
            base.damage(this.getHp() - 1);
            msg("な、な、なんと!! " + name + " は頑張ってこらえた!");
            status.tasuki--;
            return false;
        } else {
            return isDead;
        }
    }
}
