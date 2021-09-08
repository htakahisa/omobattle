using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Kakuseinokamisama : Charactor {

    private int hp = 44444;
    private int kougeki = 4444;
    private int speed = 4;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "覚醒の神様";
    private Type type = Type.DENSETU;
    private int hachimaki = 1;
    private int bakenokawa = 2;
    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.DENSETUNOIKAZUTI);
        jumonTypeList.Add(JumonType.GOUGOUGOUGOGOUN);
        jumonTypeList.Add(JumonType.KAMINOKAMI);
        jumonTypeList.Add(JumonType.HOROBI);

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
     async override public Task kougekiato(Action a) {
        if (a.getJumonType() == JumonType.HOROBI) {
            this.msg(name + " は破壊力が高すぎる超絶神大爆発で自分までダメージを食らった!");
            this.damage(50000);
            this.damage(50000);
            this.damage(50000);
            this.damage(50000);
            this.damage(50000);
            this.damage(50000);
        }
    }




}




    

