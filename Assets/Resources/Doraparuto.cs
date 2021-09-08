using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doraparuto : Charactor {

    private int hp = 3333;
    private int kougeki = 1900;
    private int speed = 19000;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "ドラパルト";
    private Type type = Type.HONOO;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.BEAATAKKU);
        jumonTypeList.Add(JumonType.GOUGOGOUN);
        jumonTypeList.Add(JumonType.OIKAZE);
        jumonTypeList.Add(JumonType.KAGEUTI);

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
