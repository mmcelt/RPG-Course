using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG.SceneManagement
{
	public class Portal : MonoBehaviour
	{
		#region Fields

		[SerializeField] int _sceneToLoadIndex;

		#endregion

		#region MonoBehaviour Methods

		void Start()
		{

		}

		void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				SceneManager.LoadScene(_sceneToLoadIndex);
			}
		}
		#endregion

		#region Public Methods


		#endregion

		#region Private Methods


		#endregion
	}
}
