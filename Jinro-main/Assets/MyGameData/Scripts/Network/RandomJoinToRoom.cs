using UnityEngine;
using System.Collections;

public class RandomJoinToRoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PhotonNetwork.JoinRandomRoom ();
		Debug.Log (PhotonNetwork.room);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPhotonRandomJoinFailed()
	{
		PhotonNetwork.CreateRoom(null);
	}

	public void OnJoinedRoom(){
		Debug.Log (PhotonNetwork.room);
		PhotonNetwork.Instantiate ("VoicePack",Vector3.zero,Quaternion.identity,0);
	}
}
