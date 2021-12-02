using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    private float time;

    private TouyamaLine touyamaLine;
    private MayamaLine mayamaLine;
    private HaruhiLine hl;
    private UminokamiLine ul;
    private MoyashiLine ml;
    private IndexLine il;


    // Start is called before the first frame update
    void Start()
    {
        touyamaLine = GameObject.Find("Touyama").GetComponent<TouyamaLine>();
        mayamaLine = GameObject.Find("Mayama").GetComponent<MayamaLine>();
         hl = GameObject.Find("Haruhi").GetComponent<HaruhiLine>();
        ul = GameObject.Find("Uminokami").GetComponent<UminokamiLine>();
        ml = GameObject.Find("Moyashi").GetComponent<MoyashiLine>();
        il = GameObject.Find("Index").GetComponent<IndexLine>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 3.0) {
            time = 0;

            if (touyamaLine.getList().Count > 150) {
                touyamaLine.resetList();
                mayamaLine.resetList();
                hl.resetList();
                ul.resetList();
                ml.resetList();
                il.resetList();
            }

            touyamaLine.add();
            mayamaLine.add();
            hl.add();
            ul.add();
            ml.add();
            il.add(this.getIndexAverage());

        }
    }


    public float getIndexAverage() {
        List<float> plist = new List<float>();
        //if (touyamaLine.getPrice() > 0) {
        plist.Add(touyamaLine.getPrice());
        //}
        //if (mayamaLine.getPrice() > 0) {
        plist.Add(mayamaLine.getPrice());
        //}
        //if (hl.getPrice() > 0) {
        plist.Add(hl.getPrice());
        //}
        //if (ul.getPrice() > 0) {
        plist.Add(ul.getPrice());
        //}
        //if (ml.getPrice() > 0) {
        plist.Add(ml.getPrice());
        //}

        float sum = 0;
        foreach (float p in plist) {
            sum += p;
        }

        return sum / plist.Count;
    }
}
