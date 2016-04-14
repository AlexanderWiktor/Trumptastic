using UnityEngine;
using System.Collections;

public class teleporterBeh : MonoBehaviour {

public float PlayerX;
public float PlayerY;
private GameObject _player;
	// Use this for initialization
	void Start () {
       _player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.tag == "Player")
      {
          float[] teleportStorage = new float[2];
          teleportStorage[0] = PlayerX;
          teleportStorage[1] = PlayerY;
          other.SendMessage("Teleport", teleportStorage);
      }       
    }
}