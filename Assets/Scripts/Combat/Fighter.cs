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

		[SerializeField] float _timeBetweenAttacks = 1f;

		[SerializeField] Transform _rightHandTransform;
		[SerializeField] Transform _lefttHandTransform;
		[SerializeField] Weapon _defaultWeapon;

		Health _target;
		Mover _mover;
		ActionScheduler _scheduler;
		Animator _anim;

		float _timeSinceLastAttack;
		Weapon _currentWeapon;

		#endregion

		#region MonoBehaviour Methods

		void Start()
		{
			_timeSinceLastAttack = Mathf.Infinity;

			_mover = GetComponent<Mover>();
			_scheduler = GetComponent<ActionScheduler>();
			_anim = GetComponent<Animator>();
			_currentWeapon = _defaultWeapon;
			EquipWeapon(_currentWeapon);
		}

		void Update()
		{
			_timeSinceLastAttack += Time.deltaTime;

			if (_target == null || _target.IsDead) return;

			if (!GetIsInRange())
			{
				_mover.MoveTo(_target.transform.position, 1f);
			}
			else
			{
				_mover.Cancel();
				AttackBehaviour();
			}
		}
		#endregion

		#region Public Methods

		public void Attack(GameObject combatTarget)
		{
			_scheduler.StartAction(this);
			_target = combatTarget.GetComponent<Health>();
		}

		public void CancelAttack()
		{
			_anim.ResetTrigger("attack");
			_anim.SetTrigger("stopAttack");
			_target = null;
			_mover.Cancel();
		}

		public void Cancel()
		{
			CancelAttack();
		}

		public bool CanAttack(GameObject combatTarget)
		{
			if (combatTarget == null) return false;

			Health targetHealth = combatTarget.GetComponent<Health>();
			return targetHealth != null && !targetHealth.IsDead;
		}
		#endregion

		#region Private Methods

		bool GetIsInRange()
		{
			return Vector3.Distance(transform.position, _target.transform.position) < _currentWeapon.WeaponRange;
		}

		void AttackBehaviour()
		{
			transform.LookAt(_target.transform);

			if (_timeSinceLastAttack >= _timeBetweenAttacks)
			{
				//this will trigger the Hit() event
				TriggerAttack();
				_timeSinceLastAttack = 0;
			}
		}

		void TriggerAttack()
		{
			_anim.ResetTrigger("stopAttack");
			_anim.SetTrigger("attack");
		}

		//Animation Events
		void Hit()
		{
			if (_target == null) return;

			if (_currentWeapon.HasProjectile())
				_currentWeapon.LaunchProjectile(_rightHandTransform, _lefttHandTransform, _target);
			else
				DealDamage(_currentWeapon.WeaponDamage);
		}

		void Shoot()
		{
			Hit();
		}

		void DealDamage(float damage)
		{
			if (!_target) return;

			_target.TakeDamage(damage);
		}

		public void EquipWeapon(Weapon weapon)
		{
			if (weapon == null) return;
			_currentWeapon = weapon;
			weapon.Spawn(_rightHandTransform, _lefttHandTransform, _anim);
		}
		#endregion
	}
}