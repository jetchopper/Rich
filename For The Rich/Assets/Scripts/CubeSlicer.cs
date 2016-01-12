﻿using UnityEngine;
using System.Collections;

public class CubeSlicer : MonoBehaviour {

	public float particlesSpeed;

	GameObject copyCube;
	Transform collidedCube;
	bool sliced, cubeReady;
	float distanceEndToCenter, cutLength, prevScale;

	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {
		if (cubeReady && sliced){
			//cubes resizing
			prevScale = collidedCube.localScale.x;
			distanceEndToCenter = collidedCube.position.x;
			cutLength = prevScale / 2 + distanceEndToCenter;
			collidedCube.localScale = new Vector3(cutLength, collidedCube.localScale.y, collidedCube.localScale.z);
			copyCube = Instantiate(collidedCube.parent.gameObject);
			copyCube.GetComponent<BoxCollider>().enabled = false;
			copyCube.transform.GetChild(0).localScale = new Vector3(prevScale - collidedCube.localScale.x, 
			                                            collidedCube.localScale.y, collidedCube.localScale.z);
			copyCube.GetComponent<CubeMove>().speed = particlesSpeed;
			//translation
			collidedCube.Translate(Vector3.right * (prevScale - collidedCube.localScale.x) / 2);
			copyCube.transform.Translate(Vector3.left * (copyCube.transform.localScale.x / 2 + copyCube.transform.position.x));
			sliced = false;
		}
	}

	public void Slice(){
		sliced = true;
		Debug.Log("sliced");
	}

	public void OnTriggerEnter(Collider c){
		collidedCube = c.transform.GetChild(0);
		cubeReady = true;
		Debug.Log("ready");
	}

	public void OnTriggerExit(Collider c){
		cubeReady = false;
		Debug.Log("not ready");
	}
}