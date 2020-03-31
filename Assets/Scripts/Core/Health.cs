using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
	public class Health : MonoBehaviour
	{
		#region Fields

		[SerializeField] float _healthPoints = 100f;

		public float CurrentHealth => _healthPoints;

		public bool IsDead { get; private set; }

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
			_healthPoints = Mathf.Max(_healthPoints - damage, 0);

			print(_healthPoints);

			if(_healthPoints == 0 && !IsDead)
			{
				Die();
			}
		}
		#endregion

		#region Private Methods

		void Die()
		{
			GetComponent<Animator>().SetTrigger("die");
			IsDead = true;
			GetComponent<ActionScheduler>().CancelCurrentAction();
		}
		#endregion
	}
}