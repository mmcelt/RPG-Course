using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;
using RPG.Combat;
using RPG.Movement;

namespace RPG.Control
{
	public class AIController : MonoBehaviour
	{
		#region Fields

		[SerializeField] float _chaseDistance = 5f;
		[SerializeField] float _suspicionTime = 3f;
		[SerializeField] PatrolPath _patrolPath;
		[SerializeField] float _waypointTolerance = 0.5f;

		GameObject _player;

		Fighter _fighter;
		Health _health;
		Mover _mover;
		ActionScheduler _scheduler;

		Vector3 _guardPosition;
		float _timeSinceLastSawPlayer;
		int _currentWaypointIndex;

		#endregion

		#region MonoBehaviour Methods

		void Start()
		{
			_player = GameObject.FindGameObjectWithTag("Player");
			_fighter = GetComponent<Fighter>();
			_health = GetComponent<Health>();
			_mover = GetComponent<Mover>();
			_scheduler = GetComponent<ActionScheduler>();

			_timeSinceLastSawPlayer = Mathf.Infinity;
			_guardPosition = transform.position;
		}

		void Update()
		{
			if (_health.IsDead) return;

			if (InAttackRangeOfPlayer() && _fighter.CanAttack(_player))
			{
				_timeSinceLastSawPlayer = 0;
				AttackBehavior();
			}
			else if (_timeSinceLastSawPlayer < _suspicionTime)
			{
				SuspicionBehavior();
			}
			else
			{
				PatrolBehavior();
			}

			_timeSinceLastSawPlayer += Time.deltaTime;
		}

		void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, _chaseDistance);
		}
		#endregion

		#region Public Methods


		#endregion

		#region Private Methods

		bool InAttackRangeOfPlayer()
		{
			float distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
			return distanceToPlayer < _chaseDistance;
		}

		void AttackBehavior()
		{
			_fighter.Attack(_player);
		}

		void SuspicionBehavior()
		{
			_scheduler.CancelCurrentAction();

		}

		void PatrolBehavior()
		{
			Vector3 nextPosition = _guardPosition;

			if(_patrolPath != null)
			{
				if (AtWaypoint())
				{
					CycleWaypoint();
				}
				nextPosition = GetCurrentWaypoint();
			}
			_mover.StartMoveAction(nextPosition);
		}

		bool AtWaypoint()
		{
			float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWaypoint());
			return distanceToWaypoint < _waypointTolerance;
		}

		void CycleWaypoint()
		{
			_currentWaypointIndex = _patrolPath.GetNextIndex(_currentWaypointIndex);
		}

		Vector3 GetCurrentWaypoint()
		{
			return _patrolPath.GetWaypoint(_currentWaypointIndex);
		}
		#endregion
	}
}