
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Eirianseizouki : Charactor {
    private int hp = 1000;
    private int kougeki = 100;
    private int speed = 100;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "エイリアン無限製造機";
    private Type type = Type.AKU;

    private JumonType jumonType;
    private int hachimaki = 2;


    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.KOSYOU);
        jumonTypeList.Add(JumonType.GOUGOGOUN);
        jumonTypeList.Add(JumonType.APPUDETO);
        jumonTypeList.Add(JumonType.KODAIHEIKI);

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

    async void msg(string msg) {
        GameObject.Find("ButtleMsgText").GetComponent<UnityEngine.UI.Text>().text = msg;
        await System.Threading.Tasks.Task.Delay(1500);
    }

    async override public System.Threading.Tasks.Task kougekimae(Action a) {

        this.jumonType = a.getJumonType();

    }
    async override public Task kougekiato(Action a) {
        if (a.getJumonType() == JumonType.KOSYOU) {
            this.damage(44444);
            this.msg(name + " は破壊力が高すぎる超絶神大爆発で自分までダメージを食らった!");
        }
    }
    }
