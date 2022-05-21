using UnityEngine;
using System.Collections;

public class PixelPerfectCameraScript : MonoBehaviour 
{
	public int size = 2;
	// Update is called once per frame
	void Update () 
	{
		float i = Screen.height / size;
		GetComponent<Camera>().orthographicSize = i / 64;
	}
}
