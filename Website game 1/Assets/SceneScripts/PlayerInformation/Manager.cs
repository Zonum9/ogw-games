using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] TMP_InputField playerName;
    [SerializeField] TMP_InputField friends;

    public void StartGame()
    {
        ConnectToServer.userId = playerName.text;
        ManageFriends.friends = friends.text.Split(',');
        SceneManager.LoadScene("Loading scene");
    }
}
