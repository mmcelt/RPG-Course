using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
	public class AIController : MonoBehaviour
	{
		#region Fields

		[SerializeField] float _chaseDistance = 5f;

		GameObject _player;

		#endregion

		#region MonoBehaviour Methods

		void Start()
		{
			_player = GameObject.FindGameObjectWithTag("Player");
		}

		void Update()
		{
			if (DistanceToPlayer() < _chaseDistance)
			{
				print(transform.name + " Sees the Player, I'll get him!");
			}
		}

		float DistanceToPlayer()
		{
			return Vector3.Distance(transform.position, _player.transform.position);
		}
		#endregion

		#region Public Methods


		#endregion

		#region Private Methods


		#endregion
	}
}