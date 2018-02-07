using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	//Custom Class can't see in inspector.
	//Serializable help us to see variable in inspector.
	[Serializable]
	public class Count{
		public int minimum;
		public int maximum;

		public Count(int min, int max){
			minimum = min;
			maximum = max;
		}
	}

	public int columns = 40;
	public int rows= 3;
	public Count foodCount = new Count(30,40);
	public Count enemyCount = new Count(1,1);
	public GameObject[] floorTiles;
	public GameObject[] wallTiles;
	public GameObject[] foodTiles;
	public GameObject[] enemyTiles;
	public GameObject[] InnerWallTiles;
	private Transform boardHolder;
	private List<Vector3> gridPositions = new List<Vector3>();

	void initialiseList()
	{
		gridPositions.Clear();
		for(int x=0; x<rows ;x++)
		{
			for(int y=0; y<columns; y++)
			{
				gridPositions.Add(new Vector3(x,y, 0f));
			}
		}

	}
	void BoardSetup()
	{
		boardHolder = new GameObject("Board").transform;
		for(int x=-1 ; x<rows+1 ; x++)
		{
			for(int y=-1; y<columns+1; y++)
			{
				GameObject toInstantiate;
				if( (x+y+2) %2 ==0 ) toInstantiate = floorTiles[0];
				else toInstantiate = floorTiles[1];
				
				if(x==-1 || x==rows) toInstantiate = wallTiles[Random.Range(0, wallTiles.Length)];

				GameObject instance = Instantiate(toInstantiate, new Vector3(x,y,0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent(boardHolder);
			}
		}
		for(int x=-1 ; x<rows+1; x++)
		{
			GameObject toInstantiate;
			toInstantiate = wallTiles[0];
			GameObject instance = Instantiate(toInstantiate, new Vector3(x, -2, 0f), Quaternion.identity) as GameObject;
			instance.transform.SetParent(boardHolder);
		}
	}  

	Vector3 RandomPostition()
	{
		int randomindex = Random.Range(0, gridPositions.Count);
		Vector3 randomPosition = gridPositions[randomindex];
		gridPositions.RemoveAt(randomindex);
		return randomPosition;
	}

	void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
	{
		int objectCount = Random.Range(minimum, maximum+1);
		for( int i=0; i<objectCount ; i++)
		{
			Vector3 randomPostion = RandomPostition();
			GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
			Instantiate (tileChoice, randomPostion, Quaternion.identity);			
		}
	}
	public void SetupScene(int lvl)
	{
		BoardSetup();
		initialiseList();
		LayoutObjectAtRandom(foodTiles, foodCount.minimum, foodCount.maximum);
		LayoutObjectAtRandom(enemyTiles, 10, 10);
		LayoutObjectAtRandom(InnerWallTiles, 2, 4);
	}
}
