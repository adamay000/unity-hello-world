using UnityEngine;

public class CameraController : MonoBehaviour {
	public float distance;
	public float angle;

	void Update () {
		keymove ();
	}

	void OnValidate() {
		updateCameraPosition ();
	}

	private void keymove() {
		if (Input.GetKey ("up")) {
			zoomUp ();
		}
		if (Input.GetKey ("down")) {
			zoomDown ();
		}
		if (Input.GetKey("left")) {
			rotateLeft ();
		}
		if (Input.GetKey("right")) {
			rotateRight ();
		}
	}

	private void zoomUp() {
		distance -= 0.1f;
		if (distance < 0.1f) {
			distance = 0.1f;
		}
		updateCameraPosition ();
	}

	private void zoomDown() {
		distance += 0.1f;
		updateCameraPosition ();
	}

	private void rotateLeft() {
		angle -= 1.0f;
		if (angle < 0.0f) {
			angle += 360.0f;
		}
		updateCameraPosition ();
	}

	private void rotateRight() {
		angle += 1.0f;
		if (angle > 359.0f) {
			angle -= 360.0f;
		}
		updateCameraPosition ();
	}

	private void updateCameraPosition() {
		gameObject.transform.position = new Vector3 (
			distance * Mathf.Cos (angle * Mathf.Deg2Rad),
			0.0f,
			distance * Mathf.Sin (angle * Mathf.Deg2Rad)
		);
		gameObject.transform.LookAt (Vector3.zero);
	}
}
