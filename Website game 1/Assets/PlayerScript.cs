using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rigid;
    private float moveSpeed = 10;

    PhotonView view;
    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        view = gameObject.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!view.IsMine) {
            return;    
        }

        if (Input.GetKey(KeyCode.W))
        {
            rigid.velocity = new Vector2(0, moveSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rigid.velocity = new Vector2(0, -moveSpeed);
        }
        else
        {
            rigid.velocity = Vector2.zero;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("ball")) {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity *= 1.1f;
        }
    }
}
