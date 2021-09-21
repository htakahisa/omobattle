using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleAction : MonoBehaviour
{
    private GetBattleResultRes res;
    private List<ShowResult> results = new List<ShowResult>();
    private int index = 0;

    private float time;

    private float interval = 1f;

    private Text msg;


    // Start is called before the first frame update
    void Start()
    {
        msg = GameObject.Find("msg").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
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

    }
     public void setBattleRes(GetBattleResultRes res) {


        this.res = res;

        foreach (GetBattleResultRes.BattleResult r in res.results) {
            if (r.change != null) {
                this.addResult(ShowResult.of(r.change, r.change.message1, 0f));
                this.addResult(ShowResult.of(r.change, r.change.action, 2.5f));
                this.addResult(ShowResult.of(r.change, r.change.message1, 1.5f));
            }

            if (r.inTheBattle != null) {
                this.addResult(ShowResult.of(r.inTheBattle, r.inTheBattle.message1, 0f));
                this.addResult(ShowResult.of(r.inTheBattle, r.inTheBattle.action, 2.5f));
                this.addResult(ShowResult.of(r.inTheBattle, r.inTheBattle.message1, 1.5f));
            }

            if (r.beforeAttack != null) {
                this.addResult(ShowResult.of(r.beforeAttack, r.beforeAttack.message1, 0f));
                this.addResult(ShowResult.of(r.beforeAttack, r.beforeAttack.action, 2.5f));
                this.addResult(ShowResult.of(r.beforeAttack, r.beforeAttack.message1, 1.5f));
            }

            if (r.inAttack != null) {
                this.addResult(ShowResult.of(r.inAttack, r.inAttack.message1, 0f));
                this.addResult(ShowResult.of(r.inAttack, r.inAttack.action, 2.5f));
                this.addResult(ShowResult.of(r.inAttack, r.inAttack.message1, 1.5f));
            }
            if (r.afterAttack != null) {
                this.addResult(ShowResult.of(r.afterAttack, r.afterAttack.message1, 0f));
                this.addResult(ShowResult.of(r.afterAttack, r.afterAttack.action, 2.5f));
                this.addResult(ShowResult.of(r.afterAttack, r.afterAttack.message1, 1.5f));
            }
            if (r.endTheBattle != null) {
                this.addResult(ShowResult.of(r.endTheBattle, r.endTheBattle.message1, 0f));
                this.addResult(ShowResult.of(r.endTheBattle, r.endTheBattle.action, 2.5f));
                this.addResult(ShowResult.of(r.endTheBattle, r.endTheBattle.message1, 1.5f));
            }
        }
    }

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
}
