using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
	public class Fighter : MonoBehaviour
	{
		#region Fields


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

		public void Attack(CombatTarget target)
		{
			print("Take that you lilly livered dweeb! " + target.name);
		}
		#endregion

		#region Private Methods


		#endregion
	}
}