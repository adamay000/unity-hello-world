using UnityEngine;
using System.Collections.Generic;

namespace HelloWorld {
	public class HelloWorld : MonoBehaviour
	{
		[Range(0, 1000)]
		public int entityAmount = 10;
		[Range(0, 100)]
		public int radius = 4;
		public GameObject entity;

		private List<GameObject> entities = new List<GameObject>();

		void Awake () {
			OnValidate ();
		}

		void OnValidate() {
			int removeAmount = entities.Count - entityAmount;

			if (removeAmount > 0) {
				foreach (GameObject e in entities.GetRange (entityAmount, removeAmount)) {
					Destroy (e);
				}
				entities.RemoveRange (entityAmount, removeAmount);
			} else {
				while (entities.Count < entityAmount) {
					entities.Add (spawn());
				}
			}
		}

		private GameObject spawn() {
			GameObject spawned = Instantiate (
				entity,
				transform.position + Random.insideUnitSphere * radius,
				Quaternion.Slerp(transform.rotation, Random.rotation, 0.5f)
			);

			spawned.GetComponent<Entity.Entity> ().controller = this;
			spawned.SetActive (true);

			return spawned;
		}
	}
}
