using UnityEngine;
using System.Collections;

public class MoveTrail : MonoBehaviour {

    public int moveSpeed = 230;
    private GameObject _enemy;
	// Use this for initialization
	void Start () {
_enemy = GameObject.FindGameObjectWithTag("enemy");	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
        Destroy(gameObject, 2);
	
	}
   void OnCollision2D(Collision2D other){
    //  if (other.gameObject.tag == "enemy")

    Debug.Log("I HIT AN ENEMY");
    Destroy (this.gameObject);
 }
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy"){
            Debug.Log("I HIT AN ENEMY withtrigger");
            Destroy(this.gameObject);
        }

    }
}
