using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    private static int positiveX = 1, negativeX = -1;
    private static int positiveY = -1, negativeY = 1;
	
	private Animator enemyAnimator;
	Vector3 move;
	public float speed = 1.0f;
	
	Vector2 componentDistance;
	
	// Use this for initialization
	void Start () {
		
		enemyAnimator = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	
	    float xDirection = 0, yDirection = 0;
		
		bool north = false, northeast = false, east = false, southeast = false, south = false, 
		southwest = false, west = false, northwest = false, still = true;
		
		
		if (componentDistance.x > 0 && componentDistance.y > 0) {
		  southeast = true;
		  xDirection = positiveX;
		  yDirection = negativeY;
		}
		
		else if (componentDistance.x > 0 && componentDistance.y == 0) {
		  east = true;
		  xDirection = positiveX;
		  yDirection = 0;
		}		
		
		else if (componentDistance.x > 0 && componentDistance.y < 0) {
		 northeast = true;
		 xDirection = positiveX;
		 yDirection = positiveY;
		 
		}
		
		else if (componentDistance.x < 0 && componentDistance.y > 0) {
		  southwest = true;
		  xDirection = negativeX;
		  yDirection = negativeY;
		}
		
		else if (componentDistance.x < 0 && componentDistance.y == 0) {
		  west = true;
		  xDirection = negativeX;
		  yDirection = 0;
		}
		
		else if (componentDistance.x < 0 && componentDistance.y < 0) {
		  northwest = true;
		  xDirection = negativeX;
		  yDirection = positiveY;
		}
		
		else if (componentDistance.x == 0 && componentDistance.y > 0) {
		  south = true;
		  xDirection = 0;
		  yDirection = negativeY;
		}
		
		else if (componentDistance.x == 0 && componentDistance.y == 0) {
		  still = true;
		  xDirection = 0;
		  yDirection = 0;
		  
		}
		
		else if (componentDistance.x == 0 && componentDistance.y < 0) {
		  north = true;
		  xDirection = 0;
		  yDirection = positiveY;
		  
		}
		
		
		if (north) {
			
			enemyAnimator.SetInteger("Direction", 1);
			move = new Vector3(xDirection, yDirection, 0);
			transform.position += move * speed * Time.deltaTime;
			
		}
		
		else if (northwest || west || southwest) {
			
			enemyAnimator.SetInteger ("Direction", 4);
			move = new Vector3(xDirection, yDirection, 0);
			transform.position += move * speed * Time.deltaTime;
			
		}
		
		else if (south) {
			
			enemyAnimator.SetInteger ("Direction", 3);
			move = new Vector3(xDirection, yDirection, 0);
			transform.position += move * speed * Time.deltaTime;
			
		}
		
		else if (southeast || east || northeast) {
			
			enemyAnimator.SetInteger("Direction", 2);
			move = new Vector3(xDirection, yDirection, 0);
			transform.position += move * speed * Time.deltaTime;
			
		}
		
		else if (still) {
			
			enemyAnimator.SetInteger("Direction", 0);
			
		}
		
	}
	
	public void setDirection(Vector2 componentVector) {
	
	  componentDistance = componentVector;
	
	}
	
}
