using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oratto : Charactor {
    private int hp = 8100;
    private int kougeki = 1090;
    private int speed = 30;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "おらった";
    private Type type = Type.AKU;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.KAMITUKU);
        jumonTypeList.Add(JumonType.TABERU);
        jumonTypeList.Add(JumonType.KURION);
        jumonTypeList.Add(JumonType.GOUGOGOUN);

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


