using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    public GameObject connectingRoom;
    public GameObject topLeftRoom;
    public GameObject bottomLeftRoom;
    public GameObject topRightRoom;
    public GameObject bottomRightRoom;
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject topWall;
    public GameObject bottomWall;
    public GameObject spawnRoom;

    public int roomCount = 0;
    public int dungeonSize; //how many row/collumn, e.g. 0 sets it to 0x0, 00 rooms.

    public NavMeshSurface surface;

   
    // Start is called before the first frame update
    void Start()
    {

        GenerateLevel();
        surface.BuildNavMesh();

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void GenerateLevel()
    {
        int bounds = ((dungeonSize) * 20) - 20;

        for (int i = -bounds; i < bounds + 40; i += 40)
        {
            for (int j = -bounds; j < bounds + 40; j += 40)
            {
                if (i == bounds & j == bounds)
                {
                    Debug.Log("Top right " + roomCount);
                    GameObject instance = Instantiate(topRightRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                }
                else if (j == -bounds & i == bounds)
                {
                    Debug.Log("Bottom right " + roomCount);
                    GameObject instance = Instantiate(bottomRightRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                }
                else if (i == -bounds & j == -bounds)
                {
                    Debug.Log("Bottom Left " + roomCount);
                    GameObject instance = Instantiate(bottomLeftRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                }
                else if (i == -bounds & j == bounds)
                {
                    Debug.Log("Top Left " + roomCount);
                    GameObject instance = Instantiate(topLeftRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                }
                else if (i == -bounds)
                {
                    GameObject instance = Instantiate(leftWall, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                }
                else if (i == bounds)
                {
                    GameObject instance = Instantiate(rightWall, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                }
                else if (j == -bounds)
                {
                    GameObject instance = Instantiate(bottomWall, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                }
                else if (j == bounds)
                {
                    GameObject instance = Instantiate(topWall, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                }
                else if (j == 0 & i == 0)
                {
                    GameObject instance = Instantiate(spawnRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                }
                else
                {
                    GameObject instance = Instantiate(connectingRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                }

                roomCount++;
            }
        }
    }
}
