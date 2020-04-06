using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
	public class Projectile : MonoBehaviour
	{
		#region Fields

		[SerializeField] Transform _target;
		[SerializeField] float _moveSpeed = 10f;

		#endregion

		#region MonoBehaviour Methods

		void Start()
		{

		}

		void Update()
		{
			if (_target == null) return;

			transform.LookAt(GetAimPoint());
			transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
		}
		#endregion

		#region Public Methods


		#endregion

		#region Private Methods

		Vector3 GetAimPoint()
		{
			CapsuleCollider aimPoint = _target.GetComponent<CapsuleCollider>();

			if (aimPoint == null)
				return _target.position;

			return _target.position + Vector3.up * aimPoint.height / 1.4f;
		}
		#endregion
	}
}