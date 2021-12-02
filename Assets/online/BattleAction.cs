using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;
using System.Collections;

public class BattleAction : MonoBehaviour
{
    private GetBattleResultRes res;
    private List<ShowResult> results = new List<ShowResult>();
    private int index = 0;

    private float time;

    private float interval = 3f;

    private Text msg;



    private List<Actions> actionList = new List<Actions>();
    public long selectedCharacterId = 0;
    public GameObject[] wazaButtons = null;

    public GameObject[] changeButtons = null;
    public string wazaId;

    // Start is called before the first frame update
    void Start()
    {
        msg = GameObject.Find("msg").GetComponent<Text>();


        actionList = GameObject.Find("battle").GetComponent<Battle>().actionList;
        wazaButtons = GameObject.FindGameObjectsWithTag("wazas");
        // 初回選択
        selectedCharacterId = long.Parse(PlayerPrefs.GetString("choose").Split(',')[0]);

        changeButtons = GameObject.FindGameObjectsWithTag("change");

        Images images = GameObject.Find("Images").GetComponent<Images>();
        images.setSprite();

    }

    private IEnumerator callApi() {

        // ステータス取得
        GetBattleResultReq getBattleResultReq = new GetBattleResultReq();
        getBattleResultReq.roomId = PlayerPrefs.GetString("roomId");
        getBattleResultReq.userId = PlayerPrefs.GetString("inputName");
        string json = JsonUtility.ToJson(getBattleResultReq);


        Debug.Log("BattleStatus: " + json);
        string url = Battle.host + "/getBattleResultStatus";
        // HEADERはHashtableで記述
        Hashtable header = new Hashtable();
        // jsonでリクエストを送るのへッダ例
        header.Add("Content-Type", "application/json; charset=UTF-8");


        string postJsonStr = json;
        byte[] postBytes = Encoding.Default.GetBytes(postJsonStr);

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(postBytes);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        Debug.Log(request.downloadHandler.text);

        GetBattleStatusRes getBattleStatusRes = JsonUtility.FromJson<GetBattleStatusRes>(request.downloadHandler.text);


        string status = getBattleStatusRes.getUserStatus(PlayerPrefs.GetString("inputName")).battleResultStatus;

        // ステータスが WAIT なら何もしない
        if (status.Equals("WAIT")) {
            yield break;
        }


        //とうやま！頑張ってバトルできるようにするんや！
        // わかったで!
        if (actionList.Count == 0) {
            switch (status) {
                case "INIT_CHANGE":
                    this.showChangeButton(true);
                    this.showWazaButton(false);
                    break;
                case "GET_RESULT":
                    this.showChangeButton(false);
                    this.showWazaButton(false);
                    break;
                case "COMMAND_INPUT":
                    this.showChangeButton(false);
                    this.showWazaButton(true);
                    actionList.Add(new MessageAction("キャラクターを選択してください。"));
                    break;
                default:
                    this.showChangeButton(true);
                    this.showWazaButton(false);
                    break;
            }
        }


        if (status.Equals("INIT_CHANGE") && selectedCharacterId != 0) {
            Debug.Log("call INIT_CHANGE");

            // キャラクター情報取得(技設定など)
            GetCharacterReq c = new GetCharacterReq();
            c.characterId = selectedCharacterId;
            StartCoroutine(getCharacter(JsonUtility.ToJson(c)));

            // INIT_CHANGE 
            BattleReq req = new BattleReq();
            req.roomId = PlayerPrefs.GetString("roomId");
            req.userId = PlayerPrefs.GetString("inputName");
            req.waza = Waza.INIT_CHANGE.ToString();
            req.changeCharacterId = selectedCharacterId;
            StartCoroutine(battle(JsonUtility.ToJson(req)));
            Debug.Log("INIT_CHANGE selectedCharacterId is " + selectedCharacterId);
            selectedCharacterId = 0;

            actionList.Add(new MessageAction("通信中・・・"));


        }

        if (status.Equals("GET_RESULT")) {
            GetBattleResultReq req = new GetBattleResultReq();
            req.roomId = PlayerPrefs.GetString("roomId");
            req.userId = PlayerPrefs.GetString("inputName");
            StartCoroutine(getResult(JsonUtility.ToJson(req)));


        }


        if (status.Equals("COMMAND_INPUT") && this.wazaId != null) {
            BattleReq req = new BattleReq();
            req.roomId = PlayerPrefs.GetString("roomId");
            req.userId = PlayerPrefs.GetString("inputName");
            req.waza = wazaId;
            req.changeCharacterId = selectedCharacterId;

            StartCoroutine(battle(JsonUtility.ToJson(req)));

            actionList.Add(new MessageAction("通信中・・・"));

        }


            //if (actionList.Count > 0) {

        //    Actions action = actionList[0];

        //    action.doAction(action);

        //    actionList.Remove(action);
        //}
    }



    void Update() {
        time += Time.deltaTime;
        if (time < interval) {
            return;
        }
        time = 0;

        // ステータス取得
        StartCoroutine(callApi());






    }


    public void showChangeButton(bool show) {
        foreach (GameObject go in changeButtons) {
            go.SetActive(show);
        }
    }

    public void toggleChangeButton() {
        foreach (GameObject go in changeButtons) {
            go.SetActive(!go.activeSelf);
        }
    }

    public void showWazaButton(bool show) {
        foreach (GameObject go in wazaButtons) {
            go.SetActive(show);
        }
    }

    // Update is called once per frame
    /*void Update() {
        time += Time.deltaTime;
        if (time < interval) {
            return;
        }
        time = 0;

        if (results.Count > index) {
            ShowResult result = results[index];
            this.interval = result.interval;

            if ("INIT_CHANGE".Equals(result.action)) {


                if (result.a.characterStatus1.id != 0) {
                    string name = Characters.of().getName(result.a.characterStatus1.characterId);

                    //Resources.Load(name);
                    if (result.a.characterStatus1.userId.Equals(PlayerPrefs.GetString("inputName"))) {
                        GameObject.Find("me").GetComponent<UnityEngine.UI.Image>().color = new Color(1f, 1f, 1f, 1f);
                        GameObject.Find("me").GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(name);
                    } else {
                        GameObject.Find("op").GetComponent<UnityEngine.UI.Image>().color = new Color(1f, 1f, 1f, 1f);
                        GameObject.Find("op").GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(name);
                    }
                }

            } else if ("DEAD".Equals(result.action)) {
                if (result.a.characterStatus1.id != 0) {
                    string name = Characters.of().getName(result.a.characterStatus1.characterId);

                    //Resources.Load(name);
                    if (result.a.characterStatus1.userId.Equals(PlayerPrefs.GetString("inputName"))) {
                        if (result.a.characterStatus1.hp <= 0) {
                            GameObject.Find("me").GetComponent<UnityEngine.UI.Image>().color = new Color(0f, 0f, 0f, 0f);
                            GameObject.Find("me").GetComponent<UnityEngine.UI.Image>().sprite = null;

                        }
                    } else {
                        if (result.a.characterStatus1.hp <= 0) {
                            GameObject.Find("op").GetComponent<UnityEngine.UI.Image>().color = new Color(0f, 0f, 0f, 0f);
                            GameObject.Find("op").GetComponent<UnityEngine.UI.Image>().sprite = null;
                        }
                    }
                }
                if (result.a.characterStatus2.id != 0) {
                    string name = Characters.of().getName(result.a.characterStatus2.characterId);

                    //Resources.Load(name);
                    if (result.a.characterStatus2.userId.Equals(PlayerPrefs.GetString("inputName"))) {
                        if (result.a.characterStatus2.hp <= 0) {
                            GameObject.Find("me").GetComponent<UnityEngine.UI.Image>().color = new Color(0f, 0f, 0f, 0f);
                            GameObject.Find("me").GetComponent<UnityEngine.UI.Image>().sprite = null;
                        }
                    } else {
                        if (result.a.characterStatus2.hp <= 0) {
                            GameObject.Find("op").GetComponent<UnityEngine.UI.Image>().color = new Color(0f, 0f, 0f, 0f);
                            GameObject.Find("op").GetComponent<UnityEngine.UI.Image>().sprite = null;
                        }
                    }
                }




            } else if ("EFFECT".Equals(result.action)) {

            } else if ("CHANGE".Equals(result.action)) {
                if (result.a.characterStatus1.id != 0) {
                    string name = Characters.of().getName(result.a.characterStatus1.characterId);

                    //Resources.Load(name);
                    if (result.a.characterStatus1.userId.Equals(PlayerPrefs.GetString("inputName"))) {
                        GameObject.Find("me").GetComponent<UnityEngine.UI.Image>().color = new Color(1f, 1f, 1f, 1f);
                        GameObject.Find("me").GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(name);
                    } else {
                        GameObject.Find("op").GetComponent<UnityEngine.UI.Image>().color = new Color(1f, 1f, 1f, 1f);
                        GameObject.Find("op").GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(name);
                    }
                }
            } else {
                msg.text = result.action;
            }

            index++;
        } else {

            results = new List<ShowResult>();
            index = 0;
            GameObject.Find("battle").GetComponent<Battle>().showingResult = false;
        }

    }*/

    //public void setBattleRes(GetBattleResultRes res) {


    //    this.res = res;

    //    foreach (GetBattleResultRes.BattleResult r in res.results) {
    //        if (r.change != null) {
    //            this.addResult(ShowResult.of(r.change, r.change.message1, 0f));
    //            this.addResult(ShowResult.of(r.change, r.change.action, 2.5f));
    //            this.addResult(ShowResult.of(r.change, r.change.message1, 1.5f));
    //        }

    //        if (r.inTheBattle != null) {
    //            this.addResult(ShowResult.of(r.inTheBattle, r.inTheBattle.message1, 0f));
    //            this.addResult(ShowResult.of(r.inTheBattle, r.inTheBattle.action, 2.5f));
    //            this.addResult(ShowResult.of(r.inTheBattle, r.inTheBattle.message1, 1.5f));
    //        }

    //        if (r.beforeAttack != null) {
    //            this.addResult(ShowResult.of(r.beforeAttack, r.beforeAttack.message1, 0f));
    //            this.addResult(ShowResult.of(r.beforeAttack, r.beforeAttack.action, 2.5f));
    //            this.addResult(ShowResult.of(r.beforeAttack, r.beforeAttack.message1, 1.5f));
    //        }

    //        if (r.inAttack != null) {
    //            this.addResult(ShowResult.of(r.inAttack, r.inAttack.message1, 0f));
    //            this.addResult(ShowResult.of(r.inAttack, r.inAttack.action, 2.5f));
    //            this.addResult(ShowResult.of(r.inAttack, r.inAttack.message1, 1.5f));
    //        }
    //        if (r.afterAttack != null) {
    //            this.addResult(ShowResult.of(r.afterAttack, r.afterAttack.message1, 0f));
    //            this.addResult(ShowResult.of(r.afterAttack, r.afterAttack.action, 2.5f));
    //            this.addResult(ShowResult.of(r.afterAttack, r.afterAttack.message1, 1.5f));
    //        }
    //        if (r.endTheBattle != null) {
    //            this.addResult(ShowResult.of(r.endTheBattle, r.endTheBattle.message1, 0f));
    //            this.addResult(ShowResult.of(r.endTheBattle, r.endTheBattle.action, 2.5f));
    //            this.addResult(ShowResult.of(r.endTheBattle, r.endTheBattle.message1, 1.5f));
    //        }
    //    }
    //}

    private void addResult(ShowResult r) {
        if (r == null) {
            return;
        }
        results.Add(r);
    }


    public class ShowResult {
        public GetBattleResultRes.ResultAction a;
        public string action;
        public float interval;

        public static ShowResult of(GetBattleResultRes.ResultAction a, string action, float interval) {
            if (a == null || action == null || action == "") {
                return null;
            }

            ShowResult r = new ShowResult();
            r.a = a;
            r.action = action;
            r.interval = interval;

            return r;
        }
    }



    IEnumerator battle(string json) {

        Debug.Log("BATTLE: " + json);
        string url = Battle.host + "/battle";
        // HEADERはHashtableで記述
        Hashtable header = new Hashtable();
        // jsonでリクエストを送るのへッダ例
        header.Add("Content-Type", "application/json; charset=UTF-8");


        string postJsonStr = json;
        byte[] postBytes = Encoding.Default.GetBytes(postJsonStr);

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(postBytes);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        Debug.Log(request.downloadHandler.text);

        BattleRes battleRes = JsonUtility.FromJson<BattleRes>(request.downloadHandler.text);
        this.wazaId = null;
    }


    IEnumerator getResult(string json) {
        Debug.Log("Resutl: " + json);
        string url = Battle.host + "/getResult";
        // HEADERはHashtableで記述
        Hashtable header = new Hashtable();
        // jsonでリクエストを送るのへッダ例
        header.Add("Content-Type", "application/json; charset=UTF-8");


        string postJsonStr = json;
        byte[] postBytes = Encoding.Default.GetBytes(postJsonStr);

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(postBytes);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        Debug.Log(request.downloadHandler.text);

        GetBattleResultRes getBattleResultRes = JsonUtility.FromJson<GetBattleResultRes>(request.downloadHandler.text);

        // バトル結果をactionList に詰めて表示する

        foreach(GetBattleResultRes.BattleResult r in getBattleResultRes.results) {
            List<Actions> addList = ActionFactory.actions(r);
            foreach(Actions a in addList) {
                actionList.Add(a);
            }

            
        }
        actionList.Add(new MessageAction("コマンドを選択してください。"));

        //if (!getBattleResultRes.battleResultId.Equals(this.battleResultId)) {
        //    BattleAction ba = GameObject.Find("battleAction").GetComponent<BattleAction>();
        //    ba.setBattleRes(getBattleResultRes);
        //    this.battleResultId = getBattleResultRes.battleResultId;
        //}
    }

    IEnumerator getCharacter(string json) {
        Debug.Log("Character: " + json);
        string url = Battle.host + "/getCharacter";
        // HEADERはHashtableで記述
        Hashtable header = new Hashtable();
        // jsonでリクエストを送るのへッダ例
        header.Add("Content-Type", "application/json; charset=UTF-8");


        string postJsonStr = json;
        byte[] postBytes = Encoding.Default.GetBytes(postJsonStr);

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(postBytes);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        Debug.Log(request.downloadHandler.text);

        GetCharacterRes getCharacterRes = JsonUtility.FromJson<GetCharacterRes>(request.downloadHandler.text);


        foreach (GameObject w in wazaButtons) {
            w.SetActive(true);
        }

        wazaButtons[0].GetComponentInChildren<Text>().text = getCharacterRes.wazaName1;
        wazaButtons[1].GetComponentInChildren<Text>().text = getCharacterRes.wazaName2;
        wazaButtons[2].GetComponentInChildren<Text>().text = getCharacterRes.wazaName3;
        wazaButtons[3].GetComponentInChildren<Text>().text = getCharacterRes.wazaName4;
        wazaButtons[0].GetComponent<WazaButton>().setWaza(getCharacterRes.waza1);
        wazaButtons[1].GetComponent<WazaButton>().setWaza(getCharacterRes.waza2);
        wazaButtons[2].GetComponent<WazaButton>().setWaza(getCharacterRes.waza3);
        wazaButtons[3].GetComponent<WazaButton>().setWaza(getCharacterRes.waza4);

    }
}
