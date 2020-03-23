using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;

namespace RPG.Control 
{
	public class PlayerController : MonoBehaviour
	{
		#region Fields

		Mover _mover;
		Fighter _fighter;

		#endregion

		#region MonoBehaviour Methods

		void Start()
		{
			_mover = GetComponent<Mover>();
			_fighter = GetComponent<Fighter>();
		}

		void Update()
		{
			InteractWithCombat();
			InteractWithMovement();
		}

		#endregion

		#region Public Methods


		#endregion

		#region Private Methods

		void InteractWithMovement()
		{
			if (Input.GetMouseButton(0))
			{
				MoveToCursor();
			}
		}

		void InteractWithCombat()
		{
			RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

			foreach(RaycastHit hit in hits)
			{
				CombatTarget target = hit.transform.GetComponent<CombatTarget>();
				if (!target) continue;

				if (Input.GetMouseButtonDown(0))
				{
					_fighter.Attack(target);
				}
			}
		}

		void MoveToCursor()
		{
			RaycastHit hit;
			bool hasHit = Physics.Raycast(GetMouseRay(), out hit);

			if (hasHit)
			{
				_mover.MoveTo(hit.point);
			}
		}

		static Ray GetMouseRay()
		{
			return Camera.main.ScreenPointToRay(Input.mousePosition);
		}
		#endregion
	}
}
