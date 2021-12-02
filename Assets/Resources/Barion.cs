using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Barion : Charactor {

    private int hp = 38500;
    private int kougeki = 13500;
    private int speed = 1000;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "ヴァリオン";
    private Type type = Type.DENSETU;

    private int bakenokawa = 1;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.HORORORO);
        jumonTypeList.Add(JumonType.SECRETTHEPERFECT);
        jumonTypeList.Add(JumonType.RUGAN);
        jumonTypeList.Add(JumonType.SPAMD);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name);
    }
    override public bool damage(int damage) {


        if (this.bakenokawa > 0) {
            msg(name + " の化けの皮が身代わりになり、攻撃力が上がった！");
            this.kougeki += 10000;

            this.bakenokawa--;
            return false;
        } else {
            return base.damage(damage);
        }

       

    }
    async override public Task kougekiato(Action a) {
        if (a.getJumonType() == JumonType.HORORORO) {
            this.msg(name + " は地球ごと燃やし尽くしたせいで、自分もダメージを食らった！!");
            this.damage(6233);
            this.damage(6233);
            this.damage(6233);
            this.bakenokawa += 2;
            this.msg(name + " は起死回生で化けの皮が2枚追加した！");

        }
    }
}
