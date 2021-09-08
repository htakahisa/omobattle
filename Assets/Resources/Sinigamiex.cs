using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinigamiex : Charactor {
    private int hp = 10000;
    private int kougeki = 5;
    private int speed = 500;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "死神EX";
    private Type type = Type.AKU;

    public int toDeath = 1;
    public int toModoru = 1;


    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.PANTI);
        jumonTypeList.Add(JumonType.PANTI);
        jumonTypeList.Add(JumonType.PANTI);
        jumonTypeList.Add(JumonType.PANTI);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name);
    }

    // Update is called once per frame
    void Update() {
        
      
        
        
    }

    

        async override public void tuikaEnd() {


        if (toDeath-- <= 0 ) {

            if (hp >= 0) { 
                this.damage(this.getHp() - 1);
                GameObject.Find("ButtleMsgText").GetComponent<UnityEngine.UI.Text>().text = name + "は命を削ってフォルムチェンジした!";

                jumonTypeList.Remove(JumonType.PANTI);
                jumonTypeList.Remove(JumonType.PANTI);
                jumonTypeList.Remove(JumonType.PANTI);
                jumonTypeList.Remove(JumonType.PANTI);
                jumonTypeList.Add(JumonType.DENSETUNOSINIGAMINOKAMA);
                jumonTypeList.Add(JumonType.DENSETUNOSINIGAMINOKAMA);
                jumonTypeList.Add(JumonType.DENSETUNOSINIGAMINOKAMA);
                jumonTypeList.Add(JumonType.DENSETUNOSINIGAMINOKAMA);
                toDeath = 1;
                toModoru = 1;
            }
        }
        if(toModoru-- <= 0) {
            GameObject.Find("ButtleMsgText").GetComponent<UnityEngine.UI.Text>().text = name + "は元に戻った!";
            jumonTypeList.Remove(JumonType.DENSETUNOSINIGAMINOKAMA);
            jumonTypeList.Remove(JumonType.DENSETUNOSINIGAMINOKAMA);
            jumonTypeList.Remove(JumonType.DENSETUNOSINIGAMINOKAMA);
            jumonTypeList.Remove(JumonType.DENSETUNOSINIGAMINOKAMA);
            jumonTypeList.Add(JumonType.PANTI);
            jumonTypeList.Add(JumonType.PANTI);
            jumonTypeList.Add(JumonType.PANTI);
            jumonTypeList.Add(JumonType.PANTI);
            toDeath = 1;
            toModoru = 1;

        }
        
        
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

