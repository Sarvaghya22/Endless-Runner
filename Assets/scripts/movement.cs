using System.Collections;
using System.Collections.Generic;
using static UnityEngine.GraphicsBuffer;
using UnityEngine;

public class movement : MonoBehaviour

{
    public float forceMag;
    
    [SerializeField] private Rigidbody rb;



    [SerializeField] GameObject Lane1Cube;
    [SerializeField] GameObject Lane2Cube;
    [SerializeField] GameObject Lane3Cube;

    private Vector3[] lanepos;
    // Start is called before the first frame update

    int currentLaneIndex ;
    int targetIndex;
    void Start()
    {
        Debug.Log("Start");
        lanepos = new Vector3[3];

        currentLaneIndex = 1;
        targetIndex = 1;

        lanepos[0] = Lane1Cube.transform.position;
        lanepos[1] = Lane2Cube.transform.position;
        lanepos[2] = Lane3Cube.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * forceMag);
            
        }
            
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentLaneIndex != 0)
            {
                targetIndex = currentLaneIndex - 1;
            }
            currentLaneIndex = targetIndex;

            Debug.Log(lanepos[targetIndex]);

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentLaneIndex != 2)
            {
                targetIndex = currentLaneIndex + 1;
            }
            currentLaneIndex = targetIndex;

            Debug.Log(lanepos[targetIndex]);
        }

        var step = 50f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, lanepos[targetIndex], step);
    
}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag== "Sphere")
            {
                Destroy(collision.gameObject);

            }
    }
}
