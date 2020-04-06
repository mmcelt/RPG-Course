using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
	public class WeaponPickup : MonoBehaviour
	{
		#region Fields

		[SerializeField] Weapon _pickupWeapon;

		#endregion

		#region MonoBehaviour Methods

		void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				other.GetComponent<Fighter>().EquipWeapon(_pickupWeapon);

				Destroy(gameObject);
			}
		}
		#endregion

		#region Public Methods


		#endregion

		#region Private Methods


		#endregion
	}
}