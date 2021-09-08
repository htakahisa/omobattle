using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaguOsupng : Charactor {

    private int hp = 9999;
    private int kougeki = 2220;
    private int speed = 40;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "メタグオスプン";
    private Type type = Type.ZIMEN;
    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.ZISIN);
        jumonTypeList.Add(JumonType.APPUDETO);
        jumonTypeList.Add(JumonType.GOUN);
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

