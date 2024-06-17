using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject ballPrefab;

    private void Start()
    {
        int playerNum = PhotonNetwork.LocalPlayer.ActorNumber;
        Vector2 pos = new Vector2((playerNum == 1 ? -1 : 1) * 6, 0);
        PhotonNetwork.Instantiate(playerPrefab.name, pos, Quaternion.identity);

        if (playerNum == 2) {
            GameObject ball=PhotonNetwork.Instantiate(ballPrefab.name, Vector2.zero, Quaternion.identity);
            ball.GetComponent<BallScript>().setMoveDirection(Random.Range(0, 2) == 1 ? 1 : -1);            
        }

        Debug.Log("the player number is " + PhotonNetwork.LocalPlayer.ActorNumber);
    }
}
