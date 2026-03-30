using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public bool SpawnMeteor = false;
    public float CoolDown = 10;

    public HelperScript helper;

    public GameObject Meteor;

    // Start is called before the first frame update
    void Start()
    {
        helper = GameObject.FindGameObjectWithTag("Helper").GetComponent<HelperScript>();
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
        helper.StartCoroutine(helper.ShowMeteorWarning(helper.repetitions));
        yield return new WaitForSeconds(3f);
        for(int i = 0; i<3; i++)
        {
            Spawn();
            yield return new WaitForSeconds(0.1f);
        }
        SpawnMeteor = true;
        helper.MeteorPanel.SetActive(false);
    }

    public void Spawn()
    {
        float rand_pos_x = Random.Range(-5f, 5f);
        //Debug.Log(rand_pos_x);
        Instantiate(Meteor, new Vector3(rand_pos_x, transform.position.y, -1), Quaternion.identity);
        
    }
}
