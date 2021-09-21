using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters
{

    private Dictionary<long, string> map = new Dictionary<long, string>();


    public static Characters of() {
        Characters c = new Characters();

        c.map[1] = "touyama";
        c.map[2] = "omoko";
        c.map[3] = "mapTouyamaOmoko";


        return c;
    }



    public string getName(long id) {

        return map[id];

    }





}
