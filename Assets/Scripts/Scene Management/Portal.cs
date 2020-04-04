using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

namespace RPG.SceneManagement
{
	public class Portal : MonoBehaviour
	{
		#region Fields

		[SerializeField] int _sceneToLoadIndex;
		[SerializeField] Transform _spawnPoint;

		#endregion

		#region MonoBehaviour Methods

		void Start()
		{
			
		}

		void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				StartCoroutine(Transition());
			}
		}
		#endregion

		#region Public Methods


		#endregion

		#region Private Methods

		IEnumerator Transition()
		{
			DontDestroyOnLoad(gameObject);

			yield return SceneManager.LoadSceneAsync(_sceneToLoadIndex);

			Portal otherPortal = GetOtherPortal();
			UpdatePlayer(otherPortal);

			Destroy(gameObject);
		}

		void UpdatePlayer(Portal otherPortal)
		{
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			player.GetComponent<NavMeshAgent>().Warp(otherPortal._spawnPoint.position);
			player.transform.rotation = otherPortal._spawnPoint.rotation;
		}

		Portal GetOtherPortal()
		{
			foreach (Portal portal in FindObjectsOfType<Portal>())
			{
				if (portal == this) continue;

				return portal;
			}

			return null;
		}
		#endregion
	}
}
