namespace Cinematics.ScreenEffects {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Serialization;
	using UnityEngine.UIElements;

	public class ScreenFadeManager : MonoBehaviour {


		#region Serialized Fields

		[SerializeField]
		private CanvasGroup m_UIFadeoutGroup;
		
		[SerializeField]
		private float m_FadeoutDuration = 0.5f;
		
		[SerializeField]
		private float m_FadeInDuration = 0.5f;

		#endregion
		
		
		#region  Private Properties
		
		private IEnumerator FadeoutCoroutine {
			get {
				return m_FadeoutCoroutine;
			}
			set {
				m_FadeoutCoroutine = value;
			}
		}

		private IEnumerator FadeInCoroutine {
			get {
				return m_FadeInCoroutine;
			}
			set {
				m_FadeInCoroutine = value;
			}
		}
		
		#endregion
		
		
		#region NonSerialized Fields
		
		[NonSerialized]
		private IEnumerator m_FadeoutCoroutine;

		[NonSerialized]
		private IEnumerator m_FadeInCoroutine;
		
		#endregion
		
		
		#region Public Methods

		public void FadeOut() {
			if (this.FadeoutCoroutine != null) {
				StopAllCoroutines();
				this.FadeoutCoroutine = null;
			}

			this.FadeoutCoroutine = FadeoutCoroutineImpl();
			StartCoroutine(this.FadeoutCoroutine);
		}

		public void FadeIn() {
			if (this.FadeInCoroutine != null) {
				StopAllCoroutines();
				this.FadeInCoroutine = null;
			}
			
			this.FadeInCoroutine = FadeInCoroutineImpl();
			StartCoroutine(this.FadeInCoroutine);
		}
		
		#endregion
		
		#region Private Methods

		private IEnumerator FadeoutCoroutineImpl() {
			// Set Alpha
			m_UIFadeoutGroup.alpha = 0;
			
			float alpha = 0;
			
			while (alpha < 1) {
				alpha += Time.deltaTime / m_FadeoutDuration;
				m_UIFadeoutGroup.alpha = alpha;
			}
			
			// Finalize Alpha
			m_UIFadeoutGroup.alpha = 1;

			yield break;
		}

		private IEnumerator FadeInCoroutineImpl() {
			yield return new WaitForSeconds(m_FadeInDuration);
		}
		
		#endregion

		
	}
}
