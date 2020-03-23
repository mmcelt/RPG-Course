using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
	#region Fields

	[SerializeField] Transform _target;

	NavMeshAgent _navAgent;
	Animator _anim;

	#endregion

	#region MonoBehaviour Methods

	void Start() 
	{
		_navAgent = GetComponent<NavMeshAgent>();
		_anim = GetComponent<Animator>();
	}
	
	void Update() 
	{
		if (Input.GetMouseButton(0))
		{
			MoveToCursor();
		}

		UpdateAnimator();
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

	void UpdateAnimator()
	{
		Vector3 velocity = _navAgent.velocity;
		Vector3 localVelocity = transform.InverseTransformDirection(velocity);
		float speed = localVelocity.z;
		_anim.SetFloat("ForwardSpeed", speed);
	}
	#endregion
}
