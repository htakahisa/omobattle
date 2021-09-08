using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tamago : Charactor {

    private int hp = 5555;
    private int kougeki = 555;
    private int speed = 5555;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "卵";
    private Type type = Type.HUTUU;
    private int hachimaki = 2;
    private int bakenokawa = 1;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.TABERARERU);
        jumonTypeList.Add(JumonType.KAMITUKU);
        jumonTypeList.Add(JumonType.GOUGOGOUN);
        jumonTypeList.Add(JumonType.OMOIIPPATU);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name);
    }
    override public bool damage(int damage) {

        Status status = GameObject.Find("status").GetComponent<Status>();


        if (this.bakenokawa > 0) {
            msg(name + " の化けの皮が身代わりになり、化けの皮がはがれた!");

            this.bakenokawa--;
            return false;
        } else {


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
}
