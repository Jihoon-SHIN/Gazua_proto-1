using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour {

	//public Dictionary<string, List<int>> CommandList = new Dictionary<string, List<int>>();
	public List<int> front = new List<int>();
	public List<int> frontRight;
	public List<int> frontLeft;
	public List<int> attackFront;
	//public static string Command = null;
	public string returnValue = null;
	public int test = 100;

	private float BPM = 130;

	public static CommandManager instance = null;

	// Use this for initialization
	void Start () {
		if(instance==null)
		 instance = this;
		front.Add(1);
		front.Add(2);
		front.Add(3);
		front.Add(4);

		frontRight.Add(1);
		frontRight.Add(3);

		frontLeft.Add(2);
		frontLeft.Add(4);

		attackFront.Add(2);
		attackFront.Add(3);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string commandCheck(List<int> command)
	{
		returnValue = "";
		
		for(int i=0; i<command.Count ; i++)
		{				
			if(command.Count == front.Count){
				if(command[i] != front[i])
				{
					break;
				}
				if(i==command.Count-1)
				{
					return "front";
				}
			}
			
		}

		for(int i=0; i<command.Count ; i++)
		{				
			if(command.Count == frontRight.Count){
				if(command[i] != frontRight[i])
				{
					break;
				}
				if(i==command.Count-1)
				{
					return "frontRight";
				}
			}
			
		}
		for(int i=0; i<command.Count ; i++)
		{				
			if(command.Count == frontLeft.Count){
				if(command[i] != frontLeft[i])
				{
					break;
				}
				if(i==command.Count-1)
				{
					return "frontLeft";
				}
			}
			
		}
		for(int i=0; i<command.Count ; i++)
		{				
			if(command.Count == attackFront.Count){
				if(command[i] != attackFront[i])
				{
					break;
				}
				if(i==command.Count-1)
				{
					return "attackFront";
				}
			}
			
		}

		return "NoCommand";
	}
}
