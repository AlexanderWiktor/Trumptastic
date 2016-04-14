using UnityEngine;
using System.Collections;

public class enemy1Beh : MonoBehaviour {
 public float Speed;
    public int life = 2;
    public float speedup = 300; 
    private GameObject _player;
    private GameObject _spring;
 //private GameObject _diam;
	// Use this for initialization
	void Start () {
  //      _diam = GameObject.FindGameObjectWithTag("diamond");
	 _player = GameObject.FindGameObjectWithTag("Player");
     _spring = GameObject.FindGameObjectWithTag("spring");

     
	}
	
	// Update is called once per frame
	void Update () {
	transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, Speed * Time.deltaTime);

        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            life--;
            Debug.Log("I got Hit");
        }
        if (other.gameObject.tag == "spring")
       {
     GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
     GetComponent<Rigidbody2D>().AddForce(new Vector2(0, speedup));

       }

    }
}
