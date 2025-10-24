using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsVisibleToCamera(transform.position) == false)
        {
            Destroy(gameObject);
        }
    }

    public bool IsVisibleToCamera(Vector3 target)
    {
        Vector3 target_pos = cam.WorldToViewportPoint(target);
        if (target_pos.y < 0 || target_pos.y > 1)
        {
            return false; //jest poza kamer¹
        }
        else
        {
            return true; //jest widoczny dla kamery
        }
    }
}
