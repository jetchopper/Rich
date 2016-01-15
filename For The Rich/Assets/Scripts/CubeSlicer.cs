using UnityEngine;
using System.Collections;

public class CubeSlicer : MonoBehaviour {

	public float particlesSpeed;

	GameObject copyCube;
	Transform collidedCube, copyChild;
	bool sliced, cubeReady;
	float cutLength, prevScale, initialSizeX;

	// Update is called once per frame
	void Update () {
		if (cubeReady && sliced){
			Clicing();
		}
	}

	void Clicing(){
		//getting scale before cut & X cut from right
		prevScale = collidedCube.localScale.x;
		cutLength = prevScale / 2 + collidedCube.position.x;
		//resizing original cube, shifting to the right and scaling texture
		collidedCube.localScale = new Vector3(cutLength, collidedCube.localScale.y, collidedCube.localScale.z);
		collidedCube.Translate(Vector3.right * (prevScale - collidedCube.localScale.x) / 2);
		collidedCube.GetComponent<Renderer>().material.mainTextureScale = new Vector2(collidedCube.localScale.x / initialSizeX, 1);
		//another cube, creation
		copyCube = Instantiate(collidedCube.parent.gameObject);
		copyCube.GetComponent<BoxCollider>().enabled = false;
		copyCube.GetComponent<CubeMove>().speed = particlesSpeed;
		copyCube.GetComponent<CubeMove>().SelfDestructor();
		copyChild = copyCube.transform.GetChild(0);
		//resizing created cube, shifting to the left, scaling and offsetting texture
		copyChild.localScale = new Vector3(prevScale - collidedCube.localScale.x, 
		                                   collidedCube.localScale.y, collidedCube.localScale.z);
		copyChild.Translate(Vector3.left * (copyCube.transform.GetChild(0).localScale.x / 2
		                                    + collidedCube.localScale.x / 2));
		copyChild.GetComponent<Renderer>().material.mainTextureScale = new Vector2(copyChild.localScale.x / initialSizeX, 1);
		copyChild.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(collidedCube.localScale.x / initialSizeX, 0f);
		//slicing finished
		sliced = false;
	}

	public void Slice(){
		sliced = true;
		Debug.Log("sliced");
	}

	public void OnTriggerEnter(Collider c){
		collidedCube = c.transform.GetChild(0);
		initialSizeX = collidedCube.localScale.x;
		cubeReady = true;
		sliced = false;
		Debug.Log("ready");
	}

	public void OnTriggerExit(Collider c){
		cubeReady = false;
		if (c.GetComponent<CubeMove>() != null){
			c.GetComponent<CubeMove>().speed = particlesSpeed;
			c.GetComponent<CubeMove>().SelfDestructor();
		}
		Debug.Log("not ready");
	}
}
