
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kyourannotouyama : Charactor {
    private int hp = 4610;
    private int kougeki = 2020;
    private int speed = 60;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "狂乱のとうやま";
    private Type type = Type.AKU;


    private int hachimaki = 1;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.KYOUUN);
        jumonTypeList.Add(JumonType.GOUGOGOUN);
        jumonTypeList.Add(JumonType.GATIDEDOUSIYO);
        jumonTypeList.Add(JumonType.KAMITUKU);

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

    async void msg() {
         GameObject.Find("ButtleMsgText").GetComponent<UnityEngine.UI.Text>().text = "な、な、なんと!! " + name + " は頑張ってこらえた!";
        await System.Threading.Tasks.Task.Delay(1500);
    }
}
