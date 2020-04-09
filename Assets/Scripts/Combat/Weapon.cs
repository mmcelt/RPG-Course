using RPG.Core;
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
		[SerializeField] Projectile _projectile;

		public float WeaponDamage => _weaponDamage;
		public float WeaponRange => _weaponRange;

		const string _weaponName = "Weapon";

		#endregion

		#region Public Methods

		public void Spawn(Transform rightHand, Transform lefthand, Animator animator)
		{
			DestroyOldWeapon(rightHand, lefthand);

			if (_equippedPrefab)
			{
				Transform handTransform = GetTransform(rightHand, lefthand);

				GameObject weapon = Instantiate(_equippedPrefab, handTransform);
				weapon.name = _weaponName;
			}

			if (_weaponOverrideController)
				animator.runtimeAnimatorController = _weaponOverrideController;
		}

		public bool HasProjectile()
		{
			return _projectile != null;
		}

		public void LaunchProjectile(Transform rightHand, Transform leftHand, Health target)
		{
			Projectile projectileInstance = Instantiate(_projectile, GetTransform(rightHand, leftHand).position, Quaternion.identity);
			projectileInstance.SetTarget(target, _weaponDamage);
		}
		#endregion

		#region Private Methods

		Transform GetTransform(Transform rightHand, Transform lefthand)
		{
			return _isRightHanded ? rightHand : lefthand;
		}

		void DestroyOldWeapon(Transform rightHand, Transform leftHand)
		{
			Transform oldWeapon = rightHand.Find(_weaponName);

			if (oldWeapon == null)
				oldWeapon = leftHand.Find(_weaponName);

			if (oldWeapon == null) return;

			oldWeapon.name = "DESTOYING";

			Destroy(oldWeapon.gameObject);
		}
		#endregion
	}
}