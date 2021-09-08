using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Akuzado : Charactor {

    private int hp = 6500;
    private int kougeki = 230;
    private int speed = 1350;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "アクザード";
    private Type type = Type.AKU;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.BURAKKUZADO);
        jumonTypeList.Add(JumonType.GOUGOGOUN);
        jumonTypeList.Add(JumonType.ANKOKUU);
        jumonTypeList.Add(JumonType.KODAIHEIKI);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name, this.type);
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
