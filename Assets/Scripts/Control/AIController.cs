using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;

namespace RPG.Control
{
	public class AIController : MonoBehaviour
	{
		#region Fields

		[SerializeField] float _chaseDistance = 5f;

		GameObject _player;

		Fighter _fighter;
		//Mover _mover;

		#endregion

		#region MonoBehaviour Methods

		void Start()
		{
			_player = GameObject.FindGameObjectWithTag("Player");
			_fighter = GetComponent<Fighter>();
			//_mover = GetComponent<Mover>();
		}

		void Update()
		{
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

		bool InAttackRangeOfPlayer()
		{
			float distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
			return distanceToPlayer < _chaseDistance;
		}
		#endregion

		#region Public Methods


		#endregion

		#region Private Methods


		#endregion
	}
}