using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour {
	//public GameObject lightSource;
	public Light lightSource;
	public bool dayTime;
	public bool timeProgressionOn;
	// Use this for initialization
	void Start () {
		dayTime = true;
		timeProgressionOn = false;
	}
	//intensity of 1 is at noon, 
	//intensity of .12 is at midnight
	//intensity of .44 is at dusk when decreasing
	//intensity of .44 is dawn when increasing
	
	// Update is called once per frame
	void Update () 
	{
	if (Input.GetKeyDown (KeyCode.Space))
		{
			timeProgressionOn = true;
		}
		if (timeProgressionOn == true) 
		{
			if(lightSource.intensity >.12f && dayTime ==true)
			{
			lightSource.intensity -= Time.deltaTime*.1f;
			}
			if(lightSource.intensity <= .12f && dayTime == true)
			{
				dayTime = false;
			}
			if(lightSource.intensity < 1f && dayTime == false)
			{
				lightSource.intensity += Time.deltaTime*.1f;
			}
			if(lightSource.intensity >= 1f && dayTime == false)
			{
				dayTime = true;
			}
		}
	}
}
