using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
	public class Projectile : MonoBehaviour
	{
		#region Fields

		[SerializeField] float _moveSpeed = 10f;
		[SerializeField] bool _isHoming;
		[SerializeField] GameObject _hitEffect;

		float _damage;

		Health _target;

		#endregion

		#region MonoBehaviour Methods

		void Start()
		{
			if (_target == null) return;

			transform.LookAt(GetAimPoint());
		}

		void Update()
		{
			if (_target == null) return;

			if (_isHoming && !_target.IsDead)
				transform.LookAt(GetAimPoint());

			transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
		}

		void OnTriggerEnter(Collider other)
		{
			if (other.GetComponent<Health>() != _target) return;

			if (_target.IsDead) return;	//stops projectiles in flight interacting with the dead

			_target.TakeDamage(_damage);

			if (_hitEffect != null)
				Instantiate(_hitEffect, GetAimPoint(), transform.rotation);

			Destroy(gameObject);
		}
		#endregion

		#region Public Methods

		public void SetTarget(Health target, float damage)
		{
			_target = target;
			_damage = damage;
		}
		#endregion

		#region Private Methods

		Vector3 GetAimPoint()
		{
			CapsuleCollider aimPoint = _target.GetComponent<CapsuleCollider>();

			if (aimPoint == null)
				return _target.transform.position;

			return _target.transform.position + Vector3.up * aimPoint.height / 1.7f;
		}
		#endregion
	}
}