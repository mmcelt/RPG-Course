using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
	public class PersistentObjectSpawner : MonoBehaviour
	{
		#region Fields

		[SerializeField] GameObject _persistentObjectPrefab;

		static bool _hasSpawned;

		#endregion

		#region MonoBehaviour Methods

		void Awake()
		{
			if (_hasSpawned) return;

			SpawnPersistentObjects();

			_hasSpawned = true;
		}

		void Update()
		{

		}
		#endregion

		#region Public Methods


		#endregion

		#region Private Methods

		void SpawnPersistentObjects()
		{
			GameObject persistentObject = Instantiate(_persistentObjectPrefab);

			DontDestroyOnLoad(persistentObject);
		}
		#endregion
	}
}