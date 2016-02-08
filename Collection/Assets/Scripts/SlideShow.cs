using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class SlideShow : MonoBehaviour {
	
	public Image [] slides;
	public Canvas canvas;
	int tempNumber =0;
	int numberObject = 0;
	List<Vector3> endPos = new List<Vector3>();
	public int speedSlide = 5;
	
	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.Landscape;
		Vector3 beginPosition = slides [0].GetComponent<RectTransform> ().localPosition;
		beginPosition.x -= canvas.GetComponent<RectTransform> ().rect.width;
		foreach (Image sl in slides) {
			sl.GetComponent<RectTransform>().localPosition = beginPosition;
			beginPosition.x += canvas.GetComponent<RectTransform>().rect.width;
			endPos.Add(sl.transform.position);
		}
		
	}
	
	
	public void ForButton(int fl)
	{
		tempNumber += fl;
		if (tempNumber > slides.Length) {
			tempNumber = 1;
		}
		if (tempNumber < 1) {
			tempNumber = slides.Length;
		}
		numberObject = tempNumber;
		
		Debug.Log(numberObject);
		if (fl == -1) 
		{
			int tempIndexOrder = slides[0].transform.GetSiblingIndex();
			Vector3 temp = endPos[0];
			for(int i=0; i<endPos.Count; i++)
			{
				if(i != endPos.Count-1){
					endPos[i] = endPos[i+1];
					slides[i].transform.SetSiblingIndex(slides[i+1].transform.GetSiblingIndex());
				}
				else{
					endPos[i]= temp;
					slides[i].transform.SetSiblingIndex(tempIndexOrder);
				}
			}
		}
		
		if (fl == 1) 
		{
			int tempIndexOrder = slides[slides.Length-1].transform.GetSiblingIndex();
			Vector3 temp = endPos[endPos.Count-1];
			for(int i=endPos.Count-1; i>=0; i--)
			{
				if(i != 0){
					endPos[i] = endPos[i-1];
					slides[i].transform.SetSiblingIndex(slides[i-1].transform.GetSiblingIndex());
				}
				else{
					endPos[i]= temp;	
					slides[i].transform.SetSiblingIndex(tempIndexOrder);
				}
			}
		}
		
		
	}
	
	
	void RotateCollection(float speed)
	{
		for(int i = 0; i< slides.Length; i++) {
			slides[i].transform.position = Vector3.Lerp(slides[i].transform.position, endPos[i], Time.deltaTime*speed);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		RotateCollection (speedSlide);
	}
}
