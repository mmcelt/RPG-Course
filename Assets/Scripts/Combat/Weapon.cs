using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
	[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
	public class Weapon : ScriptableObject
	{
		#region Fields

		[SerializeField] GameObject _weaponPrefab;
		[SerializeField] AnimatorOverrideController _weaponOverrideController;

		#endregion

		#region Public Methods

		public void Spawn(Transform handTransform,Animator animator)
		{
			Instantiate(_weaponPrefab, handTransform);
			animator.runtimeAnimatorController = _weaponOverrideController;
		}
		#endregion

		#region Private Methods


		#endregion
	}
}