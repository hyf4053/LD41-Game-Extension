using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
public class BoardManager : MonoBehaviour {

	[Serializable]
	public class Count{
		public int minimum;
		public int maximum;
		public Count(int min, int max){
			minimum = min;
			maximum = max;
		}
	}

public int columns = 4;
public int rows = 3;
public Count treeCount = new Count(3,10);

public GameObject[] boardPrefabs;

private Transform boardHolder;
private List<Vector3> gridPositions = new List<Vector3>();
void InitialiseList(){
	gridPositions.Clear();
	for (int x = 1; x < columns; x++){
		for(int y = 1; y < rows; y++){
			gridPositions.Add(new Vector3(x,y,0f));
		}
	}
}

void BoardSetup(){
	boardHolder = new GameObject("Board").transform;
	for(int x = 1; x < columns; x++){
		for(int y = 1; y < rows; y++){
			GameObject toTinstantiate = boardPrefabs[Random.Range(0,boardPrefabs.Length)];
			GameObject instance = Instantiate(toTinstantiate, new Vector3(x,y,0f),Quaternion.identity) as GameObject;

			instance.transform.SetParent(boardHolder);
		}
	}
}

Vector3 RandomPostion(){
	int randomIndex = Random.Range(0,gridPositions.Count);
	Vector3 RandomPostion = gridPositions[randomIndex];
	gridPositions.RemoveAt(randomIndex);
	return RandomPostion;
}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
