using UnityEngine;
using System.Collections;

public class CubeSlicer : MonoBehaviour {

	public float particlesSpeed;
	public ParticleSystem starBurst;
	
	GameObject copyCube;
	Transform collidedCube, copyChild;
	bool sliced, cubeReady, coinReady;
	float cutLength, prevScale, initialSizeX;
	int combo;

	void Awake(){
		combo = 1;
	}

	// Update is called once per frame
	void Update () {
		if (cubeReady && sliced){
			Slicing();
		}
		if (coinReady && sliced){
			CoinSlicing();
		}
	}

	void Slicing(){
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
		copyCube.GetComponent<CubeMove>().SelfDestructor(combo);
		copyChild = copyCube.transform.GetChild(0);
		//resizing created cube, shifting to the left, scaling and offsetting texture
		copyChild.localScale = new Vector3(prevScale - collidedCube.localScale.x, 
		                                   collidedCube.localScale.y, collidedCube.localScale.z);
		copyChild.Translate(Vector3.left * (copyCube.transform.GetChild(0).localScale.x / 2
		                                    + collidedCube.localScale.x / 2));
		copyChild.GetComponent<Renderer>().material.mainTextureScale = new Vector2(copyChild.localScale.x / initialSizeX, 1);
		copyChild.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(collidedCube.localScale.x / initialSizeX, 0f);
		//slicing finished & particles
		combo++;
		Instantiate(starBurst);
		sliced = false;
	}

	void CoinSlicing(){
		Debug.Log("coin!");
		sliced = false;
	}

	public void Slice(){
		sliced = true;
	}

	public void OnTriggerEnter(Collider c){
		if (c.CompareTag("Bill")){
			collidedCube = c.transform.GetChild(0);
			initialSizeX = collidedCube.localScale.x;
			cubeReady = true;
			sliced = false;
		}
		if (c.CompareTag("Coin")){
			c.GetComponent<CircleRotator>().enabled = false;
			coinReady = true;
			cubeReady = false;
			sliced = false;
		}
	}

	public void OnTriggerExit(Collider c){
		if (c.CompareTag("Bill")){
			cubeReady = false;
			if (c.GetComponent<CubeMove>() != null){
				c.GetComponent<BoxCollider>().enabled = false;
				c.GetComponent<CubeMove>().speed = particlesSpeed;
				c.GetComponent<CubeMove>().SelfDestructorLast(combo);
			}
			combo = 1;
		}
		if (c.CompareTag("Coin")){
			cubeReady = cubeReady ? true : false;
			coinReady = false;
		}
	}
}
