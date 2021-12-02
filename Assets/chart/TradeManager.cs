using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TradeManager : MonoBehaviour {

    private float okane;

    private float fee = 0.01f;

    private int tvalue = 0;
    private float tAvePrice = 0;


    private int mvalue = 0;
    private float mAvePrice = 0;

    private int hvalue = 0;
    private float hAvePrice = 0;

    private int uvalue = 0;
    private float uAvePrice = 0;

    private int yvalue = 0;
    private float yAvePrice = 0;

    private int ivalue = 0;
    private float iAvePrice = 0;

    // Start is called before the first frame update
    void Start() {


        if (GameObject.Find("status") != null) {
            Status status = GameObject.Find("status").GetComponent<Status>();
            this.okane = status.okane;
        } else {
            okane = 100000;
        }


    }
    void Update() {
        GameObject.Find("OkaneText").GetComponent<Text>().text = "お金 : " + (int)okane + " 円";


        float tProfit = GameObject.Find("Touyama").GetComponent<TouyamaLine>().getPrice() * tvalue;
        GameObject.Find("TText").GetComponent<Text>().text = "T: 数量:" + tvalue + "  平均:" + (int)tAvePrice + "  評価額:" + tProfit;

        float mProfit = GameObject.Find("Mayama").GetComponent<MayamaLine>().getPrice() * mvalue;
        GameObject.Find("MText").GetComponent<Text>().text = "M: 数量:" + mvalue + "  平均:" + (int)mAvePrice + "  評価額:" + mProfit;

        float hProfit = GameObject.Find("Haruhi").GetComponent<HaruhiLine>().getPrice() * hvalue;
        GameObject.Find("HText").GetComponent<Text>().text = "H: 数量:" + hvalue + "  平均:" + (int)hAvePrice + "  評価額:" + hProfit;

        float uProfit = GameObject.Find("Uminokami").GetComponent<UminokamiLine>().getPrice() * uvalue;
        GameObject.Find("UText").GetComponent<Text>().text = "U: 数量:" + uvalue + "  平均:" + (int)uAvePrice + "  評価額:" + uProfit;

        float yProfit = GameObject.Find("Moyashi").GetComponent<MoyashiLine>().getPrice() * yvalue;
        GameObject.Find("YText").GetComponent<Text>().text = "Y: 数量:" + yvalue + "  平均:" + (int)yAvePrice + "  評価額:" + yProfit;

        float iProfit = GameObject.Find("Index").GetComponent<IndexLine>().getPrice() * ivalue;
        GameObject.Find("IText").GetComponent<Text>().text = "I: 数量:" + ivalue + "  平均:" + (int)iAvePrice + "  評価額:" + iProfit;

        GameObject.Find("GoukeiText").GetComponent<Text>().text = "合計 : " + (int)(okane + tProfit + mProfit + hProfit + uProfit + yProfit + iProfit) + " 円";


        if (GameObject.Find("Touyama").GetComponent<TouyamaLine>().getPrice() == 0) {
            tvalue = 0;
            tAvePrice = 0;
        }
        if (GameObject.Find("Mayama").GetComponent<MayamaLine>().getPrice() == 0) {
            mvalue = 0;
            mAvePrice = 0;
        }
        if (GameObject.Find("Haruhi").GetComponent<HaruhiLine>().getPrice() == 0) {
            hvalue = 0;
            hAvePrice = 0;
        }

        if (GameObject.Find("Uminokami").GetComponent<UminokamiLine>().getPrice() == 0) {
            uvalue = 0;
            uAvePrice = 0;
        }
        if (GameObject.Find("Moyashi").GetComponent<MoyashiLine>().getPrice() == 0) {
            yvalue = 0;
            yAvePrice = 0;
        }
        if (GameObject.Find("Index").GetComponent<IndexLine>().getPrice() == 0) {
            ivalue = 0;
            iAvePrice = 0;
        }
    }

    public float getOkane() {
        return this.okane;
    }




    public void tk() {
        if (okane == 0) {
            return;
        }
        float price = GameObject.Find("Touyama").GetComponent<TouyamaLine>().getPrice();
        float kingaku = float.Parse(GameObject.Find("input").GetComponent<InputField>().text);
        if (price < 100) {
            return;
        }

        if (okane < kingaku + kingaku * fee) {
            kingaku = okane;
        }

        okane -= (kingaku + kingaku * fee);
        if (okane < 0) {
            okane = 0;
        }

        float oldSum = tAvePrice * tvalue;


        int buy = (int)(kingaku / price);
        tvalue += buy;

        tAvePrice = (oldSum + buy * price) / tvalue;
    }

    public void tu() {
        if (tvalue == 0) {
            return;
        }

        float price = GameObject.Find("Touyama").GetComponent<TouyamaLine>().getPrice();
        float sell = float.Parse(GameObject.Find("input").GetComponent<InputField>().text);

        float currentSum = tvalue * price;

        if (currentSum < sell) {
            okane += currentSum;
            tvalue = 0;
            tAvePrice = 0;

            return;
        }

        okane += sell - sell * fee;
        if (okane < 0) {
            okane = 0;
        }

        float oldSum = tAvePrice * tvalue;
        tvalue -= (int)(sell / price);


        if (tvalue <= 0) {
            tvalue = 0;
            tAvePrice = 0;
        }

    }





    public void mk() {
        if (okane == 0) {
            return;
        }
        float price = GameObject.Find("Mayama").GetComponent<MayamaLine>().getPrice();
        float kingaku = float.Parse(GameObject.Find("input").GetComponent<InputField>().text);
        if (price < 100) {
            return;
        }
        if (kingaku < price) {
            return;
        }
        if (okane < kingaku + kingaku * fee) {
            kingaku = okane;
        }

        okane -= (kingaku + kingaku * fee);
        if (okane < 0) {
            okane = 0;
        }

        float oldSum = mAvePrice * mvalue;



        int buy = (int)(kingaku / price);
        mvalue += buy;

        mAvePrice = (oldSum + buy * price) / mvalue;
    }

    public void mu() {
        if (mvalue == 0) {
            return;
        }

        float price = GameObject.Find("Mayama").GetComponent<MayamaLine>().getPrice();
        float sell = float.Parse(GameObject.Find("input").GetComponent<InputField>().text);


        float currentSum = mvalue * price;

        if (currentSum < sell) {
            okane += currentSum;
            mvalue = 0;
            mAvePrice = 0;

            return;
        }

        okane += sell - sell * fee;
        if (okane < 0) {
            okane = 0;
        }

        float oldSum = mAvePrice * mvalue;
        mvalue -= (int)(sell / price);

        if (mvalue <= 0) {
            mvalue = 0;
            mAvePrice = 0;
        }
    }





    public void hk() {
        if (okane == 0) {
            return;
        }
        float price = GameObject.Find("Haruhi").GetComponent<HaruhiLine>().getPrice();
        float kingaku = float.Parse(GameObject.Find("input").GetComponent<InputField>().text);
        if (price < 100) {
            return;
        }
        if (kingaku < price) {
            return;
        }
        if (okane < kingaku + kingaku * fee) {
            kingaku = okane;
        }

        okane -= (kingaku + kingaku * fee);
        if (okane < 0) {
            okane = 0;
        }

        float oldSum = hAvePrice * hvalue;


        int buy = (int)(kingaku / price);
        hvalue += buy;

        hAvePrice = (oldSum + buy * price) / hvalue;
    }

    public void hu() {
        if (hvalue == 0) {
            return;
        }

        float price = GameObject.Find("Haruhi").GetComponent<HaruhiLine>().getPrice();
        float sell = float.Parse(GameObject.Find("input").GetComponent<InputField>().text);


        float currentSum = hvalue * price;
        if (currentSum < sell) {
            okane += currentSum;
            hvalue = 0;
            hAvePrice = 0;

            return;
        }

        okane += sell - sell * fee;
        if (okane < 0) {
            okane = 0;
        }

        float oldSum = hAvePrice * hvalue;
        hvalue -= (int)(sell / price);

        if (hvalue <= 0) {
            hvalue = 0;
            hAvePrice = 0;
        }
    }


    public void uk() {
        if (okane == 0) {
            return;
        }
        float price = GameObject.Find("Uminokami").GetComponent<UminokamiLine>().getPrice();
        float kingaku = float.Parse(GameObject.Find("input").GetComponent<InputField>().text);
        if (price < 100) {
            return;
        }
        if (kingaku < price) {
            return;
        }
        if (okane < kingaku + kingaku * fee) {
            kingaku = okane;
        }

        okane -= (kingaku + kingaku * fee);
        if (okane < 0) {
            okane = 0;
        }

        float oldSum = uAvePrice * uvalue;


        int buy = (int)(kingaku / price);
        uvalue += buy;

        uAvePrice = (oldSum + buy * price) / uvalue;
    }

    public void uu() {
        if (uvalue == 0) {
            return;
        }

        float price = GameObject.Find("Uminokami").GetComponent<UminokamiLine>().getPrice();
        float sell = float.Parse(GameObject.Find("input").GetComponent<InputField>().text);


        float currentSum = uvalue * price;
        if (currentSum < sell) {
            okane += currentSum;
            uvalue = 0;
            uAvePrice = 0;

            return;
        }

        okane += sell - sell * fee;
        if (okane < 0) {
            okane = 0;
        }

        float oldSum = uAvePrice * uvalue;
        uvalue -= (int)(sell / price);

        if (uvalue <= 0) {
            uvalue = 0;
            uAvePrice = 0;
        }
    }


    public void yk() {
        if (okane == 0) {
            return;
        }
        float price = GameObject.Find("Moyashi").GetComponent<MoyashiLine>().getPrice();
        float kingaku = float.Parse(GameObject.Find("input").GetComponent<InputField>().text);
        if (price < 100) {
            return;
        }
        if (kingaku < price) {
            return;
        }
        if (okane < kingaku + kingaku * fee) {
            kingaku = okane;
        }

        okane -= (kingaku + kingaku * fee);
        if (okane < 0) {
            okane = 0;
        }

        float oldSum = yAvePrice * yvalue;


        int buy = (int)(kingaku / price);
        yvalue += buy;

        yAvePrice = (oldSum + buy * price) / yvalue;
    }

    public void yu() {
        if (yvalue == 0) {
            return;
        }

        float price = GameObject.Find("Moyashi").GetComponent<MoyashiLine>().getPrice();
        float sell = float.Parse(GameObject.Find("input").GetComponent<InputField>().text);


        float currentSum = yvalue * price;
        if (currentSum < sell) {
            okane += currentSum;
            yvalue = 0;
            yAvePrice = 0;

            return;
        }

        okane += sell - sell * fee;
        if (okane < 0) {
            okane = 0;
        }

        float oldSum = yAvePrice * yvalue;
        yvalue -= (int)(sell / price);

        if (yvalue <= 0) {
            yvalue = 0;
            yAvePrice = 0;
        }
    }



    public void ik() {
        if (okane == 0) {
            return;
        }
        float price = GameObject.Find("Index").GetComponent<IndexLine>().getPrice();
        float kingaku = float.Parse(GameObject.Find("input").GetComponent<InputField>().text);
        if (price < 100) {
            return;
        }
        if (kingaku < price) {
            return;
        }
        if (okane < kingaku + kingaku * fee) {
            kingaku = okane;
        }

        okane -= (kingaku + kingaku * fee);
        if (okane < 0) {
            okane = 0;
        }

        float oldSum = iAvePrice * ivalue;


        int buy = (int)(kingaku / price);
        ivalue += buy;

        iAvePrice = (oldSum + buy * price) / ivalue;
    }

    public void iu() {
        if (ivalue == 0) {
            return;
        }

        float price = GameObject.Find("Index").GetComponent<IndexLine>().getPrice();
        float sell = float.Parse(GameObject.Find("input").GetComponent<InputField>().text);


        float currentSum = ivalue * price;
        if (currentSum < sell) {
            okane += currentSum;
            ivalue = 0;
            iAvePrice = 0;

            return;
        }

        okane += sell - sell * fee;
        if (okane < 0) {
            okane = 0;
        }

        float oldSum = iAvePrice * ivalue;
        ivalue -= (int)(sell / price);

        if (ivalue <= 0) {
            ivalue = 0;
            iAvePrice = 0;
        }
    }




}
