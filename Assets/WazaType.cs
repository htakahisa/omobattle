using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WazaType
{

    // 効果抜群
    Dictionary<Type, List<Type>> goodList = new Dictionary<Type, List<Type>>();

    // 効果はいま一つ
    Dictionary<Type, List<Type>> badList = new Dictionary<Type, List<Type>>();

    // Start is called before the first frame update
    public WazaType ()
    {
        
        // 効果抜群
       
        goodList.Add(Type.MIZU, new List<Type> { Type.HONOO });
        goodList.Add(Type.DENKI, new List<Type> { Type.HUTUU });
        goodList.Add(Type.ZIMEN, new List<Type> { Type.HONOO });
        goodList.Add(Type.HIKARI, new List<Type> { Type.AKU });
        goodList.Add(Type.DENSETU, new List<Type> { Type.HONOO, Type.MIZU, Type.ZIMEN, Type.DENKI, Type.HIKOU, Type.MIZU, Type.HUTUU, Type.AKU, Type.HIKARI, });


        // 効果はいまひとつ
        badList.Add(Type.HONOO, new List<Type> { Type.MIZU, Type.ZIMEN });
        badList.Add(Type.MIZU, new List<Type> { Type.ZIMEN });
        badList.Add(Type.HUTUU, new List<Type> { Type.DENKI });
        badList.Add(Type.DENKI, new List<Type> { Type.DENKI });
    }


    public float getTypeRate(Type fromType, Type toType) {
        float rate = 1;

        if (goodList.ContainsKey(fromType) && goodList[fromType].Contains(toType)) {
            rate += 0.5f;
        }

        if (badList.ContainsKey(fromType) && badList[fromType].Contains(toType)) {
            rate -= 0.5f;
        }

        return rate;
    }

}

public enum Type {
    HONOO,  //炎
    MIZU, // 水
    ZIMEN, // 地面
    DENKI, // 電気
    HIKOU,  // 飛行
    HUTUU,  // ノーマル
    AKU,  // 悪
    HIKARI,  // 光
    DENSETU,　//　伝説
    NON
}
