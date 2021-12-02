using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAllCharacterRes 
{

    public List<GetCharacterRes> characterResList;


    public string getName(long characterId) {

        foreach (GetCharacterRes res in characterResList) {
            if (res.id == characterId) {
                return res.name;
            }
        }
        return "????";
    }
}
