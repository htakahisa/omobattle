using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command2 : MonoBehaviour
{

    private JumonType jumonType;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void setJumonType(JumonType jumonType) {
        this.jumonType = jumonType;
    }

    public void modoru() {
        GameObject kantoku = GameObject.Find("Kantoku");
        kantoku.GetComponent<Kantoku>().showCommand(true);
        kantoku.GetComponent<Kantoku>().showCommand2(false);
    }

    public void click() {
        GameObject timer = GameObject.Find("timer");
        GameObject kantoku = GameObject.Find("Kantoku");

        Charactor mikata = kantoku.GetComponent<Kantoku>().getMikata();
        if (mikata.getItemType() == ItemType.KODAWARISUKAFU || mikata.getItemType() == ItemType.KODAWARIHATIMAKI) {
            if (mikata.getIsKodawari() && jumonType != mikata.getJumonTypeKodawari()) {
                mikata.msg("その技は出せない!!");
                return;
            }
            mikata.setIsKodawari(true);
            mikata.setJumonTypeKodawari(jumonType);
        }


        kantoku.GetComponent<Kantoku>().commandInputed(jumonType);
        timer.GetComponent<TimeCounter>().stop();

    }
}
