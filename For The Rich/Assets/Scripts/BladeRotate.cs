﻿using UnityEngine;
using System.Collections;

public class BladeRotate : MonoBehaviour {

	public Cutting cutting;
	public float cutPercent;

	bool isRotating;
	float percent, startAngle, delta;

	// Use this for initialization
	void Awake () {
		startAngle = transform.eulerAngles.z;
		delta = Mathf.Abs (transform.eulerAngles.z) / 100f;
	}
	
	// Update is called once per frame
	void Update () {
		if (isRotating){
			transform.eulerAngles = new Vector3(0f, 0f, startAngle - delta * percent);
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			StartRotate(80f);
		}
		if (Input.GetKeyUp(KeyCode.LeftArrow)){
			StartRotate(0f);
		}
	}

	public void StartRotate(float x){
		isRotating = true;
		percent = x;
		cutting.ReadyLeft(percent > cutPercent ? true : false);
	}

	public void StopRotate(){
		isRotating = false;
		cutting.ReadyLeft(false);
		transform.eulerAngles = new Vector3(0f, 0f, startAngle);
	}
}
