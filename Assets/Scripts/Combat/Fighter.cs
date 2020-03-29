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
		[SerializeField] float _timeBetweenAttacks = 1f;

		[SerializeField] float _weaponDamage = 5f;

		Health _target;
		Mover _mover;
		ActionScheduler _scheduler;
		Animator _anim;

		float _timeSinceLastAttack;

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
			_timeSinceLastAttack += Time.deltaTime;

			if (_target == null || _target.IsDead) return;

			if (!GetIsInRange())
			{
				_mover.MoveTo(_target.transform.position);
			}
			else
			{
				_mover.Cancel();
				AttackBehaviour();
			}
		}
		#endregion

		#region Public Methods

		public void Attack(CombatTarget combatTarget)
		{
			_scheduler.StartAction(this);
			_target = combatTarget.GetComponent<Health>();
		}

		public void CancelAttack()
		{
			GetComponent<Animator>().SetTrigger("stopAttack");
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
			return Vector3.Distance(transform.position, _target.transform.position) < _weaponRange;
		}

		void AttackBehaviour()
		{
			if(_timeSinceLastAttack >= _timeBetweenAttacks)
			{
				//this will trigger the Hit() event
				_anim.SetTrigger("attack");
				_timeSinceLastAttack = 0;
			}
		}

		//Animation Event
		void Hit()
		{
			DealDamage(_weaponDamage);
		}

		void DealDamage(float damage)
		{
			if (_target)
			{
				_target.TakeDamage(damage);
			}
		}
		#endregion
	}
}