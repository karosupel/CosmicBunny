using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public bool SpawnMeteor = true;
    public float CoolDown = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SpawnMeteor == true)
        {
            StartCoroutine(MeteorSpawningTimer(CoolDown));
        }
    }

    public IEnumerator MeteorSpawningTimer(float CoolDown)
    {
        Debug.Log("Spawn Meteor");
        SpawnMeteor = false;
        yield return new WaitForSeconds(CoolDown);
        SpawnMeteor = true;
    }
}
