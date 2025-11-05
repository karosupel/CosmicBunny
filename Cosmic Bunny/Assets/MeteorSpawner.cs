using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public bool SpawnMeteor = false;
    public float CoolDown = 10;

    public GameObject Meteor;

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
            SpawnMeteor = false;
        }
    }

    public IEnumerator MeteorSpawningTimer(float CoolDown)
    {
        yield return new WaitForSeconds(CoolDown);
        Debug.Log("Spawn Meteor");
        for(int i = 0; i<5; i++)
        {
            Spawn();
            yield return new WaitForSeconds(0.1f);
        }
        SpawnMeteor = true;
    }

    public void Spawn()
    {
        float rand_pos_x = Random.Range(-5f, 5f);
        Debug.Log(rand_pos_x);
        Instantiate(Meteor, new Vector3(rand_pos_x, transform.position.y, 0), Quaternion.identity);
    }
}
