using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwitchScene : MonoBehaviour {
	public Dropdown drop;


	public void SwitchMode()
	{
		if(drop.value == 0)
			Application.LoadLevel("1");

		if(drop.value == 1)
			Application.LoadLevel("2");

	}

}
