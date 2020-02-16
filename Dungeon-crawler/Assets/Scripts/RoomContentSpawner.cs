using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoomContentSpawner : MonoBehaviour
{
    public string searchTag;
    public string roomTag;
    public List<GameObject> spawnList = new List<GameObject>();
    public GameObject water, crystal;
    public int nodeCount = 0;

    // Start is called before the first frame update
    void Start()
    {
       
     #region Content spawning

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
            foreach (GameObject spawn in spawnList)
            {
                ResourceContentSpawner(spawn);
            }
            
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
            Debug.Log("Something messed up with your room tag for content spawning" + gameObject.name);
        }     

        #endregion
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

    void ResourceContentSpawner(GameObject spawn)
    {
        
        int randomNumber = Random.Range(0, 101);
        //Debug.Log(randomNumber +" " + spawn.name);
        if (randomNumber < 30) // spawn water
        {
            Debug.Log(randomNumber + " spawning Water");
            GameObject instance = Instantiate(water, spawn.transform.position + new Vector3(0, 0.01f, 0), Quaternion.identity) as GameObject;
            instance.transform.parent = gameObject.transform;
            nodeCount++;
        }
        else if (randomNumber < 61 && randomNumber > 29) // spawn crystal 
        {
            GameObject instance = Instantiate(crystal, spawn.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity) as GameObject;
            Debug.Log(randomNumber + " spawning Crystal");
            instance.transform.Rotate(new Vector3(-90, 0, 0));
            instance.transform.parent = gameObject.transform;
            nodeCount++;
        }
        else if (randomNumber > 60 && nodeCount > 0) // if there's stuff in room don't have to spawn 
        {
            Debug.Log("Not spawning stuff, number should be above 60: " + randomNumber +" and this above 0: " + nodeCount);
        }
        else // go again
        {
            ResourceContentSpawner(spawn);
        }

        
            

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
