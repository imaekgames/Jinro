using UnityEngine;

public class RoomSetting : MonoBehaviour {

	public void Start()
	{
		PhotonNetwork.JoinRandomRoom();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnJoinedRoom()
	{
		
	}

	void OnPhotonRandomJoinFailed()
	{
		PhotonNetwork.CreateRoom(null);
	}
}
