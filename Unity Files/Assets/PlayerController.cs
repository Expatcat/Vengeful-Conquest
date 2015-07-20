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
	
	  if (Input.GetKey("w")) {
	  
	    playerAnimator.SetInteger("Direction", 1);
	    move = new Vector3(Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
	    transform.position += move * speed * Time.deltaTime;

	  
	  }
	  
	  else if (Input.GetKey ("a")) {
	  
	    playerAnimator.SetInteger ("Direction", 4);
		move = new Vector3(Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		transform.position += move * speed * Time.deltaTime;
	  
	  }
	  
	  else if (Input.GetKey ("s")) {
	  
	    playerAnimator.SetInteger ("Direction", 3);
		move = new Vector3(Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		transform.position += move * speed * Time.deltaTime;
	  
	  }
	  
	  else if (Input.GetKey ("d")) {
	  
	    playerAnimator.SetInteger("Direction", 2);
		move = new Vector3(Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		transform.position += move * speed * Time.deltaTime;
	  
	  }
	  
	  else {
	    playerAnimator.SetInteger("Direction", 0);
	  }
	
	}
}
