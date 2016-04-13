using UnityEngine;
using System.Collections;

public class enemy5Beh : MonoBehaviour {

private GameObject _player;
private GameObject _bullet;
public float speed;
public float leftX;
public float rightX;
private enum Snailstate
{
 LEFT, RIGHT
}
private Snailstate state;
	// Use this for initialization
	void Start () {
	_player = GameObject.FindGameObjectWithTag("Player");
    _bullet = GameObject.FindGameObjectWithTag("bullet");
 transform.position += new Vector3(speed, 0, 0);

	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.x>rightX){
state = Snailstate.LEFT;
        }
        if(transform.position.x<leftX)
        {
            state = Snailstate.RIGHT;
        }
        if (state == Snailstate.LEFT)
        {
             transform.Translate(Vector2.right * speed * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 180);
        }
        if (state == Snailstate.RIGHT)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 0);
        }

	
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