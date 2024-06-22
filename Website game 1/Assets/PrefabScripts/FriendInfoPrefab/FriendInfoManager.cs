using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FriendInfoManager : MonoBehaviourPunCallbacks
{
    public string friendId;
    [SerializeField] TMP_Text onlineStatus;
    [SerializeField] Material onlineMat;
    [SerializeField] Material offlineMat;
    [SerializeField] TMP_Text playerName;
    [SerializeField] TMP_Text playerRoom;
    [SerializeField] Button joinRoom;
    private string friendRoom;
    //
    public void UpdateInfo(List<FriendInfo> allFriends)
    {
        FriendInfo friend = allFriends.Find(f => f.UserId == friendId);

        if (friend == null)
        {
            return;
        }
        if (friend.IsOnline)
        {
            onlineStatus.text = "Online";
            onlineStatus.color = Color.green;
        }
        else
        {
            onlineStatus.text = "Offline";
            onlineStatus.color = Color.red;
        }
        playerName.text = friendId;
        Debug.Log(friend);
        if (friend.IsInRoom)
        {
            playerRoom.enabled = true;
            joinRoom.gameObject.SetActive(true);
            this.friendRoom = friend.Room;
            playerRoom.text = "In Room: " + friend.Room;
        }
        else
        {
            playerRoom.enabled = false;
            joinRoom.gameObject.SetActive(false);
        }
    }

    public void JoinFriendRoom()
    {
        PhotonNetwork.JoinRoom(this.friendRoom);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
