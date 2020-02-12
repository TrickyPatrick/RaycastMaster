using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDrawRay : MonoBehaviour {
    public int nbrAngle = 360;
    float[] distance;
    RaycastHit2D[] hit;
    Vector2[] dir;
    Rigidbody2D rb2D;
    public LayerMask layer;
    public Sprite spriteDebug, sprite;
    int i = 0, j = 0;
    float angle, diffangle=0;
    public static bool DebugMode = false;

    private void Start () {
        rb2D = GetComponent<Rigidbody2D>();;
        dir = new Vector2[nbrAngle];
        hit = new RaycastHit2D[nbrAngle];
        distance = new float[nbrAngle];
    }
    private void Update () {
        if (Input.GetKeyDown (KeyCode.A)) {
            if (DebugMode) {
                DebugMode = false;
                GetComponent<SpriteRenderer> ().sprite = sprite;
            } else {
                DebugMode = true;
                GetComponent<SpriteRenderer> ().sprite = spriteDebug;
            }
        }
        for (i = 0; i <= nbrAngle - 1; i++) {
            angle = 360f / nbrAngle * i + diffangle;
            angle = angle * Mathf.PI / 180f;
            float x = Mathf.Sin (angle);
            float y = Mathf.Cos (angle);
            dir[i] = new Vector2 (x, y);
            hit[i] = Physics2D.Raycast (transform.position, dir[i], 100, layer);
            if (hit[i].collider != null) {
                distance[i] = Mathf.Abs (Vector2.Distance (hit[i].point, transform.position));
            } else {
                distance[i] = 100.01f;
            }
        }
        angle = 0; diffangle +=0.3f;
        i = 0;
        FindMyWay ();
    }
    private void OnDrawGizmos () {
        if (DebugMode) {
            for (j = 0; j <= nbrAngle - 1; j++) {
                if (distance[j] != 100.01f) {
                    Debug.DrawRay (transform.position, dir[j] * distance[j], Color.green);
                    Gizmos.DrawWireSphere (hit[j].point, 0.2f);
                } else
                    Debug.DrawRay (transform.position, dir[j] * distance[j], Color.red);
            }
            j = 0;
        }

    }

    private void FindMyWay () {
        float distanceToBeat = 100;
        int index=0;
        for (int k = 0; k <= nbrAngle - 1; k++)
        {
            if(distance[k]< distanceToBeat)
                {
                    index = k;
                    distanceToBeat = distance[k];
                }
        }
        rb2D.velocity = new Vector3(-dir[index].x*4,-dir[index].y*3,0);
    }
}