using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Movement;

namespace RPG.Combat
{
	public class Fighter : MonoBehaviour
	{
		#region Fields

		[SerializeField] float _weaponRange = 2f;

		Transform _target;
		Mover _mover;

		bool _isInRange;

		#endregion

		#region MonoBehaviour Methods

		void Start()
		{
			_mover = GetComponent<Mover>();
		}

		void Update()
		{
			if (_target == null) return;

			if (!GetIsInRange())
			{
				_mover.MoveTo(_target.position);
			}
			else
			{
				_mover.Stop();
			}
		}
		#endregion

		#region Public Methods

		public void Attack(CombatTarget combatTarget)
		{
			_target = combatTarget.transform;
		}

		public void CancelAttack()
		{
			_target = null;
		}
		#endregion

		#region Private Methods

		bool GetIsInRange()
		{
			return Vector3.Distance(transform.position, _target.position) < _weaponRange;
		}
		#endregion
	}
}