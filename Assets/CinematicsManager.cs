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
		
		[SerializeField]
		private float m_TransitionDuration = 3f;
		
		#endregion
		
		
		#region MonoBehaviour Methods
		
		public void Update() {
			ListenForCinematicInput();
		}
		
		#endregion
		
		
		#region NonSerialized Fields
		
		private ScreenFadeManager m_ScreenFadeManager;
		
		private ElevatorMover m_ElevatorMover;
		
		#endregion
		
		
		#region Public Properites

		public float TransitionDurationTime {
			get {
				return m_TransitionDuration;
			}
			set {
				m_TransitionDuration = value;
			}
		}
		
		#endregion
		
		
		#region Private Properties

		private ScreenFadeManager ScreenFadeManager {
			get {
				return  m_ScreenFadeManager ?? GetComponent<ScreenFadeManager>();
			}
		}

		public ElevatorMover ElevatorMover {
			get {
				return m_ElevatorMover ?? GetComponent<ElevatorMover>();
			}
		}
		
		#endregion
		
		
		#region Private Methods

		private void ListenForCinematicInput() {
			// Next level
			if (Input.GetKeyDown(m_NextLevelKey) || Input.GetKeyDown(m_PreviousLevelKey)) {
				this.ScreenFadeManager.FadeOut();
			}
		}
		
		#endregion

	}
}
