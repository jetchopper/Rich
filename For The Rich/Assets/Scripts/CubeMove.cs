using UnityEngine;
using System.Collections;

public class CubeMove : MonoBehaviour {
	
	public float speed, cost;

	bool rotate;
	Vector3 randomRot;
	float timer;

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * Time.deltaTime * speed);
		if (rotate){
			timer += Time.deltaTime;
			transform.Rotate(randomRot);
			if (timer > 18f){
				transform.GetChild(0).GetComponent<Renderer>().material.color -= Color.black * 0.02f;
			}
		}
	}

	public void SelfDestructor(int combo){
		Subscore.SetSubscore(cost * combo);
		Combo.setCombo(combo);
		rotate = true;
		timer = 0f;
		randomRot = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 0f), Random.Range(-1f, 1f));
		Destroy(gameObject, 20f);
	}

	public void SelfDestructorLast(int combo){
		Combo.setCombo(combo);
		Subscore.Clear();
		rotate = true;
		timer = 0f;
		randomRot = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 0f), Random.Range(-1f, 1f));
		Destroy(gameObject, 20f);
	}
}
