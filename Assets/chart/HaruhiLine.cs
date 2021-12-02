﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HaruhiLine : MonoBehaviour {
    private float price = 0;
    private List<float> kakakuList = new List<float>();
    private LineRenderer lineRenderer;
    private bool isZero = false;

    // Start is called before the first frame update
    void Start() {
        // LineRendererコンポーネントをゲームオブジェクトにアタッチする
        lineRenderer = gameObject.GetComponent<LineRenderer>();

        lineRenderer.startWidth = 10.1f;                   // 開始点の太さを0.1にする
        lineRenderer.endWidth = 10.1f;

        price = Random.Range(200, 800);



    }

    // Update is called once per frame
    void Update() {

    }


    public void add() {
        price += this.getAddPrice();
        if (price <= 0 || isZero) {
            //isZero = true;
            price = 0;
        }
        kakakuList.Add(price);


        this.showText();



        var positions = new Vector3[500];

        for (int i = 0; i < kakakuList.Count; i++) {
            float kakaku = kakakuList[i];
            positions[i] = new Vector3(i * 20, kakaku);
        }

        // 点の数を指定する
        lineRenderer.positionCount = kakakuList.Count;
        // 線を引く場所を指定する
        lineRenderer.SetPositions(positions);

    }

    private float getAddPrice() {
        float add = 0;
        if (Random.Range(1, 20) == 3) {
            add = Random.Range(-10, 300);
        } else if (Random.Range(1, 50) == 4) {
            add = Random.Range(-300, 10);
        } else {
            add = Random.Range(-100, 100);
        }

        return add;
    }

    private void showText() {
        GameObject.Find("HaruhiText").GetComponent<Text>().text = " はるひ工業: " + price;
    }

    public float getPrice() {
        return this.price;
    }

    public List<float> getList() {
        return this.kakakuList;
    }

    public void resetList() {
        this.kakakuList.RemoveRange(0, 120);
    }

}
