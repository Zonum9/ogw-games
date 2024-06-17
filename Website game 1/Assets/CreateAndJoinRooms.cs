using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{

    public TMPro.TMP_InputField createIn;
    public TMPro.TMP_InputField joinIn;

    public void CreateRoom() {
        PhotonNetwork.CreateRoom(createIn.text);
        Debug.Log("Create pressed");
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinIn.text);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room reached");
        PhotonNetwork.LoadLevel("PongGame");
    }

}
