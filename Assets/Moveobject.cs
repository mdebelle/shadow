using UnityEngine;
using System.Collections;

public class Moveobject : MonoBehaviour {

	bool	selected;
	bool	vertical;
	bool	move;

	float	posx;
	float	posy;

	// Use this for initialization
	void Start () {
	
		selected = false;
		vertical = false;
		move = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonUp (0)) {
		
			Debug.Log("unselected");
			selected = false;
			vertical = false;
		
		}

		if (Input.GetKeyDown (KeyCode.LeftCommand)) {
			move = true;
		}
		if (Input.GetKeyUp (KeyCode.LeftCommand)) {
			move = false;
		}

		if (Input.GetKeyDown (KeyCode.LeftControl) && move == false) {
			vertical = true;
		}
		if (Input.GetKeyUp (KeyCode.LeftControl)) {
			vertical = false;
		}

		if (selected == true) {

			if (move == true){
				
				if (posy< Input.mousePosition.y)
					transform.Translate(Vector3.up * Time.deltaTime * 2, Space.World);
				else if (posy > Input.mousePosition.y)
					transform.Translate(Vector3.down * Time.deltaTime * 2, Space.World);

				if (posx < Input.mousePosition.x)
					transform.Translate(Vector3.right * Time.deltaTime * 2, Space.World);
				else if (posx > Input.mousePosition.x)
					transform.Translate(Vector3.left * Time.deltaTime * 2, Space.World);

			} else {

				if (vertical == true && move == false) {

					if (posy < Input.mousePosition.y)
						transform.Rotate(Vector3.right * 2, Space.World);
					else if (posy > Input.mousePosition.y)
						transform.Rotate(Vector3.left * 2, Space.World);
					else
						Debug.Log("Do not move");
			
				} else if (vertical == false && move == false) {
				
					if (posx < Input.mousePosition.x)
						transform.Rotate(Vector3.down * 2, Space.World);
					else if (posx > Input.mousePosition.x)
						transform.Rotate(Vector3.up * 2,Space.World);
					else
						Debug.Log("Do not move");

				}

			}
			
			posx = Input.mousePosition.x;
			posy = Input.mousePosition.y;
		}

	}
	
	void OnMouseDown () {

		posx = Input.mousePosition.x;
		posy = Input.mousePosition.y;
		selected = true;

	}
}
