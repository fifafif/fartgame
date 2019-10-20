using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class FartSystem : MonoBehaviour
{
    private List<Fart> farts = new List<Fart>();
    public GameObject fartPrefab;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RemoveFarts();
    }

    public void SpawnFart(GameObject source)
    {
        var fart = Instantiate(fartPrefab);
        fart.transform.position = source.transform.position;
        fart.SetActive(true);

        farts.Add(fart.GetComponent<Fart>());
    }

    void RemoveFarts()
    {
        var fartsToRemove = new List<Fart>();
        
        farts.ForEach(o =>
        {
            if (o.isFinished())
            {
                Destroy(o.gameObject);
                fartsToRemove.Add(o);
            }
        });

        fartsToRemove.ForEach(fart => farts.Remove(fart));
    }
}