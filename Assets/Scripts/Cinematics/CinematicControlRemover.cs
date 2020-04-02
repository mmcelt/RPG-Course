using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
	public class CinematicControlRemover : MonoBehaviour
	{
		#region Fields

		PlayableDirector _director;

		#endregion

		#region MonoBehaviour Methods

		void OnEnable()
		{
			_director = GetComponent<PlayableDirector>();
			_director.played += DisableControl;
			_director.stopped += EnableControl;
		}

		void OnDisable()
		{
			_director.played -= DisableControl;
			_director.stopped -= EnableControl;
		}
		#endregion

		#region Public Methods


		#endregion

		#region Private Methods

		void DisableControl(PlayableDirector pd)
		{
			print("DisableControl called");
		}

		void EnableControl(PlayableDirector pd)
		{
			print("EnableControl called");
		}
		#endregion
	}
}