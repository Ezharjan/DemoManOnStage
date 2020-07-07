using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    public GameObject bullet = null;
    public Transform spawner = null;
    public Transform parent = null;


    void Start()
    {
        StartCoroutine(ShotTheBullet());
    }

    void Update()
    {

    }

    IEnumerator ShotTheBullet()
    {
        while (true)
        {
            GameObject mBullet = (GameObject)Instantiate(bullet, spawner.position, Quaternion.identity);
            mBullet.transform.SetParent(parent);
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            mBullet.GetComponent<Rigidbody>().AddForce(fwd * 500);
            yield return new WaitForSeconds(0.5f);
            Destroy(mBullet, 1);
        }
    }
}


