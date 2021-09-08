using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fenzadoteiounosugata : Charactor {

    private int hp = 8700;
    private int kougeki = 3880;
    private int speed = 350;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "フェ・ン・ザード(極めて強い帝王の姿)";
    private Type type = Type.HONOO;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.HOWAKKUSIZA);
        jumonTypeList.Add(JumonType.GOUGOGOUN);
        jumonTypeList.Add(JumonType.ANKOKUU);
        jumonTypeList.Add(JumonType.SOUZOUSOSITEHAKAI);

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
