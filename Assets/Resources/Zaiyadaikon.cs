using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zaiyadaikon : Charactor {
    private int hp = 8900;
    private int kougeki = 1870;
    private int speed = 50;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "ザイヤダイコン";
    private Type type = Type.AKU;
    private int hachimaki = 1;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.DAIKONWONUKU);
        jumonTypeList.Add(JumonType.TABERARERU);
        jumonTypeList.Add(JumonType.SIZENKAIHUKU);
        jumonTypeList.Add(JumonType.HURENDO);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name);
    }

    // Update is called once per frame
    void Update() {

    }
    override public bool damage(int damage) {
        Status status = GameObject.Find("status").GetComponent<Status>();




        bool isDead = base.damage(damage);

        if (isDead && hachimaki > 0) {
            base.damage(this.getHp() - 1);
            msg("な、な、なんと!! " + name + " は頑張ってこらえた!");
            hachimaki--;

            return false;
        }
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

