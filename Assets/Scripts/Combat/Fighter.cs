using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
	public class Fighter : MonoBehaviour, IAction
	{
		#region Fields

		[SerializeField] float _weaponRange = 2f;

		Transform _target;
		Mover _mover;
		ActionScheduler _scheduler;
		Animator _anim;

		bool _isInRange;

		#endregion

		#region MonoBehaviour Methods

		void Start()
		{
			_mover = GetComponent<Mover>();
			_scheduler = GetComponent<ActionScheduler>();
			_anim = GetComponent<Animator>();
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
				_mover.Cancel();
			}
		}
		#endregion

		#region Public Methods

		public void Attack(CombatTarget combatTarget)
		{
			_scheduler.StartAction(this);
			_target = combatTarget.transform;
		}

		public void CancelAttack()
		{
			_target = null;
		}

		public void Cancel()
		{
			CancelAttack();
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