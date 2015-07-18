using UnityEngine;
using System.Collections;

public class NetworkState : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnGUI()
	{
		if (PhotonNetwork.inRoom) foreach (PhotonPlayer pp in PhotonNetwork.playerList) { GUILayout.Label(pp.ToString()); }
	}
}
