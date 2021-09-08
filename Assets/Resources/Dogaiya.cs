using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dogaiya : Charactor {

    private int hp = 7777;
    private int kougeki = 1000;
    private int speed = 40;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "ドガイヤ";
    private int hachimaki = 1;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.BIMU);
        jumonTypeList.Add(JumonType.KODAIHEIKI);
        jumonTypeList.Add(JumonType.ATAIRU);
        jumonTypeList.Add(JumonType.APPUDETO);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name);
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

