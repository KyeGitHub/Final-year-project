using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] doors;
    [SerializeField]
    GameObject boss;
    [SerializeField]
    GameObject spawn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == ("Player"))
        {
            GameObject instance = Instantiate(boss, spawn.transform.position + new Vector3(0, 0.01f, 0), Quaternion.identity) as GameObject;
            instance.transform.parent = gameObject.transform;
            foreach (GameObject door in doors)
            {
                door.SetActive(true);
            }
        }
    }
}
