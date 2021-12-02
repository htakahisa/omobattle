using UnityEngine;
using System.Text;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{

    private GetBattleStatusRes getBattleStatusRes;
    private BattleRes battleRes;
    private GetBattleResultRes getBattleResultRes;
    private GetCharacterRes getCharacterRes;
    GameObject[] wazaButtons;
    private string battleResultStatus;


    private string battleResultId;

    public long selectedCharacterId = 0;
    private bool firstInBattle = true;

    // 選択した技
    public string waza;


    // 戦闘結果を渡した
    private bool showBattleResult = false;


    // 戦闘結果描画中
    public bool showingResult = false;

    private float time = 1f;
    private float interval = 2f;

    public bool beatOp;

    public static string host = "http://192.168.11.58:20001";


    public List<Actions> actionList = new List<Actions>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("me").GetComponentInChildren<UnityEngine.UI.Text>().text = "";
        GameObject.Find("op").GetComponentInChildren<UnityEngine.UI.Text>().text = "";


        wazaButtons = GameObject.FindGameObjectsWithTag("wazas");

        // 初回選択
        selectedCharacterId = long.Parse(PlayerPrefs.GetString("choose").Split(',')[0]);

    }


    /*
    void Update() {



        // 戦闘結果描画中
        if (showingResult) {
            return;
        }

        time += Time.deltaTime;

        if (time < interval) {
            return;
        }
        time = 0;





        // ステータス取得
        GetBattleResultReq getBattleResultReq = new GetBattleResultReq();
        getBattleResultReq.roomId = PlayerPrefs.GetString("roomId");
        StartCoroutine(getBattleResultStatus(JsonUtility.ToJson(getBattleResultReq)));
        Debug.Log("get status.");
        


        // wait
        if ("WAIT".Equals(this.battleResultStatus)) {
            Debug.Log("WAIT");
            
            return;
        }

        // init change
        if ("INIT_CHANGE".Equals(this.battleResultStatus)) {
            GameObject.Find("change").GetComponent<ChangeButton>().showChangeList();


            if (selectedCharacterId == 0) {
                
                Debug.Log("INIT_CHANGE selectedCharacterId is 0. skip.");
                return;
            }

            if (getBattleStatusRes != null && !getBattleStatusRes.getUserStatus(PlayerPrefs.GetString("inputName")).isAlive(selectedCharacterId)) {
                return;
            }


            GetCharacterReq c = new GetCharacterReq();
            c.characterId = selectedCharacterId;
            StartCoroutine(getCharacter(JsonUtility.ToJson(c))); // wazaボタンなどを表示


            BattleReq req = new BattleReq();
            req.roomId = PlayerPrefs.GetString("roomId");
            req.userId = PlayerPrefs.GetString("inputName");
            req.waza = Waza.INIT_CHANGE.ToString();
            req.changeCharacterId = selectedCharacterId;
            StartCoroutine(battle(JsonUtility.ToJson(req)));
            Debug.Log("INIT_CHANGE selectedCharacterId is " + selectedCharacterId);
            return;
        }

        // command input
        if ("COMMAND_INPUT".Equals(this.battleResultStatus)) {

            // ボタンを表示
            GameObject.Find("change").GetComponent<ChangeButton>().showChangeList();
            foreach (GameObject w in wazaButtons) {
                w.SetActive(true);
            }

            if (waza == null || waza.Equals("")) {
                Debug.Log("COMMAND_INPUT waza is null or empty. skip.");
                return;
            }
            if (waza.Equals("CHANGE") && selectedCharacterId == 0) {
                Debug.Log("COMMAND_INPUT selectedCharacterId is 0. skip.");
                return;
            }
            // キャラクター情報取得
            GetCharacterReq c = new GetCharacterReq();
            c.characterId = selectedCharacterId;
            StartCoroutine(getCharacter(JsonUtility.ToJson(c))); // wazaボタンなどを表示


            BattleReq req = new BattleReq();
            req.roomId = PlayerPrefs.GetString("roomId");
            req.userId = PlayerPrefs.GetString("inputName");
            req.waza = waza;
            req.changeCharacterId = selectedCharacterId;

            StartCoroutine(battle(JsonUtility.ToJson(req)));

            return;
        } else {
            // ボタンを消す
            GameObject.Find("change").GetComponent<ChangeButton>().disabledChangeList();

            //foreach (GameObject w in wazaButtons) {
            //    w.SetActive(false);
            //}
        }


        // get result and show
        if ("GET_RESULT".Equals(this.battleResultStatus) && !showingResult) {
            GetBattleResultReq req = new GetBattleResultReq();
            req.roomId = PlayerPrefs.GetString("roomId");
            req.userId = PlayerPrefs.GetString("inputName");
            StartCoroutine(getResult(JsonUtility.ToJson(req)));
            showingResult = true;
            return;
        }




}
*/


    void Update() {
        
        if (actionList.Count > 0) {
            Actions action = actionList[0];

            bool finished = action.doAction();

            if (finished) {
                actionList.Remove(action);
            }
        }
    }





    IEnumerator battle(string json) {

        Debug.Log("BATTLE: " + json);
        string url = host + "/battle";
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

        battleRes = JsonUtility.FromJson<BattleRes>(request.downloadHandler.text);
    }


    IEnumerator getBattleResultStatus(string json) {
        Debug.Log("BattleStatus: " + json);
        string url = host + "/getBattleResultStatus";
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

        getBattleStatusRes = JsonUtility.FromJson<GetBattleStatusRes>(request.downloadHandler.text);

        string userId = PlayerPrefs.GetString("inputName");
        if (getBattleStatusRes.user1.userId.Equals(userId)) {
            GameObject.Find("change").GetComponent<ChangeButton>().updateAliveToFalse(
                 getBattleStatusRes.user1.aliveCharacter1, getBattleStatusRes.user1.aliveCharacter2, getBattleStatusRes.user1.aliveCharacter3);

            this.battleResultStatus = getBattleStatusRes.user1.battleResultStatus;
            this.selectedCharacterId = getBattleStatusRes.user1.selectedCharacterId;
        } else if (getBattleStatusRes.user2.userId.Equals(userId)) {
            GameObject.Find("change").GetComponent<ChangeButton>().updateAliveToFalse(
                getBattleStatusRes.user2.aliveCharacter1, getBattleStatusRes.user2.aliveCharacter2, getBattleStatusRes.user2.aliveCharacter3);
            this.battleResultStatus = getBattleStatusRes.user2.battleResultStatus;
            this.selectedCharacterId = getBattleStatusRes.user2.selectedCharacterId;
        }
        
    }


    IEnumerator getResult(string json) {
        Debug.Log("Resutl: " + json);
        string url = host + "/getResult";
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

        getBattleResultRes = JsonUtility.FromJson<GetBattleResultRes>(request.downloadHandler.text);
        if (!getBattleResultRes.battleResultId.Equals(this.battleResultId)) {
            BattleAction ba = GameObject.Find("battleAction").GetComponent<BattleAction>();
            //ba.setBattleRes(getBattleResultRes);
            this.battleResultId = getBattleResultRes.battleResultId;
        }
    }


}
