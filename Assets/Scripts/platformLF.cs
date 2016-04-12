using UnityEngine;
using System.Collections;

public class platformLF : MonoBehaviour {
   
public float speed;
public float maxX;
public float minX;

protected bool paused;

enum Direction
{
   LEFT, RIGHT
};
private Direction state;
	// Use this for initialization
	void Start () {
state = Direction.LEFT;
	}
	
	// Update is called once per frame
	void Update () {
       if(!paused){
if (state == Direction.RIGHT){
    
if (transform.position.x>maxX)
{
   transform.Translate(Vector2.right * -speed * Time.deltaTime);
  state = Direction.LEFT;
}
else
{
       transform.Translate(Vector2.right * speed * Time.deltaTime);

}}
if (state == Direction.LEFT)
{
    if (transform.position.x<minX)
    {
               transform.Translate(Vector2.right * speed * Time.deltaTime);
state = Direction.RIGHT;
    }
    else
    {
           transform.Translate(Vector2.right * -speed * Time.deltaTime);

    }
       }}
	}
void OnPauseGame () {
paused = true;
}
void OnResumeGame () {
paused = false;
}
}
