using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;
using RPG.Saving;

namespace RPG.Movement
{
	public class Mover : MonoBehaviour, IAction, ISaveable
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

		void Awake()
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

		public object CaptureState()
		{
			return new SerializableVector3(transform.position);
		}

		public void RestoreState(object state)
		{
			SerializableVector3 position = (SerializableVector3)state;
			//_navAgent.enabled = false;
			_navAgent.Warp(position.ToVector());
			//_navAgent.enabled = true;
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