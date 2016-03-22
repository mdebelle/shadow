using UnityEngine;
using System.Collections;

public class Mainmanager : MonoBehaviour {

	public	levelselector[]	Levels;
	bool					slide;

	int						currentlevel;

	
	static public Mainmanager mman;

	// Use this for initialization
	void Start () {
		
		mman = this.GetComponent<Mainmanager> ();
		if (PlayerPrefs.GetInt("Ok") != 1)
			setDefaultData();
		else
			getDefaultData();


		slide = false;
		Debug.Log ("la");

	}

	void	setDefaultData(){

		resetAllData ();
		return;
	}
	
	void	getDefaultData(){

		for (int i = 0; i < Levels.Length; i++) {
			Levels[i].GetComponent<levelselector>().setlevelinfo(PlayerPrefs.GetInt ("Level"+i));
		}
		return;
	}


	public void		resetAllData(){

		Debug.Log("Reseted");

		PlayerPrefs.DeleteAll();
		PlayerPrefs.Save ();
		
		PlayerPrefs.SetInt ("Level0", 0);
		PlayerPrefs.SetInt ("Level1", -1);
		PlayerPrefs.SetInt ("Level2", -1);
		PlayerPrefs.SetInt ("Level3", -1);

		PlayerPrefs.SetInt("Ok", 1);
		PlayerPrefs.Save ();

		getDefaultData();
		return;
	}

	public void		setslide(bool val){
		slide = val;
		return;
	}

	public bool		getslide(){
		return slide;
	}

	public void		setcurrentlevelfocus(int val){
		currentlevel = val;
	}

	public int		getcurrentlevelfocus(){
		return currentlevel;
	}

	// Update is called once per frame
	void Update () {
	
	}

}
