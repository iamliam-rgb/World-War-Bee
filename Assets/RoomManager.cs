using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {


	#region Serialized Fields

	[SerializeField]
	private List<GameObject> roomsList = new List<GameObject>();

	#endregion
	
	
	#region Private Fields

	private int currentRoomIndex = 0;
	
	#endregion
	
	
	#region Monobehaviour

	public void Awake() {
		
	}

	#endregion
	
	
	#region public Methods

	public IEnumerator NextRoom() {
		if (currentRoomIndex < roomsList.Count) {
			for (int i = 0; i < roomsList.Count; i++) {
				if (i == currentRoomIndex) {
					roomsList[i].SetActive(true);

				} else {
					roomsList[i].SetActive(false);
				}
			}
			currentRoomIndex++;
		} else {
			currentRoomIndex = 0;
		}

		yield break;
	}
	
	#endregion
}
