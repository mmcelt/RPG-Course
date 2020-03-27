using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
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
			UpdateAnimator();
		}
		#endregion

		#region Public Methods

		public void MoveTo(Vector3 destination)
		{
			_navAgent.destination = destination;
			_navAgent.isStopped = false;
		}

		public void Stop()
		{
			_navAgent.isStopped = true;
		}
		#endregion

		#region Private Methods

		void UpdateAnimator()
		{
			Vector3 velocity = _navAgent.velocity;
			Vector3 localVelocity = transform.InverseTransformDirection(velocity);
			float speed = localVelocity.z;
			_anim.SetFloat("ForwardSpeed", speed);
		}
		#endregion
	}
}