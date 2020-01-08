using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoomSpawner : MonoBehaviour
{
    // Could probably put this in an array
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
    public GameObject bossRoom;

    public int roomCount = 0;
    public int dungeonSize; // how many rows/collumns, e.g. 10 sets it to 10 by 10, 100 rooms.

    // a count of each type of room as we need to make sure there is a variety to make sure the floor is completable
    public int combatRooms;
    public int resourceRooms;
    public int demibossRooms;
    public bool spawnRoomSpawned;
    public bool bossRoomSpawned;

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

        int bossRoomSide = Random.Range(1, 4);

        Debug.Log("Side: " + bossRoomSide);
        for (int i = -bounds; i < bounds + 40; i += 40)
        {
            for (int j = -bounds; j < bounds + 40; j += 40)
            {
                if (i == bounds & j == bounds)
                {
                    // Top right corner room
                    Debug.Log("Top right " + roomCount);
                    GameObject instance = Instantiate(topRightRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    
                }
                else if (j == -bounds & i == bounds)
                {
                    // Bottom right corner room
                    Debug.Log("Bottom right " + roomCount);
                    GameObject instance = Instantiate(bottomRightRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                }
                else if (i == -bounds & j == -bounds)
                {
                    // Bottom left corner room
                    Debug.Log("Bottom Left " + roomCount);
                    GameObject instance = Instantiate(bottomLeftRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                }
                else if (i == -bounds & j == bounds)
                {
                    // Top left corner room
                    Debug.Log("Top Left " + roomCount);
                    GameObject instance = Instantiate(topLeftRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                }
                else if (i == -bounds)
                {
                    // Edge room
                    GameObject instance = Instantiate(leftWall, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                }
                else if (i == bounds)
                {
                    // Edge room
                    GameObject instance = Instantiate(rightWall, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                }
                else if (j == -bounds)
                {
                    // Edge room
                    GameObject instance = Instantiate(bottomWall, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                }
                else if (j == bounds)
                {
                    // Edge room
                    GameObject instance = Instantiate(topWall, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                }
                else if (j == 0 & i == 0)
                {
                    // Spawn room
                    GameObject instance = Instantiate(spawnRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    instance.tag = "Spawn Room";
                }
                else if (j==40 & i == 0 & bossRoomSide == 1)
                {
                    Debug.Log("Boss room " + bossRoomSide);
                    GameObject instance = Instantiate(bossRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    instance.tag = "Boss Room";
                }
                else if (j == 0 & i == 40 & bossRoomSide == 2)
                {
                    Debug.Log("Boss room " + bossRoomSide);
                    GameObject instance = Instantiate(bossRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    instance.tag = "Boss Room";
                }
                else if (j == -40 & i == 0 & bossRoomSide == 3)
                {
                    Debug.Log("Boss room " + bossRoomSide);
                    GameObject instance = Instantiate(bossRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    instance.tag = "Boss Room";
                }
                else if (j == 0 & i == -40 & bossRoomSide == 4)
                {
                    Debug.Log("Boss room " + bossRoomSide);
                    GameObject instance = Instantiate(bossRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    instance.tag = "Boss Room";
                }
                else
                {
                    // Regular rooms
                    GameObject instance = Instantiate(connectingRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                }

                roomCount++;
            }
        }
    }
}