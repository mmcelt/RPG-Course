using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Saving;

namespace RPG.SceneManagement
{
	public class SavingWrapper : MonoBehaviour
	{
		#region Fields

		const string _defaultSaveFile = "save";

		#endregion

		#region MonoBehaviour Methods

		void Start()
		{

		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.L))
			{
				Load();
			}
			if (Input.GetKeyDown(KeyCode.S))
			{
				Save();
			}
		}
		#endregion

		#region Public Methods


		#endregion

		#region Private Methods

		void Load()
		{
			GetComponent<SavingSystem>().Load(_defaultSaveFile);
		}

		void Save()
		{
			GetComponent<SavingSystem>().Save(_defaultSaveFile);
		}
		#endregion
	}
}