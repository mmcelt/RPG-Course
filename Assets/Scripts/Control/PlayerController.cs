using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	#region Fields

	Mover _mover;

	#endregion

	#region MonoBehaviour Methods

	void Start() 
	{
		_mover = GetComponent<Mover>();
	}
	
	void Update() 
	{
		if (Input.GetMouseButton(0))
		{
			MoveToCursor();
		}
	}
	#endregion

	#region Public Methods


	#endregion

	#region Private Methods

	void MoveToCursor()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		bool hasHit = Physics.Raycast(ray, out hit);

		if (hasHit)
		{
			_mover.MoveTo(hit.point);
		}
	}
	#endregion
}
