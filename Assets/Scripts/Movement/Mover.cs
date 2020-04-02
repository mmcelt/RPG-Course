using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;

namespace RPG.Movement
{
	public class Mover : MonoBehaviour, IAction
	{
		#region Fields

		[SerializeField] Transform _target;
		[Range(0,10)] [SerializeField] float _maxSpeed = 6f;

		NavMeshAgent _navAgent;
		Animator _anim;
		ActionScheduler _scheduler;
		Health _health;

		#endregion

		#region MonoBehaviour Methods

		void Start()
		{
			_navAgent = GetComponent<NavMeshAgent>();
			_anim = GetComponent<Animator>();
			_scheduler = GetComponent<ActionScheduler>();
			_health = GetComponent<Health>();
		}

		void Update()
		{
			_navAgent.enabled = !_health.IsDead;
			UpdateAnimator();
		}
		#endregion

		#region Public Methods

		public void StartMoveAction(Vector3 destination, float speedFraction)
		{
			_scheduler.StartAction(this);
			MoveTo(destination, speedFraction);
		}

		public void MoveTo(Vector3 destination, float speedFraction)
		{
			_navAgent.destination = destination;
			_navAgent.speed = _maxSpeed * Mathf.Clamp(speedFraction, 0, 1);
			_navAgent.isStopped = false;
		}

		public void Cancel()
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
			_anim.SetFloat("forwardSpeed", speed);
		}
		#endregion
	}
}