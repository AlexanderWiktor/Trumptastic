using UnityEngine;
using System.Collections;

public class enemy4Beh : MonoBehaviour {

private GameObject _player;
private GameObject _bullet;
private Vector3 _pointToSpawn;
public int life = 10;
public float speed;
public float leftX;
public float rightX;
public float SpawnDistance;
public float timeofspawn;
double timestamp = 0;
public Transform Enemy1Prefab;
Transform spawnPoint;

//public Transform Player;


private enum Snailstate
{
 LEFT, RIGHT
}
private Snailstate state;
	// Use this for initialization
	void Start () {
   spawnPoint = transform.FindChild("SpawnPoint");
   //  Player = transform.FindGameObjectWithTag("Player");
	_player = GameObject.FindGameObjectWithTag("Player");
    _bullet = GameObject.FindGameObjectWithTag("bullet");
 transform.position += new Vector3(speed, 0, 0);

	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.x>rightX)
        {
            state = Snailstate.LEFT;
        }
        if(transform.position.x<leftX)
        {
            state = Snailstate.RIGHT;
        }
        if (state == Snailstate.LEFT)
        {
             transform.Translate(Vector2.right * -speed * Time.deltaTime);
        }
        if (state == Snailstate.RIGHT)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
  if (Vector2.Distance(this.transform.position, _player.transform.position) < SpawnDistance && Time.time >= timestamp)
     {      
                _pointToSpawn = _player.transform.position;  
            Debug.Log("Spawning");
           Instantiate(Enemy1Prefab,spawnPoint.position,spawnPoint.rotation);
            timestamp = Time.time + 3;
        }
	if (life<=0)
    {
        Destroy(this.gameObject);
    }
	}
    
   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            life--;
            Debug.Log("IGOTHIT");
            Debug.Log(life);
        }

    }
}