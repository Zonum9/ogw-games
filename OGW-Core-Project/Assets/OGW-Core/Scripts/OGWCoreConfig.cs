using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "OGWConfig", menuName = "OGW-Core/Config")]
public class OGWCoreConfig : ScriptableObject {

    public SceneAsset OnJoinedLobbyScene;
    public SceneAsset OnJoinedRoomScene;
}
