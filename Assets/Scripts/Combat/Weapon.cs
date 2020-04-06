using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
	[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
	public class Weapon : ScriptableObject
	{
		#region Fields

		[SerializeField] GameObject _equippedPrefab;
		[SerializeField] AnimatorOverrideController _weaponOverrideController;
		[SerializeField] float _weaponDamage = 5f;
		[SerializeField] float _weaponRange = 2f;
		[SerializeField] bool _isRightHanded = true;

		public float WeaponDamage => _weaponDamage;
		public float WeaponRange => _weaponRange;

		#endregion

		#region Public Methods

		public void Spawn(Transform rightHand, Transform lefthand, Animator animator)
		{
			if (_equippedPrefab)
			{
				Transform handTransform;

				handTransform = _isRightHanded ? rightHand : lefthand;

				Instantiate(_equippedPrefab, handTransform);
			}

			if (_weaponOverrideController)
				animator.runtimeAnimatorController = _weaponOverrideController;
		}
		#endregion

		#region Private Methods


		#endregion
	}
}