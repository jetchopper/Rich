using UnityEngine;
using System.Collections;

public class CircleRotator : MonoBehaviour {

	public float rotSpeed, speed;

	Transform slicer;
	Vector3 randomRot, direction;
	Rigidbody rb;

	void Awake(){
		rb = GetComponent<Rigidbody>();
		slicer = GameObject.FindGameObjectWithTag("Player").transform;
		randomRot = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
		direction = (-transform.position - slicer.position + (Vector3.up * 2)) / speed;
		Destroy(gameObject, 6f);
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(randomRot * rotSpeed * Time.deltaTime);
		rb.AddForceAtPosition(direction * Time.deltaTime, slicer.position);
	}
}
