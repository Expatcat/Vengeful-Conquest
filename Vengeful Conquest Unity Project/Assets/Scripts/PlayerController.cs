using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

  private Animator playerAnimator;
  Vector3 move;
  public float speed = 1.0f;

	// Use this for initialization
	void Start () {
	
	  playerAnimator = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	bool north = false, northeast = false, east = false, southeast = false, south = false, 
	  southwest = false, west = false, northwest = false, still = true;
	
	//sets the direction booleans for clarity
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
	  
			
	  if (north) {
	  
	    playerAnimator.SetInteger("Direction", 1);
	    move = new Vector3(Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
	    transform.position += move * speed * Time.deltaTime;
	  
	  }
	  
	  else if (northwest || west || southwest) {
	  
	    playerAnimator.SetInteger ("Direction", 4);
		move = new Vector3(Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		transform.position += move * speed * Time.deltaTime;
	  
	  }
	  
	  else if (south) {
	  
	    playerAnimator.SetInteger ("Direction", 3);
		move = new Vector3(Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		transform.position += move * speed * Time.deltaTime;
	  
	  }
	  
	  else if (southeast || east || northeast) {
	  
	    playerAnimator.SetInteger("Direction", 2);
		move = new Vector3(Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		transform.position += move * speed * Time.deltaTime;
	  
	  }
	  
      else if (still) {
      
	    playerAnimator.SetInteger("Direction", 0);
	    
	  }
	
	}
}
