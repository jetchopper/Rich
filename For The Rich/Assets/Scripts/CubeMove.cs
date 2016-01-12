using UnityEngine;
using System.Collections;

public class CubeMove : MonoBehaviour {

	public float speed;

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * Time.deltaTime * speed);
	}
}
