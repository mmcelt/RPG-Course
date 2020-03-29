using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
	public class Health : MonoBehaviour
	{
		#region Fields

		[SerializeField] float _health = 100f;

		#endregion

		#region MonoBehaviour Methods

		void Start()
		{

		}

		void Update()
		{

		}
		#endregion

		#region Public Methods

		public void TakeDamage(float damage)
		{
			//ensures health >= 0
			_health = Mathf.Max(_health - damage, 0);
			print(_health);
		}
		#endregion

		#region Private Methods


		#endregion
	}
}