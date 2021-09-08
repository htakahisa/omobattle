﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kurin : Charactor {
    private int hp = 7777;
    private int kougeki = 1000;
    private int speed = 50;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "クリーン";
    private Type type = Type.ZIMEN;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.SIZENKAIHUKU);
        jumonTypeList.Add(JumonType.TABERARERU);
        jumonTypeList.Add(JumonType.ZISIN);
        jumonTypeList.Add(JumonType.KURION);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name);
    }

    // Update is called once per frame
    void Update() { }

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


