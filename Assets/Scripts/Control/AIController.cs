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

		GameObject _player;

		Fighter _fighter;
		Health _health;
		Mover _mover;

		Vector3 _guardPosition;

		#endregion

		#region MonoBehaviour Methods

		void Start()
		{
			_player = GameObject.FindGameObjectWithTag("Player");
			_fighter = GetComponent<Fighter>();
			_health = GetComponent<Health>();
			_mover = GetComponent<Mover>();

			_guardPosition = transform.position;
		}

		void Update()
		{
			if (_health.IsDead) return;

			if (InAttackRangeOfPlayer() && _fighter.CanAttack(_player))
			{
				//print(transform.name + " Sees the Player, I'll get him!");
				_fighter.Attack(_player);
			}
			else
			{
				ReturnToGuardPosition();
			}
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

		void ReturnToGuardPosition()
		{
			_mover.StartMoveAction(_guardPosition);
		}
		#endregion
	}
}