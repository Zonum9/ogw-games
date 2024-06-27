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
        StartCoroutine(helper(direction));
        
    }
    private IEnumerator helper(int direction)
    {
        rigid.transform.position = Vector2.zero;
        rigid.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.5f);
        rigid.velocity = new Vector2(direction * 5, Random.Range(-5, 5));
        Debug.Log("this ran");
    }

}
