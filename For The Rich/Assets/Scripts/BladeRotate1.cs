using UnityEngine;
using System.Collections;

public class BladeRotate1 : MonoBehaviour {

	public Cutting cutting;
	public float cutPercent;

	bool isRotating;
	float percent, startAngle, delta;

	// Use this for initialization
	void Awake () {
		startAngle = 330f;
		delta = 30f / 100f;
	}
	
	// Update is called once per frame
	void Update () {
		if (isRotating){
			transform.eulerAngles = new Vector3(0f, 0f, startAngle + delta * percent);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)){
			StartRotate(80f);
		}
		if (Input.GetKeyUp(KeyCode.RightArrow)){
			StartRotate(0f);
		}
	}

	public void StartRotate(float x){
		isRotating = true;
		percent = Mathf.Abs(x);
		cutting.ReadyRight(percent > cutPercent ? true : false);
	}

	public void StopRotate(){
		isRotating = false;
		cutting.ReadyRight(false);
		transform.eulerAngles = new Vector3(0f, 0f, startAngle);
	}
}
