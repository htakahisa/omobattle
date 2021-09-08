using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panatorios : Charactor {
    private int hp = 9999;
    private int kougeki = 555;
    private int speed = 555;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "パナトリオ";
    private Type type = Type.HIKARI;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.PAINAPPURU);
        jumonTypeList.Add(JumonType.SIZENKAIHUKU);
        jumonTypeList.Add(JumonType.HURENDO);
        jumonTypeList.Add(JumonType.ZISIN);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name);
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

