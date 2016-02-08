using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectionGameObjects : MonoBehaviour {
	public GameObject []gameObj;




	List<Vector3> endPos = new List<Vector3>();
	public float step = -0.1f;
	public static int numberObject = 1;
	int tempNumber = 1;

	//public Transform cam;
	// Use this for initialization
	void Start () {
		//float x = -step;
		float angl = 0;
	
		foreach(GameObject g in gameObj){
		
		/*	g.transform.position = new Vector3 (x, 0, 0);
			endPos.Add(new Vector3(x,0,0));
			
			x+=step;*/
		
			//	g.transform.LookAt(cam);
			g.transform.position = new Vector3 (0, 0, 0);
			g.transform.RotateAround(new Vector3(0,0,20),Vector3.up,angl);
			endPos.Add(g.transform.position);
			angl += step*3.5f;
		}
	}

	public void ForButton(int fl)
	{
		tempNumber += fl;
		if (tempNumber > gameObj.Length) {
			tempNumber = 1;
		}
		if (tempNumber < 1) {
			tempNumber = gameObj.Length;
		}
		numberObject = tempNumber;
		Debug.Log (numberObject);

		if (fl == -1) 
		{
			Vector3 temp = endPos[0];
			for(int i=0; i<endPos.Count; i++)
			{
				if(i != endPos.Count-1)
					endPos[i] = endPos[i+1];
				else
					endPos[i]= temp;	
			}
		}

		if (fl == 1) 
		{
			Vector3 temp = endPos[endPos.Count-1];
			for(int i=endPos.Count-1; i>=0; i--)
			{
				if(i != 0)
					endPos[i] = endPos[i-1];
				else
					endPos[i]= temp;	
			}
		}


	}

	void RotateCollection(float speed)
	{
		for(int i = 0; i< gameObj.Length; i++) {
			gameObj[i].transform.position = Vector3.Lerp(gameObj[i].transform.position, endPos[i], Time.deltaTime*speed);
		}
	}


	// Update is called once per frame
	void Update () {
			
	/*	foreach (GameObject g in gameObj) {
			g.transform.LookAt (cam);
		}*/

		RotateCollection (5);
	
	
	}
}
