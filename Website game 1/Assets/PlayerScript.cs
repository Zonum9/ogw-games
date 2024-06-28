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
            Debug.Log("collisoin");
            Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 ballVelocity = ballRb.velocity;
            float contactY = collision.GetContact(0).point.y;

            float inter = (contactY- transform.position.y)/ (transform.lossyScale.y / 2);

            float angle = Mathf.Deg2Rad*inter * 55;

            float speed = ballVelocity.magnitude;
            Vector2 newVelocity = new Vector2(speed * Mathf.Cos(angle), speed * Mathf.Sin(angle));
            newVelocity.x = Mathf.Sign(ballVelocity.x) * Mathf.Abs(newVelocity.x);
            ballRb.velocity = newVelocity*1.05f;

        }
    }
}
