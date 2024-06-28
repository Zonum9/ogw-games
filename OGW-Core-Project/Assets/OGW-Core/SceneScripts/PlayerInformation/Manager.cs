using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] TMP_InputField playerName;
    [SerializeField] TMP_InputField friends; 

    public void StartGame()
    {
        AuthenticationValues auth = new AuthenticationValues(playerName.text);
        PhotonNetwork.AuthValues = auth;
        ManageFriends.friends = friends.text.Split(',');
        SceneManager.LoadScene("Loading");
    }
}
