using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amayuo : Charactor {
    private int hp = 6000;
    private int kougeki = 320;
    private int speed = 90;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "アマユオ";
    private Type type = Type.AKU;
    private int hachimaki = 2;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.KAMITUKU);
        jumonTypeList.Add(JumonType.KYUUKETU);
        jumonTypeList.Add(JumonType.GOUN);
        jumonTypeList.Add(JumonType.KURION);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name);
    }

    // Update is called once per frame
    override public bool damage(int damage) {
        Status status = GameObject.Find("status").GetComponent<Status>();

        bool isDead = base.damage(damage);

        if (isDead && hachimaki > 0) {
            base.damage(this.getHp() - 1);
            msg();
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
