using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Komoo : Charactor {
    private int hp = 8800;
    private int kougeki = 3770;
    private int speed = 5000;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "こもお";
    private Type type = Type.AKU;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.KAGEUTI);
        jumonTypeList.Add(JumonType.GOUGOGOUN);
        jumonTypeList.Add(JumonType.KURION);
        jumonTypeList.Add(JumonType.ANKOKUU);

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

