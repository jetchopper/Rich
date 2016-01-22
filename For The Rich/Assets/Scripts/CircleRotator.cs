using UnityEngine;
using System.Collections;

public class CircleRotator : MonoBehaviour {

	public float rotSpeed;

	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
	}
}
