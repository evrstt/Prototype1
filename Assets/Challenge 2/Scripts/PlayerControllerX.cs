using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public InputAction fireAction;

    private float dogSpawnCooldown = 1.0f;
    private float nextDogSpawnTime = 0.0f;

    void Start()
    {
        fireAction.Enable();
    }

    void Update()
    {
        if (fireAction.triggered && Time.time >= nextDogSpawnTime)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

            nextDogSpawnTime = Time.time + dogSpawnCooldown;
        }
    }
}