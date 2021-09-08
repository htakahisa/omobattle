using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void kougeki() {
        GameObject kantoku = GameObject.Find("Kantoku");
        if (!kantoku.GetComponent<Kantoku>().getIsButtonActive()) {
            return;
        }

        // 戦闘中
        //kantoku.GetComponent<Kantoku>().commandInputed(KougekiType.KOUGEKI, JumonType.NON);

        kantoku.GetComponent<Kantoku>().showCommand(false);
        kantoku.GetComponent<Kantoku>().showCommand2(true);

    }

    public void magic() {
        GameObject kantoku = GameObject.Find("Kantoku");
        if (!kantoku.GetComponent<Kantoku>().getIsButtonActive()) {
            return;
        }

        kantoku.GetComponent<Kantoku>().showCommand(false);
        kantoku.GetComponent<Kantoku>().showCommand2(true);

    }

    public void change() {
        GameObject kantoku = GameObject.Find("Kantoku");
        if (!kantoku.GetComponent<Kantoku>().getBattle()) {
            return; // 戦闘中 以外は何もしない
        }


        kantoku.GetComponent<Kantoku>().setBattle(false);

        // kantoku に味方の位置を戻してもらう
        kantoku.GetComponent<Kantoku>().changeBackMikata();

        // 交代中にする
        kantoku.GetComponent<Kantoku>().setIsChange(true);

        // こだわり系アイテム無効
        kantoku.GetComponent<Kantoku>().getMikata().setIsKodawari(false);

        // 1ターン終了
        kantoku.GetComponent<Kantoku>().showCommand(false);
        kantoku.GetComponent<Kantoku>().showCommand2(false);

        
    }

    public void daimax() {
        GameObject kantoku = GameObject.Find("Kantoku");
        if (!kantoku.GetComponent<Kantoku>().getBattle()) {
            return; // 戦闘中 以外は何もしない
        }
        kantoku.GetComponent<Kantoku>().mikataDaimax();

        GameObject.Find("daimaxButton").SetActive(false);
    }


}
