using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float health = 3;
	
	public void TakeDamage(int damage) {
		health -= damage;

		if (health <= 0) {
			gameObject.SetActive(false);
		}
	}

}
