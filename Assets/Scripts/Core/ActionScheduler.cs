using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
	public class ActionScheduler : MonoBehaviour
	{
		#region Fields

		MonoBehaviour _currentAction;

		#endregion

		#region MonoBehaviour Methods

		void Start()
		{
			_currentAction = null;
		}

		void Update()
		{

		}
		#endregion

		#region Public Methods

		public void StartAction(MonoBehaviour action)
		{
			if (_currentAction == action) return;

				if (_currentAction != null)
				{
					print("Cancelling Action: " + _currentAction);
				}
				_currentAction = action;
		}
		#endregion

		#region Private Methods


		#endregion
	}
}