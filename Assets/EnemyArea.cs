using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyArea : MonoBehaviour {


	// Use this for initialization
	public float xRange;
	public float yRange;
	public GameObject rightBound;
	public GameObject leftBound;
	public GameObject topBound;
	public GameObject bottomBound;
	public float xSpawn;
	public float ySpawn;
	public Vector3 spawnLocation;
	public int dangerLevel;
	public int dangerAmount;
	public float decideVal;
	public GameObject dangerZone1;
	public List<Transform> dayChildTransforms = new List<Transform> ();
	public List<Transform> nightChildTransforms = new List<Transform> ();
	public List<Collider> dayChildren = new List<Collider> ();
	public List<Collider> nightChildren = new List<Collider> ();
	public int enemyCount;
	public GameObject dangerZone2;
	public testCameraScript CamScript;
//	public GameObject dangerZone3;
//	public GameObject dangerZone4;

	void Start () {
		xRange = (rightBound.transform.position.x - leftBound.transform.position.x);
		yRange = (topBound.transform.position.y - bottomBound.transform.position.y);
		enemyCount = 0;

	}

	void spawnDanger()
		{
		/*
		ySpawn = Random.Range (CamScript.minX, CamScript.maxX);
		xSpawn = Random.Range (CamScript.minY, CamScript.maxY);
		spawnLocation = new Vector3 (xSpawn, ySpawn, 0);
		//dangers[dangerAmount] = 
		
		GameObject instance1 = Instantiate (dangerZone1, spawnLocation, Quaternion.identity) as GameObject;
		dayChildTransforms.Add (instance1.GetComponentInChildren<Transform> ());
		*/
		xSpawn = Random.Range (leftBound.transform.position.x, leftBound.transform.position.x + xRange);
		ySpawn = Random.Range (bottomBound.transform.position.y, bottomBound.transform.position.y + yRange);
		spawnLocation = new Vector3 (xSpawn, ySpawn, 0);
		//dangers[dangerAmount] = 

		GameObject instance1 = Instantiate (dangerZone1, spawnLocation, dangerZone1.transform.rotation) as GameObject;
		dayChildTransforms.Add (instance1.GetComponentInChildren<Transform> ());
		dayChildren.Add (instance1.GetComponent<Collider> ());

		xSpawn = Random.Range (leftBound.transform.position.x, leftBound.transform.position.x + xRange);
		ySpawn = Random.Range (bottomBound.transform.position.y, bottomBound.transform.position.y + yRange);
		spawnLocation = new Vector3 (xSpawn, ySpawn, 0);

		GameObject instance2 = Instantiate (dangerZone2, spawnLocation, dangerZone2.transform.rotation) as GameObject;
		nightChildTransforms.Add (instance2.GetComponentInChildren<Transform> ());
		nightChildren.Add (instance2.GetComponent<Collider> ());

		//dayChildTransforms [enemyCount] = dangerZone1.GetComponentInChildren<Transform> ();
		/*
		decideVal = Random.Range (1, 2);
		if (decideVal <= 1) {
			Instantiate (dangerZone1, spawnLocation, Quaternion.identity);
		}
		else if (decideVal <= 2 && decideVal > 1) {
			Instantiate (dangerZone2, spawnLocation, Quaternion.identity);
		}

		else if (decideVal <= 3 && decideVal > 2) {
			Instantiate (dangerZone3, spawnLocation, Quaternion.identity);
		}
		else if (decideVal <= 4 && decideVal > 3) {
			Instantiate (dangerZone4, spawnLocation, Quaternion.identity);
		}
		*/
		}
	// Update is called once per frame
	void Update () {
		if (dangerAmount < dangerLevel) {
			spawnDanger();
			dangerAmount+=1;
		}
		//mathf.clamp the range value to be between the bounds.
	//random range between left and right bound then from bottom and top then use those values for x and y coordinates, lock z to zero.
	}
}
