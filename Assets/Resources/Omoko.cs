using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Omoko : Charactor {
    private int hp = 8700;
    private int kougeki = 1500;
    private int speed = 5000;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "おもこ";
    private Type type = Type.HIKOU;
    private int hachimaki = 1;
    private int yoketa = 0;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.WARAWASERU);
        jumonTypeList.Add(JumonType.YUBUWOHURU);
        jumonTypeList.Add(JumonType.KAMITUKU);
        jumonTypeList.Add(JumonType.GOUN);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name);
    }

    // Update is called once per frame
    void Update() {

    }
    override public bool damage(int damage) {
        
        this.yoketa = 0;


        if (UnityEngine.Random.Range(0, 2) == 1) {
            msg(name + " はひらりと身をかわした。");
            this.yoketa = 1;
            return false;
           
        }
        if (UnityEngine.Random.Range(0, 5) == 1) {
            msg(name + " は相手の攻撃を吸収した！");


            if ((getHp() + 10000) > getMaxHp()) {
                base.damage(getMaxHp() - getHp());
            } else {

                base.damage(-10000);
            }
            return false;
        }




        Status status = GameObject.Find("status").GetComponent<Status>();


        bool isDead = base.damage(damage);
        int random = UnityEngine.Random.Range(0, 2);
        if (isDead && random == 1) {
            base.damage(this.getHp() - 1);
            msg("な、な、なんと!! " + name + " は頑張ってこらえた!");
            hachimaki--;

            return false;
        }

        
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

    public int getYoketa() {
        return yoketa;
    }
}


