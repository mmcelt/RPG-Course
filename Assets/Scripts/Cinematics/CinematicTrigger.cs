using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using RPG.Saving;

namespace RPG.Cinematics
{
	public class CinematicTrigger : MonoBehaviour, ISaveable
	{
		#region Fields

		bool _alreadyTriggered;


		#endregion

		#region MonoBehaviour Methods

		void Start()
		{
			_alreadyTriggered = true;
		}

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

		public object CaptureState()
		{
			return _alreadyTriggered;
		}

		public void RestoreState(object state)
		{
			_alreadyTriggered = (bool)state;
		}
		#endregion

		#region Private Methods


		#endregion
	}
}