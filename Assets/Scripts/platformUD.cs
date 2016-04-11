using UnityEngine;
using System.Collections;

public class platformUD : MonoBehaviour {
    
public float speed;
public float maxY;
public float minY;
enum Direction
{
    UP, DOWN
};
private Direction state;
	// Use this for initialization
	void Start () {
state = Direction.UP;
	}
	
	// Update is called once per frame
	void Update () {
if (state == Direction.UP){
    
if (transform.position.y>maxY)
{
   transform.Translate(Vector2.up * -speed * Time.deltaTime);
  state = Direction.DOWN;
}
else
{
       transform.Translate(Vector2.up * speed * Time.deltaTime);

}}
if (state == Direction.DOWN)
{
    if (transform.position.y<minY)
    {
               transform.Translate(Vector2.up * speed * Time.deltaTime);
state = Direction.UP;
    }
    else
    {
           transform.Translate(Vector2.up * -speed * Time.deltaTime);

    }
}
	}
}
