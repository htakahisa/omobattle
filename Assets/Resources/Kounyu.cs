using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kounyu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void kau() {

        Status status = GameObject.Find("status").GetComponent<Status>();



        int kingaku = int.Parse(this.gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text.Replace("円", ""));

        if (status.okane - kingaku >= 0) {
            status.okane = status.okane - kingaku;


            string name = gameObject.name;
            status.kattaList.Add(name);
        }
        
    }
}
