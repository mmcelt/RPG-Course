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

		GameObject _player;

		Fighter _fighter;
		Health _health;
		Mover _mover;
		ActionScheduler _scheduler;

		Vector3 _guardPosition;
		float _timeSinceLastSawPlayer;

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
				GuardBehavior();
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
		void GuardBehavior()
		{
			_mover.StartMoveAction(_guardPosition);
		}
		#endregion
	}
}