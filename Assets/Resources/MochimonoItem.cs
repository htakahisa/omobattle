using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MochimonoItem : MonoBehaviour
{

    private Boolean isSelected;

    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        this.originalPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void click() {

        if (!isSelected) {
            Status status = GameObject.Find("status").GetComponent<Status>();

            float x = 0;
            if (status.itemList.Count == 0) {
                x = -7;
            } else if (status.itemList.Count == 1) {
                x = -2.3f;
            } else if (status.itemList.Count == 2) {
                x = 2.3f;
            } else if (status.itemList.Count == 3) {
                x = 7;
            }


            // 移動
            gameObject.transform.position = new Vector3(x, gameObject.transform.position.y + 2.3f, gameObject.transform.position.z);

            ItemType itemType = (ItemType)Enum.Parse(typeof(ItemType), gameObject.name);

            status.itemList.Add(itemType);
            isSelected = true;

        }
    }


}
