using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaburiasu : Charactor {
    private int hp = 4700;
    private int kougeki = 2730;
    private int speed = 35700;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "ガブリアス";
    private Type type = Type.HIKOU;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.DORAGONASUKU);
        jumonTypeList.Add(JumonType.GOUGOGOUN);
        jumonTypeList.Add(JumonType.KAMITUKU);
        jumonTypeList.Add(JumonType.HANEYASUME);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name, this.type);
    }

    // Update is called once per frame
    void Update() {

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

