using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Kantoku : MonoBehaviour {

 

    private GameObject mikataButton;
    private Button button0;
    private Button button1;
    private Button button2;
    private Button button3;

    private Button button5;
    private Button button6;
    private Button button7;
    private Button button8;

    private Button button9;

    // 1. キャラクター
    private GameObject amayuo;
    private GameObject metaguOsupng;
    private GameObject omoko;
    private GameObject komoo;
    private GameObject kubiiru;
    private GameObject detabo;
    private GameObject touyama;
    private GameObject okan;
    private GameObject nekokanwohakkensitaneko;
    private GameObject togerin;
    private GameObject omokyura;
    private GameObject kesigo;
    private GameObject dotto;
    private GameObject dogaiya;
    private GameObject fensiru;
    private GameObject akuzado;
    private GameObject mahokko;
    private GameObject raimugen;
    private GameObject sinigami;
    private GameObject gaburiasu;
    private GameObject sinigamiex;
    private GameObject fenkamizadoteiounosugata;
    private GameObject kubiiruex;
    private GameObject arosu;
    private GameObject oratto;
    private GameObject kagemouta;
    private GameObject kyourankotouyama;
    private GameObject mudai;
    private GameObject kamisama;
    private GameObject fenzado;
    private GameObject akuzadoakunoteiounosugata;
    private GameObject fensiruteiounosugata;
    private GameObject tyottohonkinokamisama;
    private GameObject fenzadoteiounosugata;
    private GameObject kamisamahonki;
    private GameObject fenkamizadoteiounosugataex;
    private GameObject sekyuritelisisutemu;
    private GameObject zaiyadaikon;
    private GameObject sutari;
    private GameObject sutariEX;
    private GameObject panappu;
    private GameObject panakonbis;
    private GameObject panatorios;
    private GameObject uzayama;
    private GameObject kurin;
    private GameObject kiramepisu;
    private GameObject tarabeko;
    private GameObject neko;
    private GameObject doraparuto;
    private GameObject eirianseizouki;
    private GameObject tamago;
    private GameObject tamagoumareta;
    private GameObject syensin;
    private GameObject syensinex;
    private GameObject kamisamahonkiex;
    private GameObject omokan;
    private GameObject kamibea;
    private GameObject eriasu;
    private GameObject kuruttakabi;
    private GameObject itadori;
    private GameObject babiron;

    List<GameObject> charactorList = new List<GameObject>();

    public InputField inputField;

    // command
    GameObject command;
    GameObject command2;

    // 選択されているキャラクター
    private Charactor teki;
    private Charactor mikata;

    // 選択されているbutton
    private Button tekiBtn;
    private Button mikataBtn;

    private bool isReadyMikata;
    private bool isReadyTeki;

    // 戦闘中は true
    private bool isBattle;

    private bool isButtonActive;

    // 交代中は true
    private bool isChange;


    private Text hpMikataText;
    private Text hpTekiText;


    // 戦闘メッセージ
    private GameObject buttleMsg;

    private JumonTypeMapper jm = new JumonTypeMapper();
    private WazaType wazaType = new WazaType();
    private Dictionary<string, Charactor> charactorDic = new Dictionary<string, Charactor>();

    private GameMode gameMode;

    // HPバー
    private Slider tekiHpSlider;
    private Slider mikataHpSlider;





    // Start is called before the first frame update
    void Start() {



        // マウスを真ん中でロックする
        Cursor.lockState = CursorLockMode.None;

        // モード選択
        Status status = GameObject.Find("status").GetComponent<Status>();
        gameMode = status.gameMode;

        tekiHpSlider = GameObject.Find("tekiHpSlider").GetComponent<Slider>();
        mikataHpSlider = GameObject.Find("mikataHpSlider").GetComponent<Slider>();

        // カードを初期化
        button0 = GameObject.Find("Button0").GetComponent<Button>();
        button1 = GameObject.Find("Button1").GetComponent<Button>();
        button2 = GameObject.Find("Button2").GetComponent<Button>();
        button3 = GameObject.Find("Button3").GetComponent<Button>();
        button5 = GameObject.Find("Button5").GetComponent<Button>();
        button6 = GameObject.Find("Button6").GetComponent<Button>();
        button7 = GameObject.Find("Button7").GetComponent<Button>();
        button8 = GameObject.Find("Button8").GetComponent<Button>();
        button9 = GameObject.Find("Button9").GetComponent<Button>();


        // HP
        hpMikataText = GameObject.Find("hp").GetComponent<Text>();
        hpTekiText = GameObject.Find("hp2").GetComponent<Text>();

        // 2. プレハブからキャラクター生成  (resource フォルダの下にいる)
        Resources.Load("amayuo");
        Resources.Load("metaguOsupng");
        Resources.Load("omoko");
        Resources.Load("komoo");
        Resources.Load("kubiiru");
        Resources.Load("detabo");
        Resources.Load("touyama");
        Resources.Load("okan");
        Resources.Load("nekokanwohakkensitaneko");
        Resources.Load("kyourankotouyama");
        Resources.Load("mudai");
        Resources.Load("kamisama");
        Resources.Load("dotto");
        Resources.Load("togerin");
        Resources.Load("omokyura");
        Resources.Load("kesigo");
        Resources.Load("dogaiya");
        Resources.Load("fensiru");
        Resources.Load("akuzado");
        Resources.Load("fenzado");
        Resources.Load("fensiruseiginoteiou");
        Resources.Load("Akuzadoakunoteiounosugata");
        Resources.Load("mahokko");
        Resources.Load("tyottohonkinokamisama");
        Resources.Load("sinigami");
        Resources.Load("raimugen");
        Resources.Load("fenzadoteiounosugata");
        Resources.Load("gaburiasu");
        Resources.Load("kamisamahonki");
        Resources.Load("sinigamiex");
        Resources.Load("fenkamizadoteiounosugata");
        Resources.Load("kubiiruex");
        Resources.Load("fenkamizadoteiounosugataex");
        Resources.Load("arosu");
        Resources.Load("oratto");
        Resources.Load("kagemouta");
        Resources.Load("sekyuritelisisutemu");
        Resources.Load("zaiyadaikon");
        Resources.Load("sutari");
        Resources.Load("sutariEX");
        Resources.Load("panappu");
        Resources.Load("panakonbis");
        Resources.Load("panatorios");
        Resources.Load("uzayama");
        Resources.Load("kurin");
        Resources.Load("kiramepisu");
        Resources.Load("tarabeko");
        Resources.Load("neko");
        Resources.Load("doraparuto");
        Resources.Load("eirianseizouki");
        Resources.Load("tamago");
        Resources.Load("tamagoumareta");
        Resources.Load("syensin");
        Resources.Load("syensinex");
        Resources.Load("kamisamahonkiex");
        Resources.Load("omokan");
        Resources.Load("kamibea");
        Resources.Load("eriasu");
        Resources.Load("kuruttakabi");
        Resources.Load("itadori");
        Resources.Load("babiron");

        // 3. 変数に入れる
        amayuo = GameObject.Find("amayuo");
        metaguOsupng = GameObject.Find("metaguOsupng");
        omoko = GameObject.Find("omoko");
        komoo = GameObject.Find("komoo");
        kubiiru = GameObject.Find("kubiiru");
        detabo = GameObject.Find("detabo");
        touyama = GameObject.Find("touyama");
        okan = GameObject.Find("okan");
        nekokanwohakkensitaneko = GameObject.Find("nekokanwohakkensitaneko");
        togerin = GameObject.Find("togerin");
        omokyura = GameObject.Find("omokyura");
        kesigo = GameObject.Find("kesigo");
        dotto = GameObject.Find("dotto");
        dogaiya = GameObject.Find("dogaiya");
        oratto = GameObject.Find("oratto");
        mahokko = GameObject.Find("mahokko");
        sinigami = GameObject.Find("sinigami");
        raimugen = GameObject.Find("raimugen");
        gaburiasu = GameObject.Find("gaburiasu");
        zaiyadaikon = GameObject.Find("zaiyadaikon");
        kyourankotouyama = GameObject.Find("kyourankotouyama");
        mudai = GameObject.Find("mudai");
        kamisama = GameObject.Find("kamisama");
        fenzado = GameObject.Find("fenzado");
        fensiru = GameObject.Find("fensiru");
        akuzado = GameObject.Find("akuzado");
        fensiruteiounosugata = GameObject.Find("fensiruseiginoteiou");
        akuzadoakunoteiounosugata = GameObject.Find("Akuzadoakunoteiounosugata");
        tyottohonkinokamisama = GameObject.Find("tyottohonkinokamisama");
        fenzadoteiounosugata = GameObject.Find("fenzadoteiounosugata");
        kamisamahonki = GameObject.Find("kamisamahonki");
        sinigamiex = GameObject.Find("sinigamiex");
        fenkamizadoteiounosugataex = GameObject.Find("fenkamizadoteiounosugataex");
        fenkamizadoteiounosugata = GameObject.Find("fenkamizadoteiounosugata");
        kubiiruex = GameObject.Find("kubiiruex");
        arosu = GameObject.Find("arosu");
        kagemouta = GameObject.Find("kagemouta");
        sekyuritelisisutemu = GameObject.Find("sekyuritelisisutemu");
        sutari = GameObject.Find("sutari");
        sutariEX = GameObject.Find("sutariEX");
        panappu = GameObject.Find("panappu");
        panakonbis = GameObject.Find("panakonbis");
        panatorios = GameObject.Find("panatorios");
        uzayama = GameObject.Find("uzayama");
        kurin = GameObject.Find("kurin");
        kiramepisu = GameObject.Find("kiramepisu");
        tarabeko = GameObject.Find("tarabeko");
        neko = GameObject.Find("neko");
        doraparuto = GameObject.Find("doraparuto");
        eirianseizouki = GameObject.Find("eirianseizouki");
        tamago = GameObject.Find("tamago");
        tamagoumareta = GameObject.Find("tamagoumareta");
        syensin = GameObject.Find("syensin");
        syensinex = GameObject.Find("syensinex");
        kamisamahonkiex = GameObject.Find("kamisamahonkiex");
        omokan = GameObject.Find("omokan");
        kamibea = GameObject.Find("kamibea");
        eriasu = GameObject.Find("eriasu");
        kuruttakabi = GameObject.Find("kuruttakabi");
        itadori = GameObject.Find("itadori");
        babiron = GameObject.Find("babiron");
        this.tekiMikataSetting();


        // こまんどを消す
        command = GameObject.Find("Command");
        command.SetActive(false);
        command2 = GameObject.Find("Command2");
        command2.SetActive(false);

        this.buttleMsg = GameObject.Find("ButtleMsg");
        this.buttleMsg.SetActive(false);

        this.tekiwoDasu();
    }

    private void tekiMikataSetting() {



        // 4. リスト作成
        

        if (gameMode != GameMode.SUTEGI1) {

            charactorList.Add(omoko);
            charactorList.Add(touyama);
        }
        if (gameMode == GameMode.BATTLE) {
            charactorList.Add(sinigamiex);

        }
        charactorList.Add(komoo);
        charactorList.Add(metaguOsupng);
        charactorList.Add(kubiiru);
        charactorList.Add(detabo);
        charactorList.Add(okan);
        charactorList.Add(nekokanwohakkensitaneko);
        charactorList.Add(togerin);
        charactorList.Add(omokyura);
        charactorList.Add(kesigo);
        charactorList.Add(dogaiya);
        charactorList.Add(fenzado);
        charactorList.Add(dotto);
        charactorList.Add(mahokko);
        charactorList.Add(sinigami);
        charactorList.Add(amayuo);
        charactorList.Add(gaburiasu);
        charactorList.Add(kubiiruex);
        charactorList.Add(arosu);
        charactorList.Add(fenkamizadoteiounosugataex);
        charactorList.Add(oratto);
        charactorList.Add(kagemouta);
        charactorList.Add(sekyuritelisisutemu);
        charactorList.Add(zaiyadaikon);
        charactorList.Add(sutari);
        charactorList.Add(sutariEX);
        charactorList.Add(panappu);
        charactorList.Add(panakonbis);
        charactorList.Add(panatorios);
        charactorList.Add(uzayama);
        charactorList.Add(kurin);
        charactorList.Add(kiramepisu);
        charactorList.Add(tarabeko);
        charactorList.Add(neko);
        charactorList.Add(akuzadoakunoteiounosugata);
        charactorList.Add(fensiruteiounosugata);
        charactorList.Add(doraparuto);
        charactorList.Add(eirianseizouki);
        charactorList.Add(tamago);
        charactorList.Add(tamagoumareta);
        charactorList.Add(kamibea);
        charactorList.Add(itadori);
        charactorList.Add(babiron);



        Status status = GameObject.Find("status").GetComponent<Status>();



        if (gameMode == GameMode.BATTLE) {


            charactorList.Add(akuzado);
            charactorList.Add(fensiru);


        } else if (gameMode == GameMode.DAIMAX) {
            if (status.mapStage3) {
                charactorList.Add(kyourankotouyama);
                charactorList.Add(dotto);
            }
        }



        // リストをシャッフル
        charactorList = charactorList.OrderBy(charactor => Guid.NewGuid()).ToList();



        // 4.カードに味方を設定
        if (gameMode == GameMode.SUTEGI1) {
            button0.image.sprite = omoko.GetComponent<SpriteRenderer>().sprite;
            charactorDic.Add("Button0", omoko.GetComponent<Charactor>());

            button1.image.sprite = touyama.GetComponent<SpriteRenderer>().sprite;
            charactorDic.Add("Button1", touyama.GetComponent<Charactor>());


            button2.gameObject.SetActive(false);
            button3.gameObject.SetActive(false);

        } else if (gameMode == GameMode.DAIMAX3) {

            if (status.map3Step >= 3) {
                button0.image.sprite = fenkamizadoteiounosugata.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button0", fenkamizadoteiounosugata.GetComponent<Charactor>());
                button1.gameObject.SetActive(false);
                button2.gameObject.SetActive(false);
                button3.gameObject.SetActive(false);
            } else {
                button0.image.sprite = charactorList[0].GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button0", charactorList[0].GetComponent<Charactor>());

                button1.image.sprite = charactorList[1].GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button1", charactorList[1].GetComponent<Charactor>());

                button2.image.sprite = charactorList[2].GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button2", charactorList[2].GetComponent<Charactor>());

                button3.image.sprite = charactorList[3].GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button3", charactorList[3].GetComponent<Charactor>());
            }


        } else {


            if (status.kimetaList.Count == 0) {

                button0.image.sprite = charactorList[0].GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button0", charactorList[0].GetComponent<Charactor>());

                button1.image.sprite = charactorList[1].GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button1", charactorList[1].GetComponent<Charactor>());

                button2.image.sprite = charactorList[2].GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button2", charactorList[2].GetComponent<Charactor>());

                button3.image.sprite = charactorList[3].GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button3", charactorList[3].GetComponent<Charactor>());
            } else {

                button0.gameObject.SetActive(false);
                button1.gameObject.SetActive(false);
                button2.gameObject.SetActive(false);
                button3.gameObject.SetActive(false);

                if (status.kimetaList.Count() > 0) {
                    button0.gameObject.SetActive(true);
                    GameObject g1 = Instantiate(Resources.Load(status.kimetaList[0], typeof(GameObject)) as GameObject, new Vector3(999f, 999f), Quaternion.identity);
                    Debug.Log(status.kimetaList[0]);
                    button0.image.sprite = g1.GetComponent<SpriteRenderer>().sprite;
                    Charactor c = g1.GetComponent<Charactor>();
                    c.setItemType(status.itemList[0]);

                    charactorDic.Add("Button0", c);
                }

                if (status.kimetaList.Count > 1) {
                    button1.gameObject.SetActive(true);
                    GameObject g2 = Instantiate(Resources.Load(status.kimetaList[1], typeof(GameObject)) as GameObject, new Vector3(999f, 999f), Quaternion.identity);
                    Debug.Log(status.kimetaList[1]);
                    button1.image.sprite = g2.GetComponent<SpriteRenderer>().sprite;
                    Charactor c = g2.GetComponent<Charactor>();
                    c.setItemType(status.itemList[1]);

                    charactorDic.Add("Button1", c);
                }
                if (status.kimetaList.Count > 2) {
                    button2.gameObject.SetActive(true);
                    GameObject g3 = Instantiate(Resources.Load(status.kimetaList[2], typeof(GameObject)) as GameObject, new Vector3(999f, 999f), Quaternion.identity);
                    Debug.Log(status.kimetaList[2]);
                    button2.image.sprite = g3.GetComponent<SpriteRenderer>().sprite;

                    Charactor c = g3.GetComponent<Charactor>();
                    c.setItemType(status.itemList[2]);

                    charactorDic.Add("Button2", c);
                }
                if (status.kimetaList.Count > 3) {
                    button3.gameObject.SetActive(true);
                    GameObject g4 = Instantiate(Resources.Load(status.kimetaList[3], typeof(GameObject)) as GameObject, new Vector3(999f, 999f), Quaternion.identity);
                    Debug.Log(status.kimetaList[3]);
                    button3.image.sprite = g4.GetComponent<SpriteRenderer>().sprite;

                    Charactor c = g4.GetComponent<Charactor>();
                    c.setItemType(status.itemList[3]);

                    charactorDic.Add("Button3", c);
                }

            }
        }


        if (gameMode == GameMode.BATTLE) {


            // カードに敵を設定


            button5.image.sprite = charactorList[4].GetComponent<SpriteRenderer>().sprite;
            charactorDic.Add("Button5", charactorList[4].GetComponent<Charactor>().setLevel(status.level));

            button6.image.sprite = charactorList[5].GetComponent<SpriteRenderer>().sprite;
            charactorDic.Add("Button6", charactorList[5].GetComponent<Charactor>().setLevel(status.level));

            button7.image.sprite = charactorList[6].GetComponent<SpriteRenderer>().sprite;
            charactorDic.Add("Button7", charactorList[6].GetComponent<Charactor>().setLevel(status.level));

            button8.image.sprite = charactorList[7].GetComponent<SpriteRenderer>().sprite;
            charactorDic.Add("Button8", charactorList[7].GetComponent<Charactor>().setLevel(status.level));

            button9.gameObject.SetActive(false);
        } else if (gameMode == GameMode.SUTEGI1) {

            // カードに敵を設定
            button9.image.sprite = charactorList[0].GetComponent<SpriteRenderer>().sprite;
            charactorDic.Add("Button9", charactorList[0].GetComponent<Charactor>().setLevel(status.level));

            button5.gameObject.SetActive(false);
            button6.gameObject.SetActive(false);
            button7.gameObject.SetActive(false);
            button8.gameObject.SetActive(false);


        } else if (gameMode == GameMode.DAIMAX) {
            if (status.mapStep == 0) {
                button9.image.sprite = kyourankotouyama.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button9", kyourankotouyama.GetComponent<Charactor>().setLevel(status.level));
            } else if (status.mapStep == 1) {
                button9.image.sprite = mudai.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button9", mudai.GetComponent<Charactor>().setLevel(status.level));
            } else if (status.mapStep == 2) {
                button9.image.sprite = fenzado.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button9", fenzado.GetComponent<Charactor>().setLevel(status.level));
            } else if (status.mapStep == 3) {
                button9.image.sprite = kamisama.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button9", kamisama.GetComponent<Charactor>().setLevel(status.level));

            }
            button5.gameObject.SetActive(false);
            button6.gameObject.SetActive(false);
            button7.gameObject.SetActive(false);
            button8.gameObject.SetActive(false);

        } else if (gameMode == GameMode.DAIMAX2) {
            if (status.map2Step == 0) {
                button9.image.sprite = syensin.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button9", syensin.GetComponent<Charactor>().setLevel(status.level));
            } else if (status.map2Step == 1) {
                button9.image.sprite = fensiruteiounosugata.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button9", fensiruteiounosugata.GetComponent<Charactor>().setLevel(status.level));
            } else if (status.map2Step == 2) {
                button9.image.sprite = akuzadoakunoteiounosugata.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button9", akuzadoakunoteiounosugata.GetComponent<Charactor>().setLevel(status.level));
            } else if (status.map2Step == 3) {
                button9.image.sprite = tyottohonkinokamisama.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button9", tyottohonkinokamisama.GetComponent<Charactor>().setLevel(status.level));


                button0.image.sprite = fenzadoteiounosugata.GetComponent<SpriteRenderer>().sprite;
                charactorDic["Button0"] = fenzadoteiounosugata.GetComponent<Charactor>();
            }
            button5.gameObject.SetActive(false);
            button6.gameObject.SetActive(false);
            button7.gameObject.SetActive(false);
            button8.gameObject.SetActive(false);


        } else if (gameMode == GameMode.DAIMAX3) {
            if (status.map3Step == 0) {
                button9.image.sprite = dotto.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button9", dotto.GetComponent<Charactor>().setLevel(status.level));
            } else if (status.map3Step == 1) {
                button9.image.sprite = fenkamizadoteiounosugata.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button9", fenkamizadoteiounosugata.GetComponent<Charactor>().setLevel(status.level));
            } else if (status.map3Step == 2) {
                button9.image.sprite = sinigamiex.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button9", sinigamiex.GetComponent<Charactor>().setLevel(status.level));
            } else if (status.map3Step == 3) {
                button9.image.sprite = kamisamahonki.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button9", kamisamahonki.GetComponent<Charactor>().setLevel(status.level));
            }
            button5.gameObject.SetActive(false);
            button6.gameObject.SetActive(false);
            button7.gameObject.SetActive(false);
            button8.gameObject.SetActive(false);
        } else if (gameMode == GameMode.DAIMAX4) {
            if (status.map4Step == 0) {
                button5.image.sprite = omokan.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button5", omokan.GetComponent<Charactor>().setLevel(status.level));
                button6.image.sprite = dogaiya.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button6", dogaiya.GetComponent<Charactor>().setLevel(status.level));
                button7.image.sprite = kubiiru.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button7", kubiiru.GetComponent<Charactor>().setLevel(status.level));
                button8.image.sprite = kubiiruex.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button8", kubiiruex.GetComponent<Charactor>().setLevel(status.level));
            } else if (status.map4Step == 1) {
                button5.image.sprite = syensin.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button5", syensin.GetComponent<Charactor>().setLevel(status.level));
                button6.image.sprite = sinigamiex.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button6", sinigamiex.GetComponent<Charactor>().setLevel(status.level));
                button7.image.sprite = eirianseizouki.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button7", eirianseizouki.GetComponent<Charactor>().setLevel(status.level));
                button8.image.sprite = eirianseizouki.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button8", eirianseizouki.GetComponent<Charactor>().setLevel(status.level));
            } else if (status.map4Step == 2) {
                button5.image.sprite = syensinex.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button5", syensinex.GetComponent<Charactor>().setLevel(status.level));
                button6.image.sprite = sinigamiex.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button6", sinigamiex.GetComponent<Charactor>().setLevel(status.level));
                button7.image.sprite = omokan.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button7", omokan.GetComponent<Charactor>().setLevel(status.level));
                button8.image.sprite = eirianseizouki.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button8", eirianseizouki.GetComponent<Charactor>().setLevel(status.level));
            } else if (status.map4Step == 3) {
                button5.image.sprite = kamisamahonkiex.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button5", kamisamahonkiex.GetComponent<Charactor>().setLevel(status.level));
                button6.image.sprite = kamibea.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button6", kamibea.GetComponent<Charactor>().setLevel(status.level));
                button7.image.sprite = eriasu.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button7", eriasu.GetComponent<Charactor>().setLevel(status.level));
                button8.image.sprite = kuruttakabi.GetComponent<SpriteRenderer>().sprite;
                charactorDic.Add("Button8", kuruttakabi.GetComponent<Charactor>().setLevel(status.level));
            }
            button9.gameObject.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update() {

    }

    public bool getIsChange() {
        return this.isChange;
    }
    public void setIsChange(bool isChange) {
        this.isChange = isChange;
    }

    public bool getBattle() {
        return this.isBattle;
    }
    public void setBattle(bool isBattle) {
        this.isBattle = isBattle;
    }

    public bool getIsButtonActive() {
        return this.isButtonActive;
    }

    public void showCommand(bool active) {
        this.command.SetActive(active);
    }
    public void showCommand2(bool active) {
        this.command2.SetActive(active);

        if (active) {
            this.commandSetting(mikata);
        }
    }

    /**
     * 味方設定
     */
    public void setReady1(bool isReady, string name, Button btn) {
        this.isReadyMikata = isReady;

        Charactor g = charactorDic[name];

        this.mikata = g;
        this.mikataBtn = btn;

        this.buttleMsg.SetActive(true);
        GameObject.Find("ButtleMsgText").GetComponent<Text>().text = "";

        // HP などの表示
        hpMikataText.text = "HP : " + g.getHp().ToString();
        mikataHpSlider.value = g.getHpParcentage();

        startBattle();

    }

    /**
     * 敵設定
     */
    public void setReady2(bool isReady, string name, Button btn) {
        this.isReadyTeki = isReady;

        Charactor g = charactorDic[name];

        this.teki = g;
        this.tekiBtn = btn;


        hpTekiText.text = "HP : " + g.getHp().ToString();
        tekiHpSlider.value = g.getHpParcentage();
        startBattle();

    }

    public void changeBackMikata() {

        mikataBtn.GetComponent<Card>().back();
        this.buttleMsg.SetActive(false);

    }

    public void mikataDaimax() {
        GameObject.Find("daimaxSe").GetComponent<AudioSource>().Play();
        mikata.setDaimaxTurn(3);
        GameObject.Find("ButtleMsgText").GetComponent<Text>().text = mikata.getName() + " はダイマックスした!\n能力上昇!";
        hpMikataText.text = "HP : " + mikata.getHp();
        mikataHpSlider.value = mikata.getHpParcentage();
        mikataBtn.GetComponent<RectTransform>().sizeDelta += new Vector2(200, 200);


        GameObject daimaxP = (GameObject)Resources.Load("daimaxP");
        // プレハブからインスタンスを生成。
        GameObject bigBang = Instantiate(daimaxP, mikataBtn.transform.position, Quaternion.identity);

    }


    private void mikataDaimaxEnd() {
        if (mikata == null || mikataBtn == null || hpMikataText == null) {
            return;
        }
        if (GameObject.Find("daimaxEndSe") == null) {
            return;
        }
        if (GameObject.Find("ButtleMsgText") == null) {
            return;
        }
        GameObject.Find("daimaxEndSe").GetComponent<AudioSource>().Play();
        GameObject.Find("ButtleMsgText").GetComponent<Text>().text = mikata.getName() + " は元の姿に戻った!";
        hpMikataText.text = "HP : " + mikata.getHp();
        mikataHpSlider.value = mikata.getHpParcentage();
        mikataBtn.GetComponent<RectTransform>().sizeDelta -= new Vector2(200, 200);
    }

    private void startBattle() {
        if (!this.isReadyMikata || !this.isReadyTeki) {
            return;
        }


        // 戦闘開始
        this.isBattle = true;
        this.isButtonActive = true;

        this.command.SetActive(true);

        GameObject timer = GameObject.Find("timer");
        timer.GetComponent<TimeCounter>().start();
    }


    public void commandSetting(Charactor mikata) {
        // コマンド設定
        GameObject.Find("kougeki1")
            .GetComponent<Command2>().setJumonType(
            mikata.getJumonTypeList()[0]);
        GameObject.Find("kougeki2")
            .GetComponent<Command2>().setJumonType(
            mikata.getJumonTypeList()[1]);
        GameObject.Find("kougeki3")
            .GetComponent<Command2>().setJumonType(
            mikata.getJumonTypeList()[2]);
        GameObject.Find("kougeki4")
            .GetComponent<Command2>().setJumonType(
            mikata.getJumonTypeList()[3]);

        GameObject.Find("kougeki1Text")
            .GetComponent<Text>().text = jm.getName(mikata.getJumonTypeList()[0]);
        GameObject.Find("kougeki2Text")
            .GetComponent<Text>().text = jm.getName(mikata.getJumonTypeList()[1]);
        GameObject.Find("kougeki3Text")
            .GetComponent<Text>().text = jm.getName(mikata.getJumonTypeList()[2]);
        GameObject.Find("kougeki4Text")
            .GetComponent<Text>().text = jm.getName(mikata.getJumonTypeList()[3]);
    }




    public void commandInputed(JumonType jumonType) {

        // 味方のアクション
        Action a = Action.of(mikata, teki, hpMikataText, hpTekiText, mikataHpSlider, tekiHpSlider, mikataBtn, tekiBtn,
            jm.getKougekiType(jumonType), jumonType, jm.getPriolity(jumonType));


        this.isButtonActive = false;
        this.command.SetActive(false);
        this.command2.SetActive(false);

        commandInputed(a);



    }

    public async void tekiwoDasu() {

        // 遅延 (エラーになることがあるため必要)
        await System.Threading.Tasks.Task.Delay(3000);

        // ランダムで敵を選ぶ
        List<Button> tekiButtonList = new List<Button>();
        if (gameMode == GameMode.BATTLE || gameMode == GameMode.DAIMAX4) {
            if (charactorDic["Button5"].getHp() > 0) {
                tekiButtonList.Add(button5);
            }
            if (charactorDic["Button6"].getHp() > 0) {
                tekiButtonList.Add(button6);
            }
            if (charactorDic["Button7"].getHp() > 0) {
                tekiButtonList.Add(button7);
            }
            if (charactorDic["Button8"].getHp() > 0) {
                tekiButtonList.Add(button8);
            }

        } else {
            tekiButtonList.Add(button9);
        }

        if (tekiButtonList.Count == 0) {
            return;
        }

        Button tekiButton = tekiButtonList?.OrderBy(btn => Guid.NewGuid()).ToList()[0];
        CardTeki cardTeki = tekiButton?.GetComponent<CardTeki>();
        cardTeki?.click();


        this.isReadyTeki = true;
    }


    /**
     * 攻撃処理
     */
    private async void commandInputed(Action action) {





        List<Action> actionList = new List<Action>();
        actionList.Add(action);

        List<JumonType> jumonTypeList = teki.getJumonTypeList().OrderBy(charactor => Guid.NewGuid()).ToList(); ;
        actionList.Add(Action.of(teki, mikata, hpTekiText, hpMikataText, tekiHpSlider, mikataHpSlider, tekiBtn, mikataBtn,
            jm.getKougekiType(jumonTypeList[0]), jumonTypeList[0], jm.getPriolity(jumonTypeList[0])
             ));


        // 素早さの高い順(降順)
        actionList.Sort((o1, o2) => (o2.getPriority() - o1.getPriority()) * 100000000 + o2.getSpeed() - o1.getSpeed());


        bool isTekiDead = false;
        bool isMikataDead = false;
        foreach (Action a in actionList) {

            // 攻撃時 from のサイズ変更
            if (a.getFromBtn().GetComponent<Card>() != null) {
                a.getFromBtn().GetComponent<Card>().kougekiAction();
            }
            if (a.getFromBtn().GetComponent<CardTeki>() != null) {
                a.getFromBtn().GetComponent<CardTeki>().kougekiAction();
            }

            // 攻撃時メッセージと効果音
            buttleMsg.SetActive(true);

            await a.getFrom().kougekimae(a);


            GameObject.Find("ButtleMsgText").GetComponent<Text>().text = a.getFrom().getName() + " の " + jm.getName(a.getJumonType()) + "!\n" + jm.getMsg(a.getJumonType());
            koukaon(a.getJumonType());


            await System.Threading.Tasks.Task.Delay(2000);


            int damage = 0;
            if (KougekiType.KOUGEKI == a.getKougekiType()) {
                damage = a.getFrom().getKougekiPower(a.getKougekiType());
                damage += jm.getValInt(a.getJumonType());
                // タイプ相性
                // 技のタイプ
                Type waza = jm.getType(a.getJumonType());

                // 敵のタイプ
                Type tekiType = a.getTo().getType();

                // タイプ相性ダメージ補正
                float typeRate = wazaType.getTypeRate(waza, tekiType);
                damage = Mathf.FloorToInt((float)damage * typeRate);

                if (GameObject.Find("ButtleMsgText") == null) {
                    return;
                }

                if (typeRate > 1) {

                    GameObject.Find("ButtleMsgText").GetComponent<Text>().text =
                    GameObject.Find("ButtleMsgText").GetComponent<Text>().text + "\n" +
                    "効果はバツグンだ!!";

                } else if (typeRate < 1) {
                    GameObject.Find("ButtleMsgText").GetComponent<Text>().text =
                    GameObject.Find("ButtleMsgText").GetComponent<Text>().text + "\n" +
                    "効果はひまひとつだ・・・";

                }


                if (a.getToBtn().GetComponent<Card>() != null) {
                    a.getToBtn().GetComponent<Card>().damageAction();
                }
                if (a.getToBtn().GetComponent<CardTeki>() != null) {
                    a.getToBtn().GetComponent<CardTeki>().damageAction();
                }





            } else if (KougekiType.KOUGEKI_UP == a.getKougekiType()) {
                a.getFrom().plusKougeki(Mathf.FloorToInt(a.getFrom().getKougeki() * jm.getValFloat(a.getJumonType())));
            } else if (KougekiType.HP_UP == a.getKougekiType()) {
                a.getFrom().plusHp(Mathf.FloorToInt(a.getFrom().getMaxHp() * jm.getValFloat(a.getJumonType())));
                a.getFromHpText().text = "HP : " + a.getFrom().getHp();
                a.getFromHpSlider().value = a.getFrom().getHpParcentage();
            } else if (KougekiType.SPEED_UP == a.getKougekiType()) {
                a.getFrom().plusSpeed(Mathf.FloorToInt(a.getFrom().getSpeed() * jm.getValFloat(a.getJumonType())));
            } else if (KougekiType.CHANGE == a.getKougekiType()) {

            }

            // 追加
            a.tuika();
            await a.getFrom().kougekiato(a);


            // 攻撃したほうの hp 判定
            if (a.getFrom().getHp() <= 0) {
                a.getFromHpText().text = "HP : 0";
                a.getFromHpSlider().value = 0;
                a.getFromBtn().gameObject.SetActive(false);

                this.isBattle = false;

                if (a.getFromBtn().gameObject.GetComponent<CardTeki>() != null) {
                    this.isReadyTeki = false;
                    isTekiDead = true;
                }
                if (a.getFromBtn().gameObject.GetComponent<Card>() != null) {
                    isMikataDead = true;
                }

            } else {
                a.getFromHpText().text = "HP : " + a.getFrom().getHp();
                a.getFromHpSlider().value = a.getFrom().getHpParcentage();
            }


            // 攻撃された方の hp 判定
            bool isDead = false;
            if (a.getJumonType() == JumonType.KYOUUN) {
                isDead = damage == 0 ? false : a.getTo().damage(damage, a);
            } else {
                isDead = damage == 0 ? false : a.getTo().damage(damage);
            }
            if (isDead) {
                a.getToHpText().text = "HP : 0";
                a.getToHpSlider().value = 0;
                a.getToBtn().gameObject.SetActive(false);

                this.isBattle = false;

                if (a.getToBtn().gameObject.GetComponent<CardTeki>() != null) {
                    this.isReadyTeki = false;
                    isTekiDead = true;
                }
                if (a.getToBtn().gameObject.GetComponent<Card>() != null) {
                    isMikataDead = true;
                }

            }

            a.getToHpText().text = "HP : " + a.getTo().getHp();
            a.getToHpSlider().value = a.getTo().getHpParcentage();


            if (KougekiType.KOUGEKI == a.getKougekiType()) {
                // 攻撃を受けた時の効果音
                if (a.getTo().getName() == "おもこ") {
                    Omoko omoko = (Omoko)a.getTo();
                    if (omoko.getYoketa() == 1) {
                        GameObject.Find("yokeru").GetComponent<AudioSource>().Play();
                    } else {
                        GameObject.Find("damage1").GetComponent<AudioSource>().Play();
                    }
                } else {
                    GameObject.Find("damage1").GetComponent<AudioSource>().Play();
                }
                await System.Threading.Tasks.Task.Delay(1000);
            }


            if (isTekiDead || isMikataDead) {
                await System.Threading.Tasks.Task.Delay(1500);
                break;
            } else {
                await System.Threading.Tasks.Task.Delay(1500);
            }


        }


        this.mikata.tuikaEnd();
        this.teki.tuikaEnd();


        if (mikata.getHp() <= 0) {
            hpMikataText.text = "HP : 0";
            mikataHpSlider.value = 0;
            mikataBtn.gameObject.SetActive(false);

            this.isBattle = false;

            if (mikataBtn.gameObject.GetComponent<Card>() != null) {
                isMikataDead = true;
            }

        } else {
            hpMikataText.text = "HP : " + mikata.getHp();
            mikataHpSlider.value = mikata.getHpParcentage();
        }
        if (teki.getHp() <= 0) {
            hpTekiText.text = "HP : 0";
            tekiHpSlider.value = 0;
            tekiBtn.gameObject.SetActive(false);

            this.isBattle = false;

            if (tekiBtn.gameObject.GetComponent<CardTeki>() != null) {
                isTekiDead = true;
            }

        } else {
            hpTekiText.text = "HP : " + teki.getHp();
            tekiHpSlider.value = teki.getHpParcentage();
        }




        // 勝敗判定
        await this.buttleHantei();

        // 味方が倒れたら味方を選ぶ
        if (isMikataDead) {

            this.command.SetActive(false);
            this.isButtonActive = false;
            this.isReadyMikata = false;
            buttleMsg.SetActive(false);
        }


        // 敵が倒れたら新しく一人出す
        if (isTekiDead) {
            this.command.SetActive(false);
            this.isButtonActive = false;
            this.isReadyTeki = false;
            if (gameMode == GameMode.BATTLE || gameMode == GameMode.SUTEGI1 || gameMode == GameMode.DAIMAX4) {

                this.tekiwoDasu();
                await System.Threading.Tasks.Task.Delay(100);
                this.buttleMsg.SetActive(true);
                GameObject.Find("ButtleMsgText").GetComponent<Text>().text = "相手の通信を待っています。";
                await System.Threading.Tasks.Task.Delay(2000);
            }
        }

        // ダイマックスターンを減らす
        if (action.getFrom().minusDaimaxTurn()) {
            this.mikataDaimaxEnd(); // ダイマックス終了
        }


        this.isButtonActive = true;
        if (this.command != null) {
            this.command.SetActive(true);
        }
        if (this.command2 != null) {
            this.command2.SetActive(false);
        }


        GameObject timer = GameObject.Find("timer");
        timer.GetComponent<TimeCounter>().start();

    }




    public async Task buttleHantei() {



        await System.Threading.Tasks.Task.Delay(2000);

        // 勝ち
        if (gameMode == GameMode.BATTLE) {
            Status status = GameObject.Find("status").GetComponent<Status>();
            if (charactorDic.ContainsKey("Button5") && charactorDic["Button5"].getHp() <= 0 &&
                (!charactorDic.ContainsKey("Button6") || charactorDic.ContainsKey("Button6") && charactorDic["Button6"].getHp() <= 0) &&
                (!charactorDic.ContainsKey("Button7") || charactorDic.ContainsKey("Button7") && charactorDic["Button7"].getHp() <= 0) &&
                (!charactorDic.ContainsKey("Button8") || charactorDic.ContainsKey("Button8") && charactorDic["Button8"].getHp() <= 0)
                ) {
                SceneManager.LoadScene("win");
                status.level += 10;
                status.okane += 1000;
            }

        } else if (gameMode == GameMode.SUTEGI1) {
            if (charactorDic["Button9"].getHp() <= 0) {
                Status status = GameObject.Find("status").GetComponent<Status>();
                status.stage += 1;
                SceneManager.LoadScene("sutegi" + status.stage);
            }


        } else if (gameMode == GameMode.DAIMAX) {

            if (charactorDic["Button9"].getHp() <= 0) {
                Status status = GameObject.Find("status").GetComponent<Status>();
                status.mapStep += 1;




                SceneManager.LoadScene("map");

            }
        } else if (gameMode == GameMode.DAIMAX2) {

            if (charactorDic["Button9"].getHp() <= 0) {
                Status status = GameObject.Find("status").GetComponent<Status>();
                status.map2Step += 1;

                if (status.map2Step == 3) {
                    status.map2Stage3 = true;
                }

                SceneManager.LoadScene("map2");
            }


        } else if (gameMode == GameMode.DAIMAX3) {

            if (charactorDic["Button9"].getHp() <= 0) {
                Status status = GameObject.Find("status").GetComponent<Status>();
                status.map3Step += 1;

                if (status.map3Step == 3) {
                    status.map3Stage3 = true;
                }

                SceneManager.LoadScene("map3");
            }


        } else if (gameMode == GameMode.DAIMAX4) {

            if (charactorDic.ContainsKey("Button5") && charactorDic["Button5"].getHp() <= 0 &&
                (!charactorDic.ContainsKey("Button6") || charactorDic.ContainsKey("Button6") && charactorDic["Button6"].getHp() <= 0) &&
                (!charactorDic.ContainsKey("Button7") || charactorDic.ContainsKey("Button7") && charactorDic["Button7"].getHp() <= 0) &&
                (!charactorDic.ContainsKey("Button8") || charactorDic.ContainsKey("Button8") && charactorDic["Button8"].getHp() <= 0)
                ) {
                Status status = GameObject.Find("status").GetComponent<Status>();
                status.map4Step += 1;

                if (status.map4Step == 3) {
                    status.map4Stage3 = true;
                }

                SceneManager.LoadScene("map4");
            }


        }



        // 負け
        if (charactorDic.ContainsKey("Button0") && charactorDic["Button0"].getHp() <= 0 &&
            (!charactorDic.ContainsKey("Button1") || charactorDic.ContainsKey("Button1") && charactorDic["Button1"].getHp() <= 0) &&
            (!charactorDic.ContainsKey("Button2") || charactorDic.ContainsKey("Button2") && charactorDic["Button2"].getHp() <= 0) &&
            (!charactorDic.ContainsKey("Button3") || charactorDic.ContainsKey("Button3") && charactorDic["Button3"].getHp() <= 0)
            ) {
            SceneManager.LoadScene("lose");
        }
    }


    public void damageToTeki(KougekiType k) {

        int damage = this.mikata.getKougekiPower(k);

        bool isDead = this.teki.damage(damage);

        if (isDead) {
            hpTekiText.text = "HP : 0";
            tekiHpSlider.value = 0;
            this.tekiBtn.gameObject.SetActive(false);

            this.isBattle = false;
            this.isReadyTeki = false;
            this.isButtonActive = false;

        } else {
            hpTekiText.text = "HP : " + this.teki.getHp();
            tekiHpSlider.value = this.teki.getHpParcentage();
        }
    }

    public void damageToMikata(KougekiType k) {

        int damage = this.teki.getKougekiPower(k);

        bool isDead = this.mikata.damage(damage);
        if (isDead) {
            hpMikataText.text = "HP : 0";
            mikataHpSlider.value = 0;
            this.mikataBtn.gameObject.SetActive(false);

            this.isBattle = false;
            this.isReadyMikata = false;
            this.isButtonActive = false;


        } else {
            hpMikataText.text = "HP : " + this.mikata.getHp();
            mikataHpSlider.value = this.mikata.getHpParcentage();
        }
    }

    private async void sleep(int time) {
        await System.Threading.Tasks.Task.Delay(time);
    }

    public void kougekiUp(int kougeki) {
        this.mikata.plusKougeki(kougeki);
    }
    public void hpUp(int hp) {
        this.mikata.plusHp(hp);
    }


    public async void koukaon(JumonType j) {

        if (JumonType.KAMITUKU == j) {
            GameObject.Find("kamituku").GetComponent<AudioSource>().Play();
        } else if (JumonType.KOSYOU == j) {
            GameObject.Find("bakuhatu").GetComponent<AudioSource>().Play();
            await System.Threading.Tasks.Task.Delay(1000);
            GameObject.Find("bakuhatu").GetComponent<AudioSource>().Play();
            await System.Threading.Tasks.Task.Delay(100);
            GameObject.Find("bakuhatu").GetComponent<AudioSource>().Play();
            await System.Threading.Tasks.Task.Delay(500);
            GameObject.Find("bakuhatu").GetComponent<AudioSource>().Play();
            await System.Threading.Tasks.Task.Delay(600);
            GameObject.Find("bakuhatu").GetComponent<AudioSource>().Play();
            await System.Threading.Tasks.Task.Delay(200);
            GameObject.Find("bakuhatu").GetComponent<AudioSource>().Play();
        } else if (JumonType.HOROBI == j) {
            GameObject.Find("bakuhatu").GetComponent<AudioSource>().Play();
            await System.Threading.Tasks.Task.Delay(1000);
            GameObject.Find("bakuhatu").GetComponent<AudioSource>().Play();
            await System.Threading.Tasks.Task.Delay(100);
            GameObject.Find("bakuhatu").GetComponent<AudioSource>().Play();
            await System.Threading.Tasks.Task.Delay(500);
            GameObject.Find("bakuhatu").GetComponent<AudioSource>().Play();
            await System.Threading.Tasks.Task.Delay(600);
            GameObject.Find("bakuhatu").GetComponent<AudioSource>().Play();
            await System.Threading.Tasks.Task.Delay(200);
            GameObject.Find("bakuhatu").GetComponent<AudioSource>().Play();
        } else if (JumonType.HORORORO == j) {
            GameObject.Find("bakuhatu").GetComponent<AudioSource>().Play();
            await System.Threading.Tasks.Task.Delay(1000);
            GameObject.Find("bakuhatu").GetComponent<AudioSource>().Play();
            await System.Threading.Tasks.Task.Delay(100);
            GameObject.Find("bakuhatu").GetComponent<AudioSource>().Play();
            await System.Threading.Tasks.Task.Delay(500);
            GameObject.Find("bakuhatu").GetComponent<AudioSource>().Play();
            await System.Threading.Tasks.Task.Delay(600);
            GameObject.Find("bakuhatu").GetComponent<AudioSource>().Play();
            await System.Threading.Tasks.Task.Delay(200);
            GameObject.Find("bakuhatu").GetComponent<AudioSource>().Play();
        } else if (JumonType.KURION == j) {
            GameObject.Find("kaihuku").GetComponent<AudioSource>().Play();
        } else if (JumonType.GOUN == j) {
            GameObject.Find("kougekiappu").GetComponent<AudioSource>().Play();
        } else if (JumonType.ATAIRU == j) {
            GameObject.Find("kougekiappu").GetComponent<AudioSource>().Play();
        } else if (JumonType.WARAWASERU == j) {
            GameObject.Find("warau").GetComponent<AudioSource>().Play();
        } else if (JumonType.ANKOKUU == j) {
            GameObject.Find("ankokuu1").GetComponent<AudioSource>().Play();
            await System.Threading.Tasks.Task.Delay(2500);
            GameObject.Find("ankokuu2").GetComponent<AudioSource>().Play();
        } else if (JumonType.GOUGOGOUN == j) {
            GameObject.Find("gokugokuu").GetComponent<AudioSource>().Play();
        } else if (JumonType.APPUDETO == j) {
            GameObject.Find("kaihuku").GetComponent<AudioSource>().Play();
        } else if (JumonType.RUGAN == j) {
            GameObject.Find("rugan").GetComponent<AudioSource>().Play();
        } else if (JumonType.GATIDEDOUSIYO == j) {
            GameObject.Find("kaihuku").GetComponent<AudioSource>().Play();
        } else if (JumonType.KYOUUN == j) {
            GameObject.Find("kyouunn").GetComponent<AudioSource>().Play();
        } else if (JumonType.OIKAZE == j) {
            GameObject.Find("kougekiappu").GetComponent<AudioSource>().Play();
        } else if (JumonType.KYUUKETU == j) {
            GameObject.Find("kaihuku").GetComponent<AudioSource>().Play();
        } else if (JumonType.SPAMD == j) {
            GameObject.Find("kaihuku").GetComponent<AudioSource>().Play();
        } else if (JumonType.BOUHUU == j) {
            GameObject.Find("bouhuu").GetComponent<AudioSource>().Play();
        } else if (JumonType.AORI == j) {
            GameObject.Find("power").GetComponent<AudioSource>().Play();
        } else if (JumonType.UZA == j) {
            GameObject.Find("power").GetComponent<AudioSource>().Play();
        } else if (JumonType.FAIYAZAREKUSSU == j) {
            GameObject.Find("fire").GetComponent<AudioSource>().Play();
        } else if (JumonType.FAIYAZAREKUSSUex == j) {
            GameObject.Find("fire").GetComponent<AudioSource>().Play();
        } else if (JumonType.GOUGOUGOUGOGOUN == j) {
            GameObject.Find("ankokuu1").GetComponent<AudioSource>().Play();
            await System.Threading.Tasks.Task.Delay(1000);
            GameObject.Find("kamituku").GetComponent<AudioSource>().Play();
        } else {
            GameObject.Find("sound").GetComponent<AudioSource>().Play();
        } 









        }

    public Charactor getMikata() {
        return this.mikata;
    }
   
}

