﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fensiruteiounosugata : Charactor {

    private int hp = 5700;
    private int kougeki = 330;
    private int speed = 250;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "フェンシル(帝王の姿)";
    private Type type = Type.HIKARI;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.HOWAITOSIRU);
        jumonTypeList.Add(JumonType.GOUGOGOUN);
        jumonTypeList.Add(JumonType.ANKOKUU);
        jumonTypeList.Add(JumonType.SOUZOU);

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
