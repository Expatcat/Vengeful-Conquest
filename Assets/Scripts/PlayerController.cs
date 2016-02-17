using UnityEngine;
using System.Collections;


/*
 * Handles movement of the player North, South, East, and West, based on keys pressed.
 * Controls animation in the correct direction
 */
public class PlayerController : MonoBehaviour {

  public DataScript data;

  private Animator playerAnimator; //the animator component attached to the player sprite
  Vector3 move; //The direction the player will move
  public float speed = 1.0f; //the speed of the player

	// Use this for initialization
	void Start () {
  
    data = GameObject.Find ("Data").GetComponent<DataScript>();
	
	  playerAnimator = GetComponent<Animator>(); //sets to the proper animator

  
	}
  
	
	// Update is called once per frame
	void Update () {
	
	  // Variables to handle which direction the player will move
	  bool north = false, northeast = false, east = false, southeast = false, south = false, 
	    southwest = false, west = false, northwest = false, still = true;
	
    PlayerDataScript playerData = data.playerData;
  
    /* sets the direction booleans for clarity */
    if (playerData.GetUserControl () == true) {
      if (Input.GetKey("w") && Input.GetKey ("a"))
  	    northwest = true;
      
      else if (Input.GetKey ("w") && Input.GetKey ("d"))
        northeast = true;
  	  
      else if (Input.GetKey ("d") && Input.GetKey ("s"))
        southeast = true;
  	  
    	else if (Input.GetKey ("s") && Input.GetKey ("a"))
    	  northwest = true;
    	  
    	else if (Input.GetKey ("w") && !Input.GetKey ("s"))
    	  north = true;
    	  
    	else if (Input.GetKey ("d"))
    	  east = true;
    	  
    	else if (Input.GetKey("s"))
    	  south = true;
    	  
    	else if (Input.GetKey ("a") && !Input.GetKey("d"))
    	  west = true;
  	} 
    
  
    /* Sets movement direction and animation behavior based on key press */
    { 
      /* If player animation should move upwards */
    	if (north) {
    	  
         playerAnimator.SetInteger("Direction", 1); //sets animation to backwards
         move = new Vector3(Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0); //sets move direction
         transform.position += move * speed * Time.deltaTime; //actually moves the player
    	  
      }
    	
      /* if player animation should move left */
    	else if (northwest || west || southwest) {
    	  
    	  playerAnimator.SetInteger ("Direction", 4); //sets player animation to move right
    	  move = new Vector3(Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0); //sets move direction
    	  transform.position += move * speed * Time.deltaTime; //moves the player
    	  
    	}
    	  
      /* If player animation should move right */
    	else if (south) {
    	  
    	  playerAnimator.SetInteger ("Direction", 3);
        move = new Vector3(Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;
           
    	}
    	 
      /* If player animation should move left */
    	else if (southeast || east || northeast) {
    	  
    	  playerAnimator.SetInteger("Direction", 2);
        move = new Vector3(Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
    	  transform.position += move * speed * Time.deltaTime;
    	  
      }
      
      /* If player should not move */
      else if (still) {
          
    	  playerAnimator.SetInteger("Direction", 0);

      }   
    }	
  }
}
