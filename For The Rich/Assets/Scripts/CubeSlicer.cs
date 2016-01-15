using UnityEngine;
using System.Collections;

public class CubeSlicer : MonoBehaviour {

	public float particlesSpeed;

	GameObject copyCube;
	Transform collidedCube;
	bool sliced, cubeReady;
	float distanceEndToCenter, cutLength, prevScale;

	// Update is called once per frame
	void Update () {
		if (cubeReady && sliced){
			//cubes resizing and shifting
			prevScale = collidedCube.localScale.x;
			distanceEndToCenter = collidedCube.position.x;
			cutLength = prevScale / 2 + distanceEndToCenter;
			collidedCube.localScale = new Vector3(cutLength, collidedCube.localScale.y, collidedCube.localScale.z);
			collidedCube.Translate(Vector3.right * (prevScale - collidedCube.localScale.x) / 2);
			//another cube
			copyCube = Instantiate(collidedCube.parent.gameObject);
			copyCube.GetComponent<BoxCollider>().enabled = false;
			copyCube.transform.GetChild(0).localScale = new Vector3(prevScale - collidedCube.localScale.x, 
			                                            collidedCube.localScale.y, collidedCube.localScale.z);
			copyCube.GetComponent<CubeMove>().speed = particlesSpeed;
			copyCube.GetComponent<CubeMove>().SelfDestructor();
			copyCube.transform.GetChild(0).Translate(Vector3.left * (copyCube.transform.GetChild(0).localScale.x / 2
			                                                         + collidedCube.localScale.x / 2));
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
		sliced = false;
		Debug.Log("ready");
	}

	public void OnTriggerExit(Collider c){
		cubeReady = false;
		Debug.Log("not ready");
	}
}
