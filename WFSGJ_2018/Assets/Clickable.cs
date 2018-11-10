using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour {
    public int playerDistance = 100;

    public GameObject bound;
    
    void Start () {
        Transform e = Instantiate(bound, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation).transform;
        e.localScale = new Vector3(1, 1, playerDistance);
        e.SetParent(this.transform);
        e.name = "collider";
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

}
