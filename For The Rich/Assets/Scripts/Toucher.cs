using UnityEngine;
using System.Collections;

public class Toucher : MonoBehaviour  {

	public BladeRotate bladeL;
	public BladeRotate1 bladeR;
	public float scissorsClosePercent;

	float gainedPercent;

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0){
			if (Input.GetTouch(0).phase == TouchPhase.Began 
			    || Input.GetTouch(0).phase == TouchPhase.Stationary 
			    && gainedPercent < scissorsClosePercent){
				gainedPercent += 50;				
				bladeL.StartRotate(gainedPercent);
				bladeR.StartRotate(gainedPercent);
			}
			if (Input.GetTouch(0).phase == TouchPhase.Ended){
				bladeL.StopRotate();
				bladeR.StopRotate();
				gainedPercent = 0f;
			}
		}
	}
}
