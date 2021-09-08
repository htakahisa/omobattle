using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller3d : MonoBehaviour
{

    private Kamerasan kamerasan;

    // Start is called before the first frame update
    void Start()
    {
        kamerasan = GameObject.Find("Main Camera").GetComponent<Kamerasan>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void upPush() {
        kamerasan.setUp(true);
    }
    public void upRelease() {
        kamerasan.setUp(false);
    }

    public void downPush() {
        kamerasan.setDown(true);
    }
    public void downRelease() {
        kamerasan.setDown(false);
    }

    public void rightPush() {
        kamerasan.setRight(true);
    }
    public void rightRelease() {
        kamerasan.setRight(false);
    }

    public void leftPush() {
        kamerasan.setLeft(true);
    }
    public void leftRelease() {
        kamerasan.setLeft(false);
    }

    public void jumpPush() {
        kamerasan.setJump(true);
    }
    public void jumpRelease() {
        kamerasan.setJump(false);
    }
}
