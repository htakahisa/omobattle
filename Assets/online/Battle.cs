using UnityEngine;
using System.Text;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class Battle : MonoBehaviour
{

    private CreateRoomReq createRoomReq;
    private CreateRoomRes createRoomRes;
    private GetBattleStatusRes getBattleStatusRes;
    private BattleRes battleRes;

    private long selectedCharacterId;
    private bool firstInBattle = true;

    private float time;
    private float interval = 5f;


    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("me").GetComponentInChildren<UnityEngine.UI.Text>().text = "";
        GameObject.Find("op").GetComponentInChildren<UnityEngine.UI.Text>().text = "";



    }

    // Update is called once per frame
    void Update() {

        time += Time.deltaTime;

        if (time < interval) {
            return;
        }
        time = 0;

        if (createRoomRes == null || !createRoomRes.ready) {
            // room 作成
            createRoomReq = new CreateRoomReq();
            createRoomReq.userId = PlayerPrefs.GetString("inputName");

            string[] characters = PlayerPrefs.GetString("choose").Split(',');

            createRoomReq.characterId1 = long.Parse(characters[0]);
            createRoomReq.characterId2 = long.Parse(characters[1]);
            createRoomReq.characterId3 = long.Parse(characters[2]);

            selectedCharacterId = createRoomReq.characterId1;

            StartCoroutine(createRoom(JsonUtility.ToJson(createRoomReq)));
            return;

        }

        // character 選択 (最初は自動で設定する)
        if (GameObject.Find("me").GetComponent<UnityEngine.UI.Image>().sprite == null || firstInBattle) {
            BattleReq req = new BattleReq();
            req.roomId = createRoomRes.roomId;
            req.userId = PlayerPrefs.GetString("inputName");
            req.waza = Waza.INIT_CHANGE.ToString();
            req.changeCharacterId = selectedCharacterId;

            StartCoroutine(battle(JsonUtility.ToJson(req)));

            firstInBattle = false;

            Resources.Load("touyama");
            GameObject.Find("me").GetComponent<UnityEngine.UI.Image>().color = new Color(1f, 1f, 1f, 1f);
            GameObject.Find("me").GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("touyama");
        }

        // 技選択
        if (battleRes != null && battleRes.battleResultStatus.Equals("COMMAND_WAITING")) { 

        }

        // メッセージなど
        if (battleRes != null && battleRes.battleResultStatus.Equals("FINISHED")) {
        // 結果取得

        }

    }






    IEnumerator createRoom(string json) {
        string url = "http://localhost:20001/createRoom";

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

        createRoomRes = JsonUtility.FromJson<CreateRoomRes>(request.downloadHandler.text);
    }


    IEnumerator battle(string json) {
        string url = "http://localhost:20001/battle";
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
        string url = "http://localhost:20001/getBattleResultStatus";
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
    }


}
