using UnityEngine;
using System.Collections;

public class springBeh : MonoBehaviour {
    
double timestamp = 0.0;
private Animator animator;
private GameObject _player;
private AudioSource move;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	_player = GameObject.FindGameObjectWithTag("Player");
move = GetComponents<AudioSource>()[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time>=timestamp)
        {
            animator.SetBool("isStill", true);
            animator.SetBool("isMoving", false);
        }
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("isStill", false);
            animator.SetBool("isMoving", true);
            timestamp = Time.time + 1.0;
            move.Play();
        }
    }
}
