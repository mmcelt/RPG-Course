﻿using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
	public class Projectile : MonoBehaviour
	{
		#region Fields

		[SerializeField] float _moveSpeed = 10f;

		Health _target;

		bool _hitTarget;

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

			Move();
		}

		void OnTriggerEnter(Collider other)
		{
			_hitTarget = true;
			Destroy(gameObject, 0.2f);
			//do damage...
		}
		#endregion

		#region Public Methods

		public void SetTarget(Health target)
		{
			_target = target;
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

		void Move()
		{
			if(!_hitTarget)
				transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
		}
		#endregion
	}
}