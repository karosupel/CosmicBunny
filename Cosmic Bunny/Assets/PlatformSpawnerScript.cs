using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject new_platform;
    public GameObject platform_prefab;

    public Camera cam;
    
    void Start()
    {
        //cam = GetComponent<Camera>();

        //na start tworze pierwsza platforme (ktora nie moze uderzyc krolika w ³eb) i nadaje jej nazwe new
        new_platform = Instantiate(platform_prefab,new Vector3(Random.Range(Random.Range(-5f,-2f),Random.Range(2f,5f)),-2,0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit2D hit = Physics2D.Raycast(new_platform.transform.position - new Vector3(-1.5f, 0, 0), Vector2.right * 1.5f, 3f);

        //jeœli new.y + 3 jednostki do góry znajduje siê w zasiêgu kamery (bedzie potrzebna na to jakas funkcja jak nic)
        //to ma zostaæ zespawnowany nowy obiekt i teraz to on bedzie new. i tak w nieskoñczonoœæ
        //a ju¿ w algorytmie samej platformy dodamy niszczenie ich, jeœli bêd¹ poza kamer¹. myœlê, ¿e to najbardziej
        //optymalne

        if (platform_prefab != null && new_platform != null)
        {
            if (IsVisibleToCamera(new_platform.transform.position + new Vector3(0, 3, 0)) == true)
            {
                float randomX = Random.Range(-5f, 5f);
                new_platform = Instantiate(platform_prefab, new Vector3(randomX, new_platform.transform.position.y + 3, 0), Quaternion.identity);
            }
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
