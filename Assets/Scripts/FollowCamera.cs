using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
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
		transform.position = _target.position;
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods


	#endregion
}
