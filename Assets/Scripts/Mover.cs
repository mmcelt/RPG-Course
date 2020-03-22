using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
	#region Fields

	[SerializeField] Transform _target;

	#endregion

	#region MonoBehaviour Methods

	void Start() 
	{
		
	}
	
	void Update() 
	{
		GetComponent<NavMeshAgent>().destination = _target.position;
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
