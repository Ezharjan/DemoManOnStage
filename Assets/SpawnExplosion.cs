using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExplosion : MonoBehaviour
{
    public Transform spawner = null;
    public GameObject explodPrefab = null;
    public Transform parent = null;


    void Start()
    {
        StartCoroutine(Explod());
    }

    IEnumerator Explod()
    {
        while (true)
        {
            GameObject res = Instantiate(explodPrefab, spawner.position, Quaternion.identity);
            res.transform.SetParent(parent);
            yield return new WaitForSeconds(1f);
            Destroy(res, 0.3f);
        }

    }
}
