using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

	
	public GameObject	puzzle;
	bool				locked;
	public string		axe;
	public int			piecenumber = 1;


	// Use this for initialization
	void Start () {

	}
	
	void	OnTriggerStay(Collider other) {

		if (other.transform.parent.name == puzzle.name) {
			if (other.name == puzzle.GetComponent<Moveobject> ().axes [axe].name) {
				if (puzzle.GetComponent<Moveobject> ().selectedstate () == false) {
					LevelManager.lman.setlock (axe, piecenumber, true);
				}
			}
		}

	}
	
	void	OnTriggerExit(Collider other) {

		if (other.transform.parent.name == puzzle.name) {
			if (other.name == puzzle.GetComponent<Moveobject> ().axes [axe].name) {
				if (puzzle.GetComponent<Moveobject> ().selectedstate () == false) {
					LevelManager.lman.setlock (axe, piecenumber, false);
				}
			}
		}

	}

}
