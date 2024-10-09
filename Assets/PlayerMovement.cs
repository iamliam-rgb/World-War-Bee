using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
   
	public float m_Speed;
	public float m_MaxSpeed;
	public Rigidbody m_Rigidbody;


	public KeyCode m_LeftKey;
	public KeyCode m_RightKey;
	public KeyCode m_UpKey;
	public KeyCode m_DownKey;

	private void FixedUpdate() {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(horizontal, 0, vertical);
		Vector3 normalizedVector = Vector3.Normalize(movement);

		if (m_Rigidbody.velocity.magnitude < m_MaxSpeed) {
			m_Rigidbody.AddForce(normalizedVector * m_Speed);
		}
	}
}
