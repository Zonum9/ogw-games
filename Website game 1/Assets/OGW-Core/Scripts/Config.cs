using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Config : MonoBehaviour
{
    public static Config Instance { get; private set; }

    public static string OnJoinedLobbyScene => Instance.config.OnJoinedLobbyScene.name;
    public static string OnJoinedRoomScene => Instance.config.OnJoinedRoomScene.name;

    [SerializeField] OGWCoreConfig config;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
