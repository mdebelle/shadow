using UnityEngine;
using System.Collections;

public class levelselector : MonoBehaviour {
	
	public Material Locked;
	public Material Current;
	public Material Succed;

	public int		levelnumber;

	Renderer 		rend;

	int				score;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void				OnMouseDown () {

		if (Mainmanager.mman.getslide () == false && Mainmanager.mman.getcurrentlevelfocus () == levelnumber) {

			if (PlayerPrefs.GetInt ("Level"+levelnumber) >= 0) {
				Application.LoadLevel (levelnumber + 1);
			} else {
				Debug.Log ("Forbiden");
			}
		}

		return;
	}

	void	checklevelstatus(){

	}

	public void	setlevelinfo(int status){
		
		rend = GetComponent<Renderer>();
		rend.enabled = true;

		Debug.Log ("render " + status);

		if (status < 0) {
			rend.sharedMaterial = Locked;
		} else if (status == 0) {
			rend.sharedMaterial = Current;
		} else {
			rend.sharedMaterial = Succed;
		}
		return;

	}
}
