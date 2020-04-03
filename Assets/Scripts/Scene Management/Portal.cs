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

			print("Scene loaded: " + SceneManager.GetActiveScene().name);
			Destroy(gameObject);
		}
		#endregion
	}
}
