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
        transform.position = Vector3.Lerp(transform.position,marble.transform.position,0.5f);
    }
    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,1f);
    }
}
