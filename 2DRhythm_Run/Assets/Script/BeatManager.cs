using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour {
	public AudioSource bgsound;
	public AudioSource beatsound;


	float bpm = 130;
	int clapperbeat = 4;

	private static float bgtime;
	int bgbeat;
	int prevbeat = -1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			beatsound.Play();
			TimeCheck.setbeat(bgsound.time);

		}
    }


}
