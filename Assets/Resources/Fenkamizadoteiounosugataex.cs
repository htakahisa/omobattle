using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fenkamizadoteiounosugataex : Charactor {

    private int hp = 13000;
    private int kougeki = 2222;
    private int speed = 15000;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "フェ・ン・神ーザ(黄昏の姿)";
    private Type type = Type.DENKI;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.SPAMD);
        jumonTypeList.Add(JumonType.GOUGOUGOUGOGOUN);
        jumonTypeList.Add(JumonType.HOWAKKUZUTIEX);
        jumonTypeList.Add(JumonType.SOUZOUSOSITEHAKAISOSITEIKAZUTIEX);

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
