using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapBuilder : MonoBehaviour
{
    public List<GameObject> prefabs = new List<GameObject>();

    private void Start()
    {
    }

    public void BuildMap()
    {
        ClearMap();

        int sum = 0;
        List<PrefabChance> prefabChances = prefabs.Select((prefab) => {
            TileScript tileScript = prefab.GetComponent<TileScript>();
            var tp = new PrefabChance {
                prefab = prefab,
                chance = sum + tileScript.chance
            };
            sum += tileScript.chance;
            return tp;
        }).ToList();

        for (int x = 0; x < 5; x++)
        {
            for (int z = 0; z < 5; z++)
            {
                Vector3 pos = new Vector3(transform.position.x + x, 0, transform.position.z + z);

                var rnd = Random.Range(0, sum);

                foreach (var pfc in prefabChances)
                {
                    if (rnd < pfc.chance)
                    {
                        Instantiate(pfc.prefab, pos, Quaternion.identity, transform);
                        break;
                    }
                }

            }
        }

        //    [1]                 [2]                   [3]  
        // 0 ..... 20 ............................ 80 ....... 100

        // [0] 20
        // [1] 60
        // [2] 20

        // [0] 20
        // [1] 80
        // [2] 100

        // rand 0 .. 99
        // 0 .. 19 -> [0]
        // 20 .. 79 -> [1]
        // 80 .. 99 -> [2]

        // [0] 10
        // [1] 10
        // [2] 10

        // [0] 10
        // [1] 20
        // [2] 30

        // rnd : 0 .. 29

        // rand 0 .. 2
        // 0 .. 9  -> [0]
        // 10 .. 19 -> [1]
        // 20 .. 29  -> [2]

    }

    private void ClearMap()
    {
        foreach (Transform child in transform)
        {
            if (Application.isEditor)
                DestroyImmediate(child.gameObject);
            else
                Destroy(child.gameObject);
        }
    }

    public class PrefabChance
    {
        public GameObject prefab;
        public int chance;
    }
}
