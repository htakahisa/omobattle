using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Action
{

    private Charactor from;
    private Charactor to;

    private KougekiType kougekiType;

    private JumonType jumonType;

    private Text fromHpText;
    private Text toHpText;

    private Slider fromHpSlider;
    private Slider toHpSlider;

    private Button fromBtn;
    private Button toBtn;


    // 優先度
    private int priority = 0;



    public static Action of(Charactor from, Charactor to,
        Text fromHpText, Text toHpText,
        Slider fromHpSlider, Slider toHpSlider,
        Button fromBtn, Button toBtn,
        KougekiType kougekiType, JumonType jumonType, int priority) {

            Action a = new Action();
            a.from = from;
            a.to = to;
            a.kougekiType = kougekiType;
            a.jumonType = jumonType;

            a.fromHpText = fromHpText;
            a.toHpText = toHpText;

            a.fromHpSlider = fromHpSlider;
            a.toHpSlider = toHpSlider;
            a.fromBtn = fromBtn;
            a.toBtn = toBtn;
            a.priority = priority;
            return a;
    }

    public Slider getFromHpSlider() {
        return this.fromHpSlider;
    }
    public Slider getToHpSlider() {
        return this.toHpSlider;
    }


    public int getPriority() {
        return this.priority;
    }


    public Button getFromBtn() {
        return this.fromBtn;
    }
    public Button getToBtn() {
        return this.toBtn;
    }
    public Charactor getFrom() {
        return this.from;
    }
    public Charactor getTo() {
        return this.to;
    }
    public Text getFromHpText() {
        return this.fromHpText;
    }
    public Text getToHpText() {
        return this.toHpText;
    }

    public int getSpeed() {
        return from.getSpeed();
    }

    public KougekiType getKougekiType() {
        return this.kougekiType;
    }
    public void setKougekiType(KougekiType k) {
        this.kougekiType = k;
    }
    public JumonType getJumonType() {
        return this.jumonType;

    }

    public void setJumonType(JumonType jumonType) {
        this.jumonType = jumonType;
    }


    async public void tuika() {

        if (JumonType.HAGE == getJumonType()) {
            getTo().plusKougeki(-(int)(getTo().getKougeki() * 0.1f));
            GameObject.Find("ButtleMsgText").GetComponent<Text>().text = 
                getFrom().getName() + " の攻撃がガクンと下がった!";
            await System.Threading.Tasks.Task.Delay(1000);
        }

        if (JumonType.HOWAKKUZUTI == getJumonType()) {
            getTo().plusKougeki((int)(getTo().getKougeki() * 2f));
            GameObject.Find("ButtleMsgText").GetComponent<Text>().text =
                getFrom().getName() + " の攻撃がグングンと上がった!";
            await System.Threading.Tasks.Task.Delay(1000);
        }

    }

    async public void tuikaEnd() {
        this.getFrom().tuikaEnd();
    }

}
