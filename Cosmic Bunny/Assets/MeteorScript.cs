using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public GameObject meteorSpawner;
    public LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        meteorSpawner = GameObject.FindGameObjectWithTag("MeteorSpawner");
        lineRenderer.SetPosition(0, new Vector3(transform.position.x, transform.position.y, -1));
        lineRenderer.SetPosition(1, new Vector3(transform.position.x, transform.position.y - 20, -1));
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
