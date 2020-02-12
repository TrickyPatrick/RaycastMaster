using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawColliders : MonoBehaviour {
   public Sprite spriteDebug, sprite;
   float direction;
   Vector3 dirr;
   bool isGoingRight = true, isGoingUp = true;
   private void Start () {
      Destroy (gameObject, 10);
      if (MainDrawRay.DebugMode) {
         GetComponent<SpriteRenderer> ().sprite = sprite;
      } else {
         GetComponent<SpriteRenderer> ().sprite = spriteDebug;
      }
      if (transform.position.x > 0)
         isGoingRight = false;
      if (transform.position.y > 0)
         isGoingUp = false;

      if (isGoingUp && isGoingRight) {
         direction = Random.Range (0.00f, 90.00f);
         dirr = Angles (direction);
      } else if (isGoingUp && !isGoingRight) {
         direction = Random.Range (270.00f, 360.00f);
         dirr = Angles (direction);
      } else if (!isGoingUp && !isGoingRight) {
         direction = Random.Range (270.00f, 180.00f);
         dirr = Angles (direction);
      } else {
         direction = Random.Range (180.00f, 90.00f);
         dirr = Angles (direction);
      }
      GetComponent<Rigidbody2D>().velocity = dirr*2;
   }
   private void Update () {
      transform.Rotate(new Vector3(0f,0f,1f),Space.World);
      if (MainDrawRay.DebugMode) {
         GetComponent<SpriteRenderer> ().sprite = sprite;
      } else {
         GetComponent<SpriteRenderer> ().sprite = spriteDebug;
      }
   }

   private Vector3 Angles (float angle) {
      float a = angle * Mathf.PI / 180f;
      float x = Mathf.Sin (a);
      float y = Mathf.Cos (a);
      Vector3 ab = new Vector3 (x*2, y*2, 0);
      return ab;
   }
}