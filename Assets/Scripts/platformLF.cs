using UnityEngine;
using System.Collections;

public class platformLF : MonoBehaviour {
   
public float speed;
public float maxX;
public float minX;
private float multiplier;
double timestamp;
protected bool paused;
private bool playerOn;

enum Direction
{
   LEFT, RIGHT
};
private Direction state;
	// Use this for initialization
	void Start () {
state = Direction.LEFT;
multiplier = 2;
playerOn = false;
	}
	
	// Update is called once per frame
	void Update () {
       if(!paused){
           if(Time.time >= timestamp && !playerOn)
           {multiplier = 2;}
           
if (state == Direction.RIGHT){
    
if (transform.position.x>maxX)
{
   transform.Translate(Vector2.right * -speed * Time.deltaTime * multiplier);
  state = Direction.LEFT;
}
else
{
       transform.Translate(Vector2.right * speed * Time.deltaTime * multiplier);

}}
if (state == Direction.LEFT)
{
    if (transform.position.x<minX)
    {
               transform.Translate(Vector2.right * speed * Time.deltaTime * multiplier);
state = Direction.RIGHT;
    }
    else
    {
           transform.Translate(Vector2.right * -speed * Time.deltaTime * multiplier);

    }
       }}
	}
void OnPauseGame () {
paused = true;
}
void OnResumeGame () {
paused = false;
}
void OnTriggerEnter2D (Collider2D other) {
     other.transform.parent = gameObject.transform; 
     multiplier = 1;
     playerOn = true;
     } 
void OnTriggerExit2D (Collider2D other) { 
    other.transform.parent = null; 
    timestamp = Time.time + 5;
    playerOn = false;
    }


}
