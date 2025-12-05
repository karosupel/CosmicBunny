using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public GameObject meteorSpawner;

    // Start is called before the first frame update
    void Start()
    {
        meteorSpawner = GameObject.FindGameObjectWithTag("MeteorSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < meteorSpawner.transform.position.y-20)
        {
            Destroy(gameObject);
        }
    }
}
