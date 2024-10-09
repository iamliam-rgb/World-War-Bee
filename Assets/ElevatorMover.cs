using System.Collections;
using System.Collections.Generic;
using Cinematics.Manager;
using UnityEngine;

public class ElevatorMover : MonoBehaviour {

	public Transform Elevator;
	public float speed;
	public float height;
	public float topHeight;
	
	public bool doOnce = false;
	
	public void MoveElevatorMiddleToBottom() {
		doOnce = false;
		height -= Time.deltaTime * speed;
		Elevator.transform.position = new Vector3(Elevator.transform.position.x, height, Elevator.transform.position.z);
	}

	public void MoveElevatorTopToMiddle() {
		if (!doOnce) {
			Elevator.transform.position = new Vector3(Elevator.transform.position.x, topHeight, Elevator.transform.position.z);
			doOnce = true;
			height = topHeight;
		}
		
		height -= Time.deltaTime * speed;

		if (height > 0) {
			Elevator.transform.position = new Vector3(Elevator.transform.position.x, height, Elevator.transform.position.z);
		} else {
			height = 0;
		}
	}

	public void SetElevatorHeight(float height) {
		Elevator.transform.position = new Vector3(Elevator.transform.position.x, height, Elevator.transform.position.z);
	}
}
