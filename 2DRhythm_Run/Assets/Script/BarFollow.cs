using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarFollow : MonoBehaviour {

	private Vector2 velocity;

	public float smoothTimeX;
	public float smoothTimeY;
	public GameObject target;
	public BeatManager beatManager;
    public float bulletSpeed = 5;
    public float noteTimer;
	public float noteInterval = 0;
	public GameObject note;
	public AudioSource BGM;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");
		beatManager = GetComponent<BeatManager>();
		BGM = GameObject.Find("CS496BGM").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		//Space Key execute makeNote.
		if(Input.GetKeyDown(KeyCode.Space))
		{
			makeNote();
			Debug.Log(TimeCheck.getbeat());
		}

		//If position X of bar is larger than -2.3, destory the clone 
		if(transform.position.x >= -2.35){
			var clones = GameObject.FindGameObjectsWithTag("Clone");
			foreach(var clone in clones)
			{
				Destroy(clone);
			}
		}
	}

	//Fixing the Bar position
	void FixedUpdate()
	{
        float posX = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref velocity.y, smoothTimeY);
		TimeCheck.setbeat(BGM.time);
		transform.position = new Vector3(TimeCheck.getPosition(), posY+4,transform.position.z);
	}
	//make Red dot note.
	void makeNote()
    {
        noteTimer += Time.deltaTime;
        if (noteTimer >= noteInterval)
        {
            GameObject noteClone;
            noteClone = Instantiate(note, transform.position, transform.rotation) as GameObject;
            noteTimer = 0;
        }
    }
}
