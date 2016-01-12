using UnityEngine;
using System.Collections;

public class Cutting : MonoBehaviour {

	public CubeSlicer slicer;

	bool cutLeft, cutRight, chiked;

	
	// Update is called once per frame
	void Update () {
		if (cutLeft && cutRight && !chiked){
			Chik();
		}
		if (!cutLeft && !cutRight){
			chiked = false;
		}
	}

	public void ReadyLeft(bool x){
		cutLeft = x;
	}

	public void ReadyRight(bool x){
		cutRight = x;
	}

	void Chik(){
		slicer.Slice();
		chiked = true;
	}
}
