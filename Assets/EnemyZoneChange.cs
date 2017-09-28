using UnityEngine;
using System.Collections;

public class EnemyZoneChange : MonoBehaviour 
{
	public EnemyArea Enemies;
	public DayNightCycle TimeProgression;
	public Transform[] Enemy1Transform;
//	public Transform EnemyT2;
//	public Transform EnemyT3;
//	public Transform EnemyT4;
	
	// Use this for initialization
	void Start () {
//		EnemyT2 = Enemies.dangerZone2.GetComponentInChildren<Transform>();
//		EnemyT3 = Enemies.dangerZone3.GetComponentInChildren<Transform>();
//		EnemyT4 = Enemies.dangerZone4.GetComponentInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
	{





		if(TimeProgression.lightSource.intensity >.2f && TimeProgression.dayTime == true && TimeProgression.timeProgressionOn == true)
		{
		/*	foreach( Transform t in Enemies.dayChildTransforms )
			{
				t.localScale += new Vector3 (Time.deltaTime,Time.deltaTime,0);

			}
*/
		
			Enemies.nightChildTransforms.ForEach(delegate( Transform obj)
			                                   {
				if (obj.localScale.x > 1)
				{
					obj.localScale -= new Vector3 (Time.deltaTime,0,Time.deltaTime);
				}
			});
				Enemies.dayChildTransforms.ForEach(delegate(Transform obj)
			{ 
				obj.localScale += new Vector3 (Time.deltaTime,0,Time.deltaTime);
			});
			
		}

		if(TimeProgression.lightSource.intensity < .8f && TimeProgression.dayTime == false && TimeProgression.timeProgressionOn == true)
		{
			Enemies.nightChildTransforms.ForEach(delegate(Transform obj)
			                                     { 
				obj.localScale += new Vector3 (Time.deltaTime,0,Time.deltaTime);
			});
				Enemies.dayChildTransforms.ForEach(delegate( Transform obj)
			{
					obj.localScale -= new Vector3 (Time.deltaTime,0,Time.deltaTime);
			});
			
		}
	}
}
