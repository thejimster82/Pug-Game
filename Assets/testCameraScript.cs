using UnityEngine;
using System.Collections;

public class testCameraScript : MonoBehaviour {
	public float mapX = 100f;
	public float mapY = 100f;
	public Camera cam;
	public GameObject gameField;
	
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	
	public void Start() {
	 	float vertExtent = cam.orthographicSize;    
		float horzExtent = vertExtent * Screen.width / Screen.height;
		
		// Calculations assume map is position at the origin
		minX = horzExtent - mapX / 2.0f;
		maxX = mapX / 2.0f - horzExtent;
		minY = vertExtent - mapY / 2.0f;
		maxY = mapY / 2.0f - vertExtent;
		Debug.Log (minX);
		Debug.Log (maxX);
		Debug.Log (minY);
		Debug.Log (maxY);
	//	GameObject thing = Instantiate (gameField, new Vector3 (0, 0, 0), Quaternion.LookRotation) as GameObject;
	//	thing.transform.localScale = new Vector3 (horzExtent,0 , vertExtent);


	}
	
	/*public void LateUpdate() {
		Vector3 v3 = transform.position;
		v3.x = Mathf.Clamp(v3.x, minX, maxX);
		v3.y = Mathf.Clamp(v3.y, minY, maxY);
		transform.position = v3;
		Debug.Log (v3);
	}
*/
}
