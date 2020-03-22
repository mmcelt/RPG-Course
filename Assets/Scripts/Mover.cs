using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
	#region Fields

	[SerializeField] Transform _target;

	NavMeshAgent _navAgent;

	#endregion

	#region MonoBehaviour Methods

	void Start() 
	{
		_navAgent = GetComponent<NavMeshAgent>();
	}
	
	void Update() 
	{
		if (Input.GetMouseButtonDown(0))
		{
			MoveToCursor();
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods

	void MoveToCursor()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		bool hasHit = Physics.Raycast(ray, out hit);

		if (hasHit)
		{
			_navAgent.destination = hit.point;
		}
	}
	#endregion
}
