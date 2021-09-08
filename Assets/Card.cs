using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour { 

    private RectTransform rect;
    private GameObject kantoku;


    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();

        this.kantoku = GameObject.Find("Kantoku");


        this.originalPosition = this.rect.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void click() {

        this.kantoku = GameObject.Find("Kantoku");
        if (this.kantoku.GetComponent<Kantoku>().getBattle()) {
            return; // 戦闘中は何もしない
        }


        this.rect.anchoredPosition = new Vector3(-130f, 0f);
        this.kantoku.GetComponent<Kantoku>().setReady1(true, this.gameObject.name, this.gameObject.GetComponent<Button>());


        // 変更の場合は1ターン使う
        if (this.kantoku.GetComponent<Kantoku>().getIsChange()) {
            kantoku.GetComponent<Kantoku>().commandInputed(JumonType.CHANGE);
            this.kantoku.GetComponent<Kantoku>().setIsChange(false);
        }
    }

    public void back() {
        this.rect.anchoredPosition = this.originalPosition;
    }


    public void kougekiAction() {

        // 現在のサイズを取得
        float h = this.rect.sizeDelta.x;
        float w = this.rect.sizeDelta.y;

        
         resize(h, w);
        
    }

    private async void resize(float h, float w) {

        for (int i = 0; i < 10; i++) {
            if (i % 2 == 0) { 
                this.rect.sizeDelta = new Vector2(h * 1.1f, w * 1.1f);
            } else {
                this.rect.sizeDelta = new Vector2(h, w);
            }
            await System.Threading.Tasks.Task.Delay(100);
        }
        this.rect.sizeDelta = new Vector2(h, w);
    }

    public void damageAction() {
        this.damageMove();
    }

    private async void damageMove() {

        for (int i = 0; i < 10; i++) {
            if (i %2 == 0) {
                this.rect.anchoredPosition = new Vector3(-130f, 10f);
            } else {
                this.rect.anchoredPosition = new Vector3(-130f, 0f);
            }
            
            await System.Threading.Tasks.Task.Delay(100);
        }
        this.rect.anchoredPosition = new Vector3(-130f, 0f);
    }
}
