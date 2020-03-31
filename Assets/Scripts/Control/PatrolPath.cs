using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
	public class PatrolPath : MonoBehaviour
	{
		#region Fields

		const float _waypointGizmoSize = 0.25f;

		#endregion

		#region MonoBehaviour Methods

		void Start()
		{

		}

		void OnDrawGizmos()
		{
			for (int i = 0; i < transform.childCount; i++)
			{
				Gizmos.DrawSphere(transform.GetChild(i).transform.position, _waypointGizmoSize);
			}
		}
		#endregion

		#region Public Methods


		#endregion

		#region Private Methods


		#endregion
	}
}