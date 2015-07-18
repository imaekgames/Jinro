using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AreaAssumption : MonoBehaviour {
	public int x = 9;
	public int y = 16;

	RectTransform rt = null;

	public int magnification = 1;

	// Use this for initialization
	void Start () {
		if (rt == null) rt = gameObject.GetComponent(typeof(RectTransform)) as RectTransform;
	}
	
	// Update is called once per frame
	void Update () {
		
		rt.sizeDelta = new Vector2(x*magnification, y*magnification);
	}
}
