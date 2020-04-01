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
				int j = GetNextIndex(i);
				Gizmos.DrawSphere(GetWaypoint(i), _waypointGizmoSize);
				Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(j));
			}
		}

		#endregion

		#region Public Methods

		public Vector3 GetWaypoint(int i)
		{
			return transform.GetChild(i).transform.position;
		}

		public int GetNextIndex(int i)
		{
			i++;
			if (i == transform.childCount)
			{
				i = 0;
			}
			return i;
		}
		#endregion

		#region Private Methods


		#endregion
	}
}