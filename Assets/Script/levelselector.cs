﻿using UnityEngine;
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
		rend = GetComponent<Renderer>();
		rend.enabled = true;

	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void				OnMouseDown () {

		if (Mainmanager.mman.getslide () == false && Mainmanager.mman.getcurrentlevelfocus() == levelnumber) {

			Debug.Log ("Lancer le level");

		}

		return;
	}

	void	checklevelstatus(){

	}

	public void	setlevelinfo(int status){
		
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