using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomContentSpawner : MonoBehaviour
{
    public string searchTag;
    public string roomTag;
    public List<GameObject> spawnList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        roomTag = transform.tag; // grab the room tag which was assigned by the spawner, use this to determine what we're putting in the room

        // checks all children for specified tag as unity searches whole scene instead of just children
        if (searchTag != null)
        {
            FindObjectwithTag(searchTag);
        }
       
        if (roomTag == "Boss Room")
        {

        }

        else if (roomTag == "Combat Room")
        {

        }

        else if (roomTag == "Resource Room")
        {

        }

        else if (roomTag == "Spawn Room")
        {

        }

        else if (roomTag == "Demi Boss Room")
        {

        }

        else if (roomTag == "Mixed Room")
        {

        }

        else
        {
            Debug.Log("Something messed up with your room tag for content spawning");
        }

    }

    // Update is called once per frame
    void Update()
    {


    }

    #region Spawning
    // Depending on room tag these will be called in the start() function
    void CombatContentSpawner()
    {
        
        

    }
    void MixedContentSpawner()
    {



    }

    void DemiContentSpawner()
    {



    }

    void ResourceContentSpawner()
    {



    }

    void BossContentSpawner()
    {
        
        

    }

    void SpawnContentSpawner()
    {



    }

    #endregion

    #region Tag finder

    public void FindObjectwithTag(string _tag)
    {
        // clears list, sets what object we want to search then calls the function to check for tags
        spawnList.Clear();
        Transform parent = transform;
        GetChildObject(parent, _tag);
    }

    public void GetChildObject(Transform parent, string _tag)
    {
        // loops through all the child objects of the parent to find any with the tag we're looking for
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
    #endregion

}
