using UnityEngine;
using System.Collections;

public class coinBeh : MonoBehaviour
{

    private GameObject _plaObj;
    // Use this for initialization
    void Start()
    {
        _plaObj = GameObject.FindGameObjectWithTag("Player");
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
           
            Destroy(this.gameObject);
        }

    }
}
