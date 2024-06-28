using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OGWConfig", menuName = "OGW-Core/Config")]
public class OGWCoreConfig : ScriptableObject {

    public string OnJoinedLobbyScene;
    public string OnJoinedRoomScene;
}
