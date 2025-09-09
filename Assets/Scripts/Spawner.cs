using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject bomb;

    private float lastTime = 0, time;
    [SerializeField] private GameObject bun, steak, cheese;
    private List<GameObject> preFabs;
    private void Awake()
    {
        time = Random.Range(1, 6);
        
        preFabs = new List<GameObject>();
        
        preFabs.Add(bun);
        preFabs.Add(cheese);
        preFabs.Add(steak);
        preFabs.Add(bomb);
    }

    // Update is called once per frame
    void Update()
    {
        Generate();
    }

    void Generate()
    {
        if (lastTime + time < Time.time)
        {
            int preFabsRandom = Random.Range(0, preFabs.Count);
            GameObject b = Instantiate(preFabs[preFabsRandom], transform.position, Quaternion.identity);
            lastTime = Time.time;
            time = Random.Range(1, 3);
            Destroy(b, 12);
        }
        
    }
}
