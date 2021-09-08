using System.Collections.Generic;
using UnityEngine;

public class Sentaku : MonoBehaviour
{

    GameObject clickedGameObject;

    // Start is called before the first frame update
    void Start()
    {
        /*        if (GameObject.Find("status") == null) {
                    return;
                }
                Status status = GameObject.Find("status").GetComponent<Status>();
                status.kimetaList = new List<string>();*/


        Status status = GameObject.Find("status").GetComponent<Status>();

        if (gameObject.GetComponent<SpriteRenderer>() == null || gameObject.GetComponent<SpriteRenderer>().sprite == null) {
            return;
        }
        string name = gameObject.GetComponent<SpriteRenderer>().sprite.name;
        if (status.kattaList.Contains(name)) {

        } else {
            this.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d) {
                clickedGameObject = hit2d.transform.gameObject;
            }

            if (clickedGameObject == gameObject) {
                this.kimeta();
            }

        }

    }


    private void kimeta() {

        string name = gameObject.GetComponent<SpriteRenderer>().sprite.name;
        Debug.Log(name);


        Status status = GameObject.Find("status").GetComponent<Status>();



        if (status.kimetaList.Count < 4 && !status.kimetaList.Contains(name)) {
            status.kimetaList.Add(name);
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        } else {
            status.kimetaList.Remove(name);
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
       

    }

    public void Risetto () {
        if (GameObject.Find("status") == null) {
            return;
        }
        Status status = GameObject.Find("status").GetComponent<Status>();
        status.kimetaList = new List<string>();
    }
}
