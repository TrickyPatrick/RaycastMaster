using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    float rand, rand1, rand2, rand3, rand4;
    public float TIMEbetweenEVERYspawn = 0.5f;
    public GameObject Instance;
    float timer;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer > TIMEbetweenEVERYspawn) {
            rand = Random.Range (1, 5);
            switch (rand) {
                case 1:
                    rand1 = Random.Range (8.00f, -8.00f);
                    Instantiate (Instance, new Vector3 (-11, rand1, 0), Quaternion.identity);
                    break;
                case 2:
                    rand2 = Random.Range (8.00f, -8.00f);
                    Instantiate (Instance, new Vector3 (11, rand2, 0), Quaternion.identity);
                    break;
                case 3:
                    rand3 = Random.Range (10.00f, -10.00f);
                    Instantiate (Instance, new Vector3 (rand3, 7, 0), Quaternion.identity);
                    break;
                default:
                    rand4 = Random.Range (10.00f, -10.00f);
                    Instantiate (Instance, new Vector3 (rand4, -7, 0), Quaternion.identity);
                    break;
            }
            timer = 0;
        }
    }
}