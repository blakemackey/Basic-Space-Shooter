
using UnityEngine;

public class Player : MonoBehaviour
{
    //public fields are editable in unity ui
    public float thrustSpeed = 1f;
    public float rotationSpeed = 1;
    public bool isThrusting { get; private set; }

    private float turnDirection;

    private Rigidbody2D rb;

    private void Awake() {
        //initilization type work, acts as a constructor method
        rb = GetComponent<Rigidbody2D>();
    }

    //Check for input for player movement
    private void Update() {
        //update method called by unity every frame the game is running
        //checks for movement by seeing if W or Up arrow is continously pressed
        isThrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

         //checks turn direction
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            turnDirection = 1f;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            turnDirection = -1f;
        } else {
            turnDirection = 0;
        }
    }

    //Then, call specific functions based on rigid body results
    private void FixedUpdate() {
        //apply input to translate into player action
        //gets called on a fixed time interval rather than every frame, keeps phsyics conistent rather than dealing with individual framerate
        if(isThrusting) {
            //moves object using unity physics engine
            rb.AddForce(transform.up * thrustSpeed);
        }

        if (turnDirection != 0f) {
            rb.AddTorque(turnDirection * rotationSpeed);
        }
    }
}
