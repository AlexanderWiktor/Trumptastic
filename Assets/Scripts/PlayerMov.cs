using UnityEngine;
using System.Collections;

public class PlayerMov : MonoBehaviour {
public float speed;
public float jumpforce;


private bool isGrounded;
private bool isJumping;

private GameObject _groObj;
	// Use this for initialization
	void Start () {
        
	_groObj = GameObject.FindGameObjectWithTag("ground");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded == true)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jumpforce));
                isJumping = true;
                isGrounded = false;
            }
            else if (isJumping == true)
            {
                 GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jumpforce));
                isJumping=false;
            }
        }
     //   if (Input.GetButtonDown)
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = true;
            isJumping = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
