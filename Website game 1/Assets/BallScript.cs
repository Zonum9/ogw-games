using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
    
{
    private Rigidbody2D rigid;
    void Awake()
    {
        rigid=gameObject.GetComponent<Rigidbody2D>();        
    }

    public void setMoveDirection(int direction) {
        rigid.transform.position = Vector2.zero;
        rigid.velocity = new Vector2(direction * 5, Random.Range(-5,5));
        Debug.Log("this ran");
    }

}
