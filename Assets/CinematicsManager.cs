namespace Cinematics.Manager {
	using System;
	using ScreenEffects;
	using UnityEngine;

	[RequireComponent(typeof(ScreenFadeManager))]
	public class CinematicsManager : MonoBehaviour {

		
		#region Serialized Fields

		[SerializeField]
		private KeyCode m_NextLevelKey = KeyCode.Period;
		
		[SerializeField]
		private KeyCode m_PreviousLevelKey = KeyCode.Comma;
		
		#endregion
		
		
		#region MonoBehaviour Methods
		
		public void Update() {
			ListenForCinematicInput();
		}
		
		#endregion
		
		#region NonSerialized Fields
		
		private ScreenFadeManager _screenFadeManager;
		
		#endregion
		
		
		#region Private Properties

		private ScreenFadeManager ScreenFadeManager {
			get {
				return  _screenFadeManager ?? GetComponent<ScreenFadeManager>();
			}
		}
		
		#endregion
		
		
		#region Private Methods

		private void ListenForCinematicInput() {
			// Next level
			if (Input.GetKey(m_NextLevelKey) || Input.GetKey(m_PreviousLevelKey)) {
				this.ScreenFadeManager.FadeOut();
			}
		}
		
		#endregion

	}
}
