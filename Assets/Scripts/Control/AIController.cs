using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;
using RPG.Combat;

namespace RPG.Control
{
	public class AIController : MonoBehaviour
	{
		#region Fields

		[SerializeField] float _chaseDistance = 5f;

		GameObject _player;

		Fighter _fighter;
		Health _health;

		#endregion

		#region MonoBehaviour Methods

		void Start()
		{
			_player = GameObject.FindGameObjectWithTag("Player");
			_fighter = GetComponent<Fighter>();
			_health = GetComponent<Health>();
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
				_fighter.Cancel();
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
		#endregion
	}
}