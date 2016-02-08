using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	float degree = 0;
	bool fl = false;

	
	void Update() 
	{
	/*	if (Input.GetKeyUp(KeyCode.RightArrow))
			degree += 90f;
		if (Input.GetKeyUp(KeyCode.LeftArrow))
			degree -= 90f;*/
		if(Input.GetKeyUp(KeyCode.Space))
		{
			fl = !fl;
		}
		if (fl) {
			degree = 90f;
		} else {
			degree = 0f;
		}
		

		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, degree, 0), Time.deltaTime*4);
	}
}
