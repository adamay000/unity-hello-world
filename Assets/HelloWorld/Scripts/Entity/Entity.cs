using UnityEngine;

namespace HelloWorld.Entity
{
	public class Entity : MonoBehaviour
	{
		public HelloWorld controller;

		private Vector3 initialPosition;
		void Start () {
			initialPosition = transform.position;

			GetComponent<Renderer> ().materials[0].color = new Color(
				Random.Range(0.0f, 1.0f),
				Random.Range(0.0f, 1.0f),
				Random.Range(0.0f, 1.0f)
			);
		}

		void Update() {
			Vector3 to = initialPosition.normalized * controller.radius - initialPosition;
			float progress = Mathf.Sin(Time.time) * 0.5f + 0.5f;
			transform.position = initialPosition + to * progress;
		}
	}
}
