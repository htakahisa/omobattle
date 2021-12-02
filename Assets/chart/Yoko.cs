using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yoko : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start() {
        // LineRendererコンポーネントをゲームオブジェクトにアタッチする
        var lineRenderer = gameObject.GetComponent<LineRenderer>();

        lineRenderer.startWidth = 10.1f;                   // 開始点の太さを0.1にする
        lineRenderer.endWidth = 10.1f;

        var positions = new Vector3[300];

        var index = 0;
        for (int i = 0; i < 48; i++) {
            positions[index++] = new Vector3(i * 100, 0 , 0);

            if (i % 5 == 0) {
                positions[index++] = new Vector3(i * 100 ,50, 0);
            } else {
                positions[index++] = new Vector3(i * 100, 30, 0);
            }
            positions[index++] = new Vector3(i * 100, 0, 0);

        }

        // 点の数を指定する
        lineRenderer.positionCount = positions.Length;

        // 線を引く場所を指定する
        lineRenderer.SetPositions(positions);
    }
}
