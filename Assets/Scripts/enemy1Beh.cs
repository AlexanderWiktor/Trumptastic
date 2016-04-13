using UnityEngine;
using System.Collections;

public class enemy1Beh : MonoBehaviour {
 public float Speed;
 private GameObject _player;
 //private GameObject _diam;
	// Use this for initialization
	void Start () {
  //      _diam = GameObject.FindGameObjectWithTag("diamond");
	 _player = GameObject.FindGameObjectWithTag("Player");

     
	}
	
	// Update is called once per frame
	void Update () {
	transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, Speed * Time.deltaTime);
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            Destroy(this.gameObject);
            Debug.Log("I got Hit");
        }

    }
}
