using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GoalScript : MonoBehaviour
{
    public TMPro.TMP_Text scoreDisplay;
    private PhotonView scoreView;
    public GameObject ballPrefab;
    [SerializeField] private int direction;
    private int score = 0;
    // Start is called before the first frame update
    void Awake()
    {
        scoreDisplay.text = score.ToString();
        scoreView = GetComponent<PhotonView>();
    }

    [PunRPC]
    public void updateScore()
    {
        score += 1;
        scoreDisplay.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreView.RPC("updateScore", RpcTarget.All);
        PhotonNetwork.Destroy(collision.gameObject);
        GameObject ball = PhotonNetwork.Instantiate(ballPrefab.name, Vector2.zero, Quaternion.identity);
        ball.GetComponent<BallScript>().setMoveDirection(direction);
        
    }
}
