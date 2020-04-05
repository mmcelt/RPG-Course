using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.SceneManagement
{
	public class Fader : MonoBehaviour
	{
		#region Fields

		CanvasGroup _canvasGroup;

		#endregion

		#region MonoBehaviour Methods

		void Start()
		{
			_canvasGroup = GetComponent<CanvasGroup>();
			//StartCoroutine(FadeOutIn());
		}
		#endregion

		#region Public Methods

		public void FadeOutImmediate()
		{
			_canvasGroup.alpha = 1f;
		}

		public IEnumerator FadeOut(float time)
		{
			while (_canvasGroup.alpha < 1)
			{
				_canvasGroup.alpha += Time.deltaTime / time;
				yield return null;
			}
		}

		public IEnumerator FadeIn(float time)
		{
			while (_canvasGroup.alpha > 0)
			{
				_canvasGroup.alpha -= Time.deltaTime / time;
				yield return null;
			}
		}
		#endregion

		#region Private Methods
		//IEnumerator FadeOutIn()
		//{
		//	yield return FadeOut(3f);
		//	print("Faded Out...");
		//	yield return FadeIn(1f);
		//	print("Faded back in...");
		//}
		#endregion
	}
}