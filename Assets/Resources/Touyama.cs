using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touyama : Charactor {
    private int hp = 1020;
    private int kougeki = 1500;
    private int speed = 700;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "とうやま";
    private Type type = Type.HIKARI;


    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.KYOUUN);
        jumonTypeList.Add(JumonType.HAGE);
        jumonTypeList.Add(JumonType.DOUSIYO);
        jumonTypeList.Add(JumonType.KAMITUKU);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name);
    }

    // Update is called once per frame
    void Update() {

    }
    override public bool damage(int damage) {
        bool isDead = base.damage(damage);
        if (isDead) {
            return false;
        } else {
            msg("な、な、なんと!! " + name + " の石頭が攻撃を吸収した！!");
            base.damage(-3000);
        }
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

