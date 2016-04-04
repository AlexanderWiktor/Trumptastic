using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    //public things
    public int score = 0;
    public int life = 3; 
    public float speed;
    public float speedup;
    public float jumpforce;
    public float hitforce;
    //things for code
    double timestamp = 10.0;
    private bool isGrounded;
    private bool isJumping;
    private bool hasYkey;
    private bool onStairs;
    //objects
    private Animator animator;
    private GameObject scoreObj;
    private GameObject coinObj;
    private GameObject diamObj;
    private GameObject fireObj;
    private GameObject lifeObj;
    private GameObject obsObj;
    private GameObject _hearthObj;
    private GameObject _keyY;
    private GameObject _doorY;
    private GameObject _nextlevel;
   private GameObject _stairs;
   private GameObject _sekret;
 //   private AudioSource jumpSound;
 //   private AudioSource pickupCoinSound;
    
    //enum
    enum PlayerState
    {
        NORMAL, EGG
    };
    
    private PlayerState state;
	// Use this for initialization
	void Start ()
	{
	    hasYkey = false;
        scoreObj = GameObject.FindGameObjectWithTag("point");
        lifeObj = GameObject.FindGameObjectWithTag("lifescore");
        animator = GetComponent<Animator>();
//	    jumpSound = GetComponents<AudioSource>()[0];
//	    pickupCoinSound = GetComponents<AudioSource>()[1];
        coinObj = GameObject.FindGameObjectWithTag("coin");
	    diamObj = GameObject.FindGameObjectWithTag("Diamond");
        fireObj = GameObject.FindGameObjectWithTag("fire");
	    obsObj = GameObject.FindGameObjectWithTag("ground");
	    _hearthObj = GameObject.FindGameObjectWithTag("hearth");
	    _keyY = GameObject.FindGameObjectWithTag("keyY");
	    _doorY = GameObject.FindGameObjectWithTag("doorY");
        _nextlevel = GameObject.FindGameObjectWithTag("nextlevel");
        _sekret = GameObject.FindGameObjectWithTag("sekret");
        state = PlayerState.NORMAL;
        _stairs = GameObject.FindGameObjectWithTag("stairs");
    }

    // Update is called once per frame
    void Update () {
        // PAUSING
        if (state == PlayerState.EGG)
        {
            if(Time.timeScale ==1.0F)
            {Time.timeScale = 0.0F;
            Object[] objects = FindObjectsOfType (typeof(GameObject));
foreach (GameObject go in objects)
{
    go.SendMessage ("OnPauseGame", SendMessageOptions.DontRequireReceiver);
        }}
            if (Input.GetKeyDown(KeyCode.U))
            {
                state = PlayerState.NORMAL;
                if(Time.timeScale ==0.0F)
                {
                Time.timeScale = 1.0F;
                 Object[] objects = FindObjectsOfType (typeof(GameObject));
foreach (GameObject go in objects)
{
    go.SendMessage ("OnResumeGame", SendMessageOptions.DontRequireReceiver);
        }
                }
            }
        }
        //PAUSING ENDS
        
        if (state == PlayerState.NORMAL)
        {
         if (onStairs ==true)
        {            
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
        else
        {
                        GetComponent<Rigidbody2D>().isKinematic = false;
        }
	    if (Input.GetButtonDown("Fire1"))
	    {
	       if (isGrounded == true)
	        {


	            animator.SetBool("IsWalking", true);
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpforce));
	            timestamp = Time.time + 10.0;
	            isJumping = true;
	            isGrounded = false;
	        }
            else if (isJumping == true)
            {
                animator.SetBool("IsWalking", true);
           //     jumpSound.Play();
                GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpforce));
                timestamp = Time.time + 10.0;
                isJumping = false;
            }
        }
	    if (Input.GetAxis("Horizontal") != 0)
	    {
	        animator.SetBool("IsWalking",true);
            transform.position += new Vector3(Input.GetAxis("Horizontal") * speed, 0, 0);
	        timestamp = Time.time + 10.0;
	    }
	    else
	    {
	        animator.SetBool("IsWalking", false);
	    }
	    if (Time.time >= timestamp)
	    {
          
            animator.SetBool("IsTired",true);
        }
        else
	    {
            //animator.SetBool("IsWalking", false);
            animator.SetBool("IsTired", false);

        }
        if (life<=0 || Input.GetButtonDown("Fire3"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        if (onStairs)
        {
            transform.position += new Vector3(0, Input.GetAxis("Vertical") * speed, 0);
        
        }
        }      
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "coin")
        {
            score++;
            scoreObj.GetComponent<TextMesh>().text = "Score:" + score;
        }
        if (other.gameObject.tag == "Diamond")
        {
            score+=5;
            scoreObj.GetComponent<TextMesh>().text = "Score: " + score;
        }
        if (other.gameObject.tag == "fire")
        {
            
            life--;
            lifeObj.GetComponent<TextMesh>().text = "Lives: " + life;
            isGrounded = true;
        }
        if (other.gameObject.tag == "enemyL")
        {
            life--;
            lifeObj.GetComponent<TextMesh>().text = "Lives: " + life;
            isGrounded = true;
        }
         if (other.gameObject.tag == "enemyR")
        {
            life--;
            lifeObj.GetComponent<TextMesh>().text = "Lives: " + life;
            isGrounded = true;
        }
        if (other.gameObject.tag == "ground")
        {
            isGrounded = true;
            isJumping = false;
        }
        if (other.gameObject.tag == "hearth")
        {
            life++;
            lifeObj.GetComponent<TextMesh>().text = "Lives: " + life;

        }
        if (other.gameObject.tag == "keyY")
        {
            hasYkey = true;
            Destroy(GameObject.FindWithTag("keyY"));
        }
        if (other.gameObject.tag == "doorY")
        {
            if (hasYkey == true)
            {
                Destroy(GameObject.FindWithTag("doorY"));
            }
        }
        if (other.gameObject.tag == "nextlevel")
        {
             Application.LoadLevel ("second");
        }
        if (other.gameObject.tag == "stairs")
        {
            onStairs = true;
            isGrounded=true;
        }
        if (other.gameObject.tag == "sekret")
        {
            state = PlayerState.EGG;
        }
       
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "stairs")
        {
            onStairs = false;
        }
    }


}
