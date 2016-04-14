using UnityEngine;
using System.Collections;

public class guiEnd : MonoBehaviour {
 
    private GameObject _player;
	void Start () {
  //      _diam = GameObject.FindGameObjectWithTag("diamond");
	 _player = GameObject.FindGameObjectWithTag("Player");
    }
	void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.tag == "Player"){
           other.SendMessage ("ShowScore", SendMessageOptions.DontRequireReceiver);
       }
    }
 	
}
