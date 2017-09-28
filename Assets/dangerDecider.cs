using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class dangerDecider : MonoBehaviour {
	public GameObject player;
	public EnemyArea Enemies;
	public DayNightCycle TimeProgression;
	public Transform[] Enemy1Transform;
	public float percentRisk = 0;
	public bool playerAlive = true;
	public float Risk;
	public Slider riskVisual;
	public float riskDefault;
	public float timerInterval = 5f;
	public float Timer;
	public Text winText;
	public ButtonInput rayCastScript;
	// Use this for initialization
	void Start () {
		Risk = 0f;
		riskDefault = 0f;
		Timer = timerInterval;
	}
	
	// Update is called once per frame
	void Update () {
		if (TimeProgression.timeProgressionOn == true) {
			Timer -= Time.deltaTime;
		}
		if (Timer <= 0) 
		{
			//riskDefault += .03f;
			//Risk +=.03f;
			//percentRisk = Random.Range (0, 1);
			Timer = timerInterval;
		}

		if (Risk >= 1) 
		{
			winText.text = "you lose";
			TimeProgression.timeProgressionOn = false;
			rayCastScript.gameInProgress = false;
		}
	//	if (percentRisk <= Risk) 
	//	{
	//		Health-=1;
	//	}
	/*foreach (Transform daychild in Enemies.dayChildTransforms)
		{
		
		}
		*/
		Debug.Log (Risk);


		riskVisual.value = Risk;
	}
	void LateUpdate()
	{
		if (Risk >= riskDefault)
		{
		//	Risk -=.0005f;
		}

	}
	void OnTriggerStay(Collider other)
	{
		if (Enemies.dayChildren.Contains (other) || Enemies.nightChildren.Contains (other)) 
		{
			Risk += .005f;
		}
	}
	
}
