using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
	public class CinematicTrigger : MonoBehaviour
	{
		#region Fields

		bool _alreadyTriggered;

		#endregion

		#region MonoBehaviour Methods

		void OnTriggerEnter(Collider other)
		{
			if (!other.CompareTag("Player")) return;

			if (!_alreadyTriggered)
			{
				_alreadyTriggered = true;
				GetComponent<PlayableDirector>().Play();
			}
		}
		#endregion

		#region Public Methods


		#endregion

		#region Private Methods


		#endregion
	}
}