using UnityEngine;
using System.Collections;

public class Toucher : MonoBehaviour  {

	public BladeRotate bladeL;
	public BladeRotate1 bladeR;
	public float scissorsClosePercent;

	Vector2 initTouchPos;
	float gainedPercent;

	void Awake(){
		gainedPercent = 0f;
	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0){
			if (Input.GetTouch(0).phase == TouchPhase.Began){
				initTouchPos = Input.GetTouch(0).position;
			}
			if (Input.GetTouch(0).phase == TouchPhase.Moved && gainedPercent < scissorsClosePercent){
				gainedPercent += Vector2.Distance(initTouchPos, 
				                                         Input.GetTouch(0).deltaPosition) * Time.deltaTime * 10f;
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
