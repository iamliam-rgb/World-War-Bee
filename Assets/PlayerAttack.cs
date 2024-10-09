using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
   public float AttackRadiusValue;
   public GameObject AttackRadiusGameObject;
   public KeyCode AttackKeyCode = KeyCode.Space;
   public bool doOnce;
   
   public void Update() {
      if (Input.GetKeyDown(AttackKeyCode)) {
         doOnce = false;
       
         if (doOnce == false) {
            AttackRadiusGameObject.SetActive(true);
            doOnce = true;
         }
      } else {
         AttackRadiusGameObject.SetActive(false);
      }
   }
}
