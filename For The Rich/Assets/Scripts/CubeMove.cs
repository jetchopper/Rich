using UnityEngine;
using System.Collections;

public class CubeMove : MonoBehaviour {
	
	public float speed;

	bool rotate;
	Vector3 randomRot;

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * Time.deltaTime * speed);
		if (rotate){
			transform.Rotate(randomRot);
		}
	}

	public void SelfDestructor(){
		rotate = true;
		randomRot = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
		Destroy(gameObject, 10f);
	}
}
