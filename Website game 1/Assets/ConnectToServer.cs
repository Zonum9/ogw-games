using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public static string userId = null;

    void Start()
    {
        if (userId != null)
        {
            AuthenticationValues auth = new AuthenticationValues(userId);
            PhotonNetwork.AuthValues = auth;
            Debug.Log("Set the values to " + auth);
            PhotonNetwork.KeepAliveInBackground = 3600;
        }
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

}
