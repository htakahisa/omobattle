using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SutariEX : Charactor {

    private int hp = 7777;
    private int kougeki = 777;
    private int speed = 777;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "スターリEX";
    private Type type = Type.HIKARI;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.HIKARU);
        jumonTypeList.Add(JumonType.SIZENKAIHUKU);
        jumonTypeList.Add(JumonType.GOUN);
        jumonTypeList.Add(JumonType.TABERU);

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
