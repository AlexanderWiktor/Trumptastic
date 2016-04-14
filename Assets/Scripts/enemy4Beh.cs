using UnityEngine;
using System.Collections;

public class enemy4Beh : MonoBehaviour {

private GameObject _player;
private GameObject _bullet;
private Vector3 _pointToSpawn;
private bool hasseen=false;
public int life = 10;
public float speed;
public float leftX;
public float rightX;
public float SpawnDistance;
public float timeofspawn;
double timestamp = 0;
public Transform Enemy1Prefab;
public Transform vote5Prefab;
Transform spawnPoint;

//public Transform Player;
     public AudioSource[] sources = new AudioSource[1];
AudioSource greetSound;
AudioSource dieSound;
AudioSource fuckSound;
AudioSource greenSound;
Transform dropPoint;
private enum Snailstate
{
 LEFT, RIGHT
}
private Snailstate state;
	// Use this for initialization
	void Start () {
   spawnPoint = transform.FindChild("SpawnPoint");
    dropPoint = transform.FindChild("dropper");
   //  Player = transform.FindGameObjectWithTag("Player");
	_player = GameObject.FindGameObjectWithTag("Player");
    _bullet = GameObject.FindGameObjectWithTag("bullet");
 transform.position += new Vector3(speed, 0, 0);
 sources = GetComponents<AudioSource>();
        greetSound = sources[1];
        dieSound = sources[0];
        fuckSound = sources[2];
        greenSound = sources[3];

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
        if(life==2)
        {
            dieSound.Play();
        }
	if (life<=0)
    {
       // dieSound.Play();
         _player.SendMessage("DieSound",SendMessageOptions.DontRequireReceiver);
        Destroy(this.gameObject);
        Instantiate(vote5Prefab,dropPoint.position,dropPoint.rotation);

         
    }
    if (life==10)
    {
        greenSound.Play();
    }
    if (life==16)
    {
        fuckSound.Play();
    }
    if(!hasseen && Vector2.Distance(this.transform.position, _player.transform.position) < SpawnDistance)
    {
        greetSound.Play();
        hasseen=true;
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