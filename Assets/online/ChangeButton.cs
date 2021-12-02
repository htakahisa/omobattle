using System;
using System.Collections;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;

public class ChangeButton : MonoBehaviour
{

    private GameObject[] changes;
    private Boolean[] alive = { true, true, true };
    // Start is called before the first frame update
    void Start()
    {
        changes = GameObject.FindGameObjectsWithTag("change");
        if (changes == null || changes.Length == 0) {
            return;
        }
        string[] characters = PlayerPrefs.GetString("choose").Split(',');

        //foreach (GameObject c in changes) {

        //    c.SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showChangeList() {
        BattleAction ba = GameObject.Find("battleAction").GetComponent<BattleAction>();
        ba.toggleChangeButton();

    }

    public void disabledChangeList() {

    }


    public void updateAliveToFalse(long characterId) {
        string[] characters = PlayerPrefs.GetString("choose").Split(',');

        int index = 0;
        foreach (string c in characters) {
            if (long.Parse(c) == characterId) {
                alive[index] = false;
                index++;
            }
        }
    }

    public void updateAliveToFalse(bool b1, bool b2, bool b3) {
        this.alive[0] = b1;
        this.alive[1] = b2;
        this.alive[2] = b3;
    }





    IEnumerator getAllCharacter(string json) {
        Debug.Log("Character: " + json);
        string url = Battle.host + "/getAllCharacter";
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

        GetAllCharacterRes getCharacterRes = JsonUtility.FromJson<GetAllCharacterRes>(request.downloadHandler.text);

        string[] characters = PlayerPrefs.GetString("choose").Split(',');

        changes[0].GetComponent<UnityEngine.UI.Image>().sprite =
    Resources.Load<Sprite>(getCharacterRes.getName(long.Parse(characters[0])));
        changes[1].GetComponent<UnityEngine.UI.Image>().sprite =
            Resources.Load<Sprite>(getCharacterRes.getName(long.Parse(characters[1])));
        changes[2].GetComponent<UnityEngine.UI.Image>().sprite =
            Resources.Load<Sprite>(getCharacterRes.getName(long.Parse(characters[2])));
        changes[3].GetComponent<UnityEngine.UI.Image>().sprite =
            Resources.Load<Sprite>(getCharacterRes.getName(long.Parse(characters[3])));

    }
}
