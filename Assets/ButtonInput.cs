using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ButtonInput : MonoBehaviour 
{
	public Camera buttonCamera;
	private Vector3[] pathOrder;
	public GameObject PathObject;
	public int hitPointCount;
	public GameObject player;
	public Vector3 startPoint;
	public int pathLocale;
	public Vector3 separation;
	public Vector3 separationUnit;
	public float speed;
	public float UnitUser;
	public bool gameInProgress = false;
	public bool gameComplete;
	public GameObject goal;
	public Text WinText;
	public DayNightCycle TimeProgression;
	public dangerDecider riskScript;
	public Text scoreText;
	public float invertRisk;
	public Button restartButton;
	public Vector3 finalPosition;
	// Update is called once per frame
	void SetMoveDirection()
	{
		separation = pathOrder[pathLocale] - player.transform.position;
		UnitUser = (Mathf.Sqrt (Mathf.Pow (separation.x, 2) + Mathf.Pow (separation.y, 2) + Mathf.Pow (separation.z, 2)));
		separationUnit = new Vector3(separation.x / UnitUser, separation.y / UnitUser,0);
		
	}
	void Awake()
	{
		startPoint = player.transform.position;
	}
	void Start()
	{
		pathLocale = 0;
		hitPointCount = 0;
		pathOrder = new Vector3[800];
	//	gameComplete = false;
	}
	void Update () 
	{
	//	Mathf.Clamp (player.transform.position.z, 0, 0.1);
	//	bool useMouseInput = false;

//#if UNITY_EDITOR
//		useMouseInput = true;
/*#endif

		for (int i = 0; i < Input.touchCount; i++)
		{
			Touch currentTouch = Input.touches[i];

			if ( currentTouch.phase == TouchPhase.Began || currentTouch.phase == TouchPhase.Moved || currentTouch.phase == TouchPhase.Stationary )
			{
				Ray ray = buttonCamera.ScreenPointToRay( currentTouch.position );
				RaycastHit hit;

				if ( Physics.Raycast( ray, out hit, Mathf.Infinity ) )
				{
					hit.transform.SendMessage( "MarkPath", SendMessageOptions.DontRequireReceiver );
				}

			}
		}
		*/	
		if (Input.GetMouseButton( 0 ) )
		{
			Ray ray = buttonCamera.ScreenPointToRay( Input.mousePosition );
			RaycastHit hit;

			if ( Physics.Raycast( ray, out hit, Mathf.Infinity ) )
			{
				//Debug.Log ("Hit");
				if (hit.collider.tag == "playField" || hit.collider.tag == "DangerZone")
				{
				hit.transform.SendMessage( "MarkPath", SendMessageOptions.DontRequireReceiver );

				Instantiate(PathObject,hit.point,Quaternion.identity);

				pathOrder[hitPointCount] = hit.point;
					//Debug.Log(pathOrder[hitPointCount]);
				hitPointCount += 1;
				
					//record each hit.point in order then make the dog move towards the transform in orders
				}
			}

		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			//Debug.Log ("move");
			SetMoveDirection ();
			gameInProgress = true;
		}
		if (Vector3.Distance(player.transform.position,pathOrder[pathLocale]) <= 2 && gameInProgress == true) {
				//Debug.Log ("move");
				SetMoveDirection ();
				pathLocale += 1;

		}
		if (Vector3.Distance(player.transform.position,goal.transform.position) <= 2 && gameInProgress == true) {
			finalPosition = player.transform.position;
			gameInProgress = false;

		//	gameComplete = true;
			WinText.text = "you win";
			invertRisk = (1-riskScript.Risk) * 100f;
			string scoreString = "your pug score is " + invertRisk.ToString();
		//	Debug.Log( invertRisk.ToString() );
		//	Debug.Log( scoreString );

			scoreText.text = scoreString;
			TimeProgression.timeProgressionOn = false;
		//	restartButton.enabled = true;
		}
		if (gameInProgress == true) 
		{
			player.transform.position += separationUnit * speed;
		}
	//	pathOrder[pathLocale] -= player.transform.position = separation;

	}
	public void ButtonPressed()
	{
		Application.LoadLevel ("Generic");
	}

}
