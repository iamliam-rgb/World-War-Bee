using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRadius : MonoBehaviour {

	public int Damage = 1;
	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Enemy") {
			Health health = other.gameObject.GetComponent<Health>();
			health.TakeDamage(Damage);
		}
	}

}
