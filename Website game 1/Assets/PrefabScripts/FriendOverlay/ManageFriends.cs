using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManageFriends : MonoBehaviourPunCallbacks
{

    [SerializeField] Image playerProfilePic;
    [SerializeField] TMP_Text playerName;
    [SerializeField] GameObject friendItemPrefab;
    [SerializeField] Transform friendList;
    [SerializeField] Button refresh;

    public static string[] friends = {};
    private List<FriendInfoManager> friendManagers = new();

    void Start()
    {
        playerName.text = PhotonNetwork.AuthValues.UserId;
        foreach (string friend in friends)
        {
            GameObject newItem = Instantiate(friendItemPrefab, friendList);
            FriendInfoManager manager = newItem.GetComponent<FriendInfoManager>();
            manager.friendId = friend;
            friendManagers.Add(manager);
            newItem.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
        }
        FindFriends();
    }

    public void FindFriends()
    {
        refresh.enabled = false;
        PhotonNetwork.FindFriends(friends);
    }

    public override void OnFriendListUpdate(List<FriendInfo> friendsInfo)
    {
        foreach (FriendInfoManager manager in friendManagers)
        {
            manager.UpdateInfo(friendsInfo);
        }
        refresh.enabled = true;
    }
}
