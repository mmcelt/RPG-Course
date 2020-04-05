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

		//using a struct to capture & restore state data...
		[System.Serializable]
		struct MoverSaveData
		{
			public SerializableVector3 positon;
			public SerializableVector3 rotation;
		}

		public object CaptureState()
		{
			//using a struct to capture the data...
			MoverSaveData data = new MoverSaveData();
			data.positon = new SerializableVector3(transform.position);
			data.rotation = new SerializableVector3(transform.eulerAngles);

			////using a Dictionary to save multiple values of state...
			//Dictionary<string, object> data = new Dictionary<string, object>();
			//data["position"] = new SerializableVector3(transform.position);
			//data["rotation"] = new SerializableVector3(transform.eulerAngles);

			return data;
		}
			

		public void RestoreState(object state)
		{
			//using a struct to restore the data...
			MoverSaveData data = (MoverSaveData)state;
			_navAgent.Warp((data.positon).ToVector());
			transform.eulerAngles = (data.rotation).ToVector();

			////using a Dictionary to restore multiple values of state...
			//Dictionary<string, object> data = (Dictionary<string, object>)state;
			//_navAgent.Warp(((SerializableVector3)data["position"]).ToVector());
			//transform.eulerAngles = ((SerializableVector3)data["rotation"]).ToVector();
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