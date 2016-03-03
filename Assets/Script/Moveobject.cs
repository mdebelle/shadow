using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Moveobject : MonoBehaviour {

	bool									solved;
	bool									selected;
	bool									vertical;
	bool									move;

	float									posx;
	float									posy;

	public GameObject						keyx;
	public GameObject						keyy;
	public GameObject						keyz;

	public Dictionary<string, GameObject> axes = new Dictionary<string, GameObject>();

	// Use this for initialization
	void				Start () {

		solved = false;
		selected = false;
		vertical = false;
		move = false;

		axes.Add ("x", keyx);
		axes.Add ("y", keyy);
		axes.Add ("z", keyz);

	}
	
	// Update is called once per frame
	void				Update () {

		if (Input.GetMouseButtonUp (0)) {
		
			selected = false;
			vertical = false;
			move = false;

		}

		if (Input.GetKeyDown (KeyCode.LeftCommand) && LevelManager.lman.ishard() == true)
			move = true;
		if (Input.GetKeyUp (KeyCode.LeftCommand))
			move = false;

		if (Input.GetKeyDown (KeyCode.LeftControl) && move == false  && LevelManager.lman.ismedium() == true)
			vertical = true;
		if (Input.GetKeyUp (KeyCode.LeftControl))
			vertical = false;

		if (selected == true) {

			if (move == true && LevelManager.lman.ishard() == true){
				
				if (posy< Input.mousePosition.y)
					transform.Translate(Vector3.up * Time.deltaTime * 2, Space.World);
				else if (posy > Input.mousePosition.y)
					transform.Translate(Vector3.down * Time.deltaTime * 2, Space.World);

				if (posx < Input.mousePosition.x)
					transform.Translate(Vector3.right * Time.deltaTime * 2, Space.World);
				else if (posx > Input.mousePosition.x)
					transform.Translate(Vector3.left * Time.deltaTime * 2, Space.World);

			} else {

				if (vertical == true && move == false && LevelManager.lman.ismedium() == true) {

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
	
	void				OnMouseDown () {

		if (solved == false) {

			posx = Input.mousePosition.x;
			posy = Input.mousePosition.y;
			selected = true;

		}
		return;
	}

	public bool			selectedstate() {
		return (selected);
	}

	public void			setsolved() {

		solved = true;
		return;
	}

}
