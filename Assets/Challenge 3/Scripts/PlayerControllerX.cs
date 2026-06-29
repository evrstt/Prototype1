using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce = 5f; // added a value to this variable was sending our balloon into the stratosphere, could use some addtional tuning, but works for now.
    public float upwardForce = 5f;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public InputAction floatAction;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    private float upperBound = 16.0f;


    
    void Start()
    {
        // was missing our getcomponent<rigidbody>

        Physics.gravity *= gravityModifier;
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        floatAction.Enable();

        // removed the magic number here and added upwardForce variable
        playerRb.AddForce(Vector3.up * upwardForce, ForceMode.Impulse); 

    }

    
    void Update()
    {
        bool isLowEnough = transform.position.y < upperBound;
        
        if (floatAction.IsPressed() && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        
        else if (other.gameObject.CompareTag("Money"))
        {
            // added in this transform position to move the fireworks particle to the player/money instead of just blowing up where they were

            fireworksParticle.transform.position = transform.position;
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}
