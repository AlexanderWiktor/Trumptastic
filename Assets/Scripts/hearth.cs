using UnityEngine;
using System.Collections;

public class hearth : MonoBehaviour
{

    private GameObject _player;
	// Use this for initialization
	void Start ()
	{
	    _player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            Destroy(this.gameObject);
        }

    }
}
