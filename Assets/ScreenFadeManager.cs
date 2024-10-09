namespace Cinematics.ScreenEffects {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using Manager;
	using UnityEngine;
	using UnityEngine.Serialization;
	using UnityEngine.UIElements;

	public class ScreenFadeManager : MonoBehaviour {


		#region Serialized Fields

		[SerializeField]
		private CanvasGroup m_UIFadeoutGroup;
		
		[SerializeField]
		private CinematicsManager m_CinematicsManager;

		#endregion
		
		
		#region NonSerialized Fields
		
		[NonSerialized]
		private IEnumerator m_FadeoutCoroutine;

		[NonSerialized]
		private IEnumerator m_FadeInCoroutine;
		
		[NonSerialized]
		private bool m_FadeoutRunning;

		[NonSerialized]
		private bool m_FadeInRunning;
		
		#endregion
		
		
		#region Public Methods

		public void FadeOut() {
			m_FadeoutRunning = true;
		}

		public void FadeIn() {
			m_FadeInRunning = true;
		}
		
		#endregion
		
		
		#region Monobehaviour Methods

		public void Update() {
			if (m_FadeoutRunning && m_UIFadeoutGroup.alpha < 1f) {
				m_UIFadeoutGroup.alpha += Time.deltaTime / m_CinematicsManager.TransitionDurationTime;
				m_CinematicsManager.ElevatorMover.MoveElevatorMiddleToBottom();
			} else {
				m_FadeoutRunning = false;
				FadeIn();
			}

			if (m_FadeInRunning && m_UIFadeoutGroup.alpha > 0f) {
				m_UIFadeoutGroup.alpha -= Time.deltaTime / m_CinematicsManager.TransitionDurationTime;
				m_CinematicsManager.ElevatorMover.MoveElevatorTopToMiddle();
			} else {
				m_FadeInRunning = false;
			}
		}

		#endregion
		
		
	}
}
