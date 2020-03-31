using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
	public class ActionScheduler : MonoBehaviour
	{
		#region Fields

		IAction _currentAction;

		#endregion

		#region MonoBehaviour Methods

		void Start()
		{
			_currentAction = null;
		}
		#endregion

		#region Public Methods

		public void StartAction(IAction action)
		{
			if (_currentAction == action) return;

			if (_currentAction != null)
			{
				_currentAction.Cancel();
			}
			_currentAction = action;
		}

		public void CancelCurrentAction()
		{
			StartAction(null);
		}
		#endregion

		#region Private Methods


		#endregion
	}
}