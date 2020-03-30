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
			if (InteractWithCombat()) return;
			if (InteractWithMovement()) return;

			print("Nothing to Do...");
		}

		#endregion

		#region Public Methods


		#endregion

		#region Private Methods

		bool InteractWithCombat()
		{
			RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

			foreach(RaycastHit hit in hits)
			{
				CombatTarget target = hit.transform.GetComponent<CombatTarget>();

				if (target == null) continue;
				if (!_fighter.CanAttack(target.gameObject)) continue;

				if (Input.GetMouseButtonDown(0))
				{
					_fighter.Attack(target.gameObject);
				}
				return true;
			}
			return false;
		}

		bool InteractWithMovement()
		{
			RaycastHit hit;
			bool hasHit = Physics.Raycast(GetMouseRay(), out hit);

			if (hasHit)
			{
				if (Input.GetMouseButton(0))
				{
					_mover.StartMoveAction(hit.point);
				}
				return true;
			}
			return false;
		}

		static Ray GetMouseRay()
		{
			return Camera.main.ScreenPointToRay(Input.mousePosition);
		}
		#endregion
	}
}
