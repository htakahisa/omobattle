using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detabo : Charactor {

    private int hp = 6960;
    private int kougeki = 70;
    private int speed = 40;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "デタボ";
    private Type type = Type.DENKI;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.APPUDETO);
        jumonTypeList.Add(JumonType.KODAIHEIKI);
        jumonTypeList.Add(JumonType.ATAIRU);
        jumonTypeList.Add(JumonType.KURION);

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
