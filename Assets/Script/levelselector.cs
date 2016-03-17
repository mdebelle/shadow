using UnityEngine;
using System.Collections;

public class levelselector : MonoBehaviour {
	
	public Material Locked;
	public Material Current;
	public Material Succed;

	Renderer 		rend;

	int				score;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.enabled = true;

		if (Locked == true) {
			rend.sharedMaterial = Locked;
		} else if (score == 0) {
			rend.sharedMaterial = Current;
		} else {
			rend.sharedMaterial = Succed;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void				OnMouseDown () {


		return;
	}

	void	checklevelstatus(){

	}


}
