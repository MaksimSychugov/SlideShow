using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
public class TextWriter : MonoBehaviour {

	string msg ="Объект №";
	int s;
	Text tx;
	// Use this for initialization
	void Start () {
		tx = GetComponent<Text> ();
	}

	public IEnumerator Write()
	{
		//yield return new WaitForSeconds (1.0f);
		for (int i = 0; i<= msg.Length; i++) {
			tx.text = msg.Substring(0,i);
			yield return null;
		}
	}

	// Update is called once per frame
	void Update () {
		s = CollectionGameObjects.numberObject;
		msg = string.Format("Объект № {0}",s);
		tx.text = msg;


		
	}
}
