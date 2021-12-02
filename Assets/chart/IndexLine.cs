using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndexLine : MonoBehaviour {
    private float price = 0;
    private List<float> kakakuList = new List<float>();
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start() {
        // LineRendererコンポーネントをゲームオブジェクトにアタッチする
        lineRenderer = gameObject.GetComponent<LineRenderer>();

        lineRenderer.startWidth = 10.1f;                   // 開始点の太さを0.1にする
        lineRenderer.endWidth = 10.1f;

    }

    // Update is called once per frame
    void Update() {

    }

    public void add(float price) {
        this.price = (int)price;
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

    private void showText() {


        GameObject.Find("IndexText").GetComponent<Text>().text = " INDEX: " + price;
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
