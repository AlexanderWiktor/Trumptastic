using UnityEngine;
using System.Collections;

public class backgroundBeh : MonoBehaviour {

private GameObject camera;
	// Use this for initialization
	void Start () {
	camera = GameObject.FindGameObjectWithTag("MainCamera");
    
   
	}
	
	// Update is called once per frame
	void Update () {
  //  float targetX = transform.position.x;
this.gameObject.transform.position = new Vector3(camera.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
	}
}
