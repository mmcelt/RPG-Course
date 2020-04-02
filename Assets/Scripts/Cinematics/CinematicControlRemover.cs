using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using RPG.Core;
using RPG.Control;

namespace RPG.Cinematics
{
	public class CinematicControlRemover : MonoBehaviour
	{
		#region Fields

		PlayableDirector _director;
		GameObject _player;

		#endregion

		#region MonoBehaviour Methods

		void OnEnable()
		{
			_player = GameObject.FindWithTag("Player");
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
			_player.GetComponent<ActionScheduler>().CancelCurrentAction();
			_player.GetComponent<PlayerController>().enabled = false;
		}

		void EnableControl(PlayableDirector pd)
		{
			_player.GetComponent<PlayerController>().enabled = true;
		}
		#endregion
	}
}