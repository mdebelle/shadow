using UnityEngine;
using System.Collections;

public class Moveobject : MonoBehaviour {

	bool	selected;
	bool	vertical;
	bool	move;

	float	posx;
	float	posy;
	
	bool	levelhard;
	bool	levelmedium;

	// Use this for initialization
	void Start () {
	
		selected = false;
		vertical = false;
		move = false;
		
		levelhard = false;
		levelmedium = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonUp (0)) {
		
			selected = false;
			vertical = false;
			move = false;

		}

		if (Input.GetKeyDown (KeyCode.LeftCommand) && levelhard == true)
			move = true;
		if (Input.GetKeyUp (KeyCode.LeftCommand))
			move = false;

		if (Input.GetKeyDown (KeyCode.LeftControl) && move == false  && levelmedium == true)
			vertical = true;
		if (Input.GetKeyUp (KeyCode.LeftControl))
			vertical = false;

		if (selected == true) {

			if (move == true && levelhard == true){
				
				if (posy< Input.mousePosition.y)
					transform.Translate(Vector3.up * Time.deltaTime * 2, Space.World);
				else if (posy > Input.mousePosition.y)
					transform.Translate(Vector3.down * Time.deltaTime * 2, Space.World);

				if (posx < Input.mousePosition.x)
					transform.Translate(Vector3.right * Time.deltaTime * 2, Space.World);
				else if (posx > Input.mousePosition.x)
					transform.Translate(Vector3.left * Time.deltaTime * 2, Space.World);

			} else {

				if (vertical == true && move == false && levelmedium == true) {

					if (posy < Input.mousePosition.y)
						transform.Rotate(Vector3.right * 2, Space.World);
					else if (posy > Input.mousePosition.y)
						transform.Rotate(Vector3.left * 2, Space.World);
			
				} else if (vertical == false && move == false) {
				
					if (posx < Input.mousePosition.x)
						transform.Rotate(Vector3.down * 2, Space.World);
					else if (posx > Input.mousePosition.x)
						transform.Rotate(Vector3.up * 2,Space.World);

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
