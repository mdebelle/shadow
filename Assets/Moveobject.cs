using UnityEngine;
using System.Collections;

public class Moveobject : MonoBehaviour {

	bool	selected;
	float	posx;
	float	posy;


	// Use this for initialization
	void Start () {
	
		selected = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonUp (0)) {
		
			Debug.Log("unselected");
			selected = false;
		
		}

		if (selected == true) {
			Debug.Log ("mouse position = " + Input.mousePosition.x + " " + Input.mousePosition.y);


		}

	}
	
	void OnMouseDown () {

		Debug.Log("selected");
		Debug.Log("screen size = " + Screen.width + " " + Screen.height);
		Debug.Log ("mouse position = " + Input.mousePosition.x + " " + Input.mousePosition.y);
		selected = true;

	}
}
