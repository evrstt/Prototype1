using UnityEngine;

public class Follow_Player : MonoBehaviour
{
    public GameObject player;
    public float OffsetX; 
    public float OffsetY;
    public float OffsetZ;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(2, 8, -16);
    }
}
