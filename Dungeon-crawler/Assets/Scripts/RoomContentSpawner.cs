using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomContentSpawner : MonoBehaviour
{
    public string searchTag;
    public List<GameObject> spawnList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if (searchTag != null)
        {
            FindObjectwithTag(searchTag);
        }
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void FindObjectwithTag(string _tag)
    {
        spawnList.Clear();
        Transform parent = transform;
        GetChildObject(parent, _tag);
    }

    public void GetChildObject(Transform parent, string _tag)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (child.tag == _tag)
            {
                spawnList.Add(child.gameObject);
            }
            if (child.childCount > 0)
            {
                GetChildObject(child, _tag);
            }
        }
    }
}
