using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject new_platform;
    public GameObject platform_prefab;
    
    void Start()
    {
        //na start tworze pierwsza platforme (ktora nie moze uderzyc krolika w �eb) i nadaje jej nazwe new
        new_platform = Instantiate(platform_prefab,new Vector3(Random.Range(-5f, -2f),-2,0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //je�li new.y + 3 jednostki do g�ry znajduje si� w zasi�gu kamery (bedzie potrzebna na to jakas funkcja jak nic)
        //to ma zosta� zespawnowany nowy obiekt i teraz to on bedzie new. i tak w niesko�czono��
        //a ju� w algorytmie samej platformy dodamy niszczenie ich, je�li b�d� poza kamer�. my�l�, �e to najbardziej optymalne
    }
}
