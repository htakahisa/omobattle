using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eriasu : Charactor {

    private int hp = 25000;
    private int kougeki = 1000;
    private int speed = 1000;
    private List<JumonType> jumonTypeList = new List<JumonType>();
    private string name = "エリアス";
    private Type type = Type.DENKI;
    public int toDeath = 1;
    public int toModoru = 1;
    private int bakenokawa = 1;

    // Start is called before the first frame update
    void Start() {

        jumonTypeList.Add(JumonType.FAIYAZAREKUSSU);
        jumonTypeList.Add(JumonType.EIRIANSUTORAIKU);
        jumonTypeList.Add(JumonType.PURIZUMASAFAIA);
        jumonTypeList.Add(JumonType.BURIRIANTOKAKUTERU);

        // 設定
        init(this.hp, this.kougeki, this.speed, this.jumonTypeList, this.name);
    }
    override public bool damage(int damage) {


        if (this.bakenokawa > 0) {
            msg(name + " の化けの皮が身代わりになり、化けの皮がはがれた!");

            this.bakenokawa--;
            return false;
        } else {
            return base.damage(damage);
        }

    }
    async override public void tuikaEnd() {


        if (toDeath-- <= 0) {

            if (hp >= 0) {
                this.damage(1000);
                GameObject.Find("ButtleMsgText").GetComponent<UnityEngine.UI.Text>().text = name + "は命を削ってフォルムチェンジした!";

                jumonTypeList.Remove(JumonType.FAIYAZAREKUSSU);
                jumonTypeList.Remove(JumonType.EIRIANSUTORAIKU);
                jumonTypeList.Remove(JumonType.PURIZUMASAFAIA);
                jumonTypeList.Remove(JumonType.BURIRIANTOKAKUTERU);
                jumonTypeList.Add(JumonType.FAIYAZAREKUSSUex);
                jumonTypeList.Add(JumonType.EIRIANSUTORAIKUex);
                jumonTypeList.Add(JumonType.PURIZUMASAFAIAex);
                jumonTypeList.Add(JumonType.BURIRIANTOKAKUTERUex);
                toDeath = 1;
                toModoru = 1;
            }
        }
        if (toModoru-- <= 0) {
            GameObject.Find("ButtleMsgText").GetComponent<UnityEngine.UI.Text>().text = name + "は元に戻った!";
            jumonTypeList.Remove(JumonType.FAIYAZAREKUSSUex);
            jumonTypeList.Remove(JumonType.EIRIANSUTORAIKUex);
            jumonTypeList.Remove(JumonType.PURIZUMASAFAIAex);
            jumonTypeList.Remove(JumonType.BURIRIANTOKAKUTERUex);
            jumonTypeList.Add(JumonType.FAIYAZAREKUSSU);
            jumonTypeList.Add(JumonType.EIRIANSUTORAIKU);
            jumonTypeList.Add(JumonType.PURIZUMASAFAIA);
            jumonTypeList.Add(JumonType.BURIRIANTOKAKUTERU);
            toDeath = 1;
            toModoru = 1;

        }
    }
}
