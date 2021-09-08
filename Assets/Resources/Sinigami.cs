using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Sinigami : Charactor {
    private int hp = 200;
    private int kougeki = 1900;
    private int speed = 1000;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "死神";
    private Type type = Type.AKU;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.MITIZURE);
        jumonTypeList.Add(JumonType.SINIGAMINOKAMA);
        jumonTypeList.Add(JumonType.KAMITUKU);
        jumonTypeList.Add(JumonType.GOUGOGOUN);

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

