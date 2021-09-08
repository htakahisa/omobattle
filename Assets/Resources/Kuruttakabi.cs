using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kuruttakabi : Charactor {
    private int hp = 29000;
    private int kougeki = 500;
    private int speed = 1900;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "狂ったカービィ";
    private Type type = Type.AKU;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.TABERU);
        jumonTypeList.Add(JumonType.GOUGOGOUN);
        jumonTypeList.Add(JumonType.KURION);
        jumonTypeList.Add(JumonType.KYOURANSYOKUZI);

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

