using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
	#region Fields

	[SerializeField] Transform _target;

	Ray _lastRay;

	#endregion

	#region MonoBehaviour Methods

	void Start() 
	{
		
	}
	
	void Update() 
	{
		if (Input.GetMouseButtonDown(0))
		{
			_lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		}
		Debug.DrawRay(_lastRay.origin, _lastRay.direction * 100);

		GetComponent<NavMeshAgent>().destination = _target.position;
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
