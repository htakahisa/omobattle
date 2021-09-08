using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public static Status singleton;


    public int mapStep = 0;

    public int map2Step = 0;

    public int map3Step = 0;

    public int map4Step = 0;

    public GameMode gameMode;

    public bool mapStage3;
    public bool map2Stage3;
    public bool map3Stage3;
    public bool map4Stage3;

    public int stage = 1;


    public float level = 0;

    public int katta = 1;
   
    // お金
    public int okane = 500;
    public int tasuki;

    // kimetaList
    public List<string> kimetaList = new List<string>();

    // item list
    public List<ItemType> itemList = new List<ItemType>();


    public List<string> kattaList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        kattaList.Add("arosu");
        kattaList.Add("dotto");
        kattaList.Add("kiramepisu");
        kattaList.Add("kubiiruex");
        kattaList.Add("kurin");
        kattaList.Add("omokyura");
        kattaList.Add("oratto");
        kattaList.Add("siyigami");
        kattaList.Add("sutari");
        kattaList.Add("amayuo");
        kattaList.Add("touyama");
        kattaList.Add("raimugen");
        kattaList.Add("detabo");
        kattaList.Add("panappu");
        kattaList.Add("panatorios");
        kattaList.Add("panakonbis");
        kattaList.Add("kesigo");
        kattaList.Add("fenzado");
        kattaList.Add("zaiyadaikon");
        kattaList.Add("mahokko");
        kattaList.Add("dekakao");
        kattaList.Add("kubiiruEX");
        kattaList.Add("sekyuritelisisutemu");
        kattaList.Add("kubiiru");
        kattaList.Add("omoko");
        kattaList.Add("tarabeko");
        kattaList.Add("togerin");
        kattaList.Add("uzaou");
        kattaList.Add("syensinEX");
        kattaList.Add("itadori");
        kattaList.Add("babiron");
       

    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void Awake() {
        //　スクリプトが設定されていなければゲームオブジェクトを残しつつスクリプトを設定
        if (singleton == null) {
            DontDestroyOnLoad(gameObject);
            singleton = this;
            //　既にGameStartスクリプトがあればこのシーンの同じゲームオブジェクトを削除
        } else {
            Destroy(gameObject);
        }
    }
    
}


public enum GameMode {
    BATTLE,
    DAIMAX,
    DAIMAX2,
    DAIMAX3,
    DAIMAX4,
    SUTEGI1,

}