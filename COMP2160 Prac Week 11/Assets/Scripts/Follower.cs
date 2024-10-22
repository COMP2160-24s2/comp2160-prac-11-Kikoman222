using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    GameObject marble;
    // Start is called before the first frame update
    void Start()
    {
        marble = GameObject.Find("Marble");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 spot = new Vector3(marble.transform.position.x,0.5f,marble.transform.position.z);
        transform.position = Vector3.Lerp(transform.position,spot,0.5f);
    }
    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,1f);
    }
}
