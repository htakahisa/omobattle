using UnityEngine;
using System.Text;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine.UI;

public class WaigingRoom : MonoBehaviour
{

    private string host = "http://192.168.11.58:20001";

    private CreateRoomRes createRoomRes;

    private float time = 2f;
    private float interval = 3f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        if (time < interval) {
            return;
        }
        time = 0;

        // create room
        if (createRoomRes == null || !createRoomRes.ready) {
            CreateRoomReq createRoomReq = new CreateRoomReq();
            createRoomReq.userId = PlayerPrefs.GetString("inputName");

            string[] characters = PlayerPrefs.GetString("choose").Split(',');
            Debug.Log(characters[0]);
            createRoomReq.characterId1 = long.Parse(characters[0]);
            createRoomReq.characterId2 = long.Parse(characters[1]);
            createRoomReq.characterId3 = long.Parse(characters[2]);
            StartCoroutine(createRoom(JsonUtility.ToJson(createRoomReq)));


        }

        if (createRoomRes != null && createRoomRes.ready) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("onlineBattle");
        }

    }


    IEnumerator createRoom(string json) {
        Debug.Log(json);
        string url = host + "/createRoom";

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
        PlayerPrefs.SetString("roomId", createRoomRes.roomId);
        PlayerPrefs.Save();
    }
}
