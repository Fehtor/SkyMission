using System.Collections.Generic;
using UnityEngine;

public enum RoomWallType
{
    Door,
    Wall,
    None
}

public class RoomWalls {

    public RoomWallType topWall;
    public RoomWallType bottomWall;
    public RoomWallType rightWall;
    public RoomWallType leftWall;

    public RoomWalls()
    {
        topWall = RoomWallType.None;
        bottomWall = RoomWallType.None;
        rightWall = RoomWallType.None;
        leftWall = RoomWallType.None;
    }

    public RoomWalls (bool isWalls)
    {
        if (isWalls)
        {
            topWall = RoomWallType.Wall;
            bottomWall = RoomWallType.Wall;
            rightWall = RoomWallType.Wall;
            leftWall = RoomWallType.Wall;
        }
        else
        {
            topWall = RoomWallType.Door;
            bottomWall = RoomWallType.Door;
            rightWall = RoomWallType.Door;
            leftWall = RoomWallType.Door;
        }
    }

}

public class Room : MonoBehaviour
{

    private int depth;
    private Collider2D canSpawn;

    public RoomWalls roomWalls;
    private LevelController controller;

    public Room()
    {
        roomWalls = new RoomWalls();
    }

    private void GenerateWalls()
    {
        if (depth == controller.GetDepth())
        {
            SetLastRoomWalls();
        }

        if (roomWalls.topWall == RoomWallType.None)
        {
            canSpawn = Physics2D.OverlapCircle(transform.position + new Vector3(0, 20, 0), 2);
            if (canSpawn)
            {
                RoomWalls closestRoomWalls = canSpawn.gameObject.GetComponent<Room>().roomWalls;
                if(closestRoomWalls.bottomWall == RoomWallType.Door)
                {
                    roomWalls.topWall = RoomWallType.Door;
                }
                else
                {
                    roomWalls.topWall = RoomWallType.Wall;
                }
            }
            else
            {
                roomWalls.topWall = GenerateWall();
            }
            
        }
        
        if(roomWalls.bottomWall == RoomWallType.None)
        {
            canSpawn = Physics2D.OverlapCircle(transform.position + new Vector3(0, -20, 0), 2);
            if (canSpawn)
            {
                RoomWalls closestRoomWalls = canSpawn.gameObject.GetComponent<Room>().roomWalls;
                if (closestRoomWalls.topWall == RoomWallType.Door)
                {
                    roomWalls.bottomWall = RoomWallType.Door;
                }
                else
                {
                    roomWalls.bottomWall = RoomWallType.Wall;
                }
            }
            else
            {
                roomWalls.bottomWall = GenerateWall();
            }
            
        }
        
        if(roomWalls.rightWall == RoomWallType.None)
        {
            canSpawn = Physics2D.OverlapCircle(transform.position + new Vector3(0, 36, 0), 2);
            if (canSpawn)
            {
                RoomWalls closestRoomWalls = canSpawn.gameObject.GetComponent<Room>().roomWalls;
                if (closestRoomWalls.leftWall == RoomWallType.Door)
                {
                    roomWalls.rightWall = RoomWallType.Door;
                }
                else
                {
                    roomWalls.rightWall = RoomWallType.Wall;
                }
            }
            else
            {
                roomWalls.rightWall = GenerateWall();
            }
            
        }
        
        if(roomWalls.leftWall == RoomWallType.None)
        {
            canSpawn = Physics2D.OverlapCircle(transform.position + new Vector3(0, -36, 0), 2);
            if (canSpawn)
            {
                RoomWalls closestRoomWalls = canSpawn.gameObject.GetComponent<Room>().roomWalls;
                if (closestRoomWalls.rightWall == RoomWallType.Door)
                {
                    roomWalls.leftWall = RoomWallType.Door;
                }
                else
                {
                    roomWalls.leftWall = RoomWallType.Wall;
                }
            }
            else
            {
                roomWalls.leftWall = GenerateWall();
            }

            
        }

        Debug.Log($"{roomWalls.topWall} {roomWalls.rightWall} {roomWalls.bottomWall} {roomWalls.leftWall}");
        
        if(controller.GetDepth() > depth)
        {
            SpawnNearRooms();
        }
        
        SpawnWall();
    }

    public void SetLastRoomWalls()
    {
        if(roomWalls.topWall == RoomWallType.None) roomWalls.topWall = RoomWallType.Wall;
                   
        if(roomWalls.bottomWall == RoomWallType.None) roomWalls.bottomWall = RoomWallType.Wall;

        if (roomWalls.rightWall == RoomWallType.None) roomWalls.rightWall = RoomWallType.Wall;

        if (roomWalls.leftWall == RoomWallType.None) roomWalls.leftWall = RoomWallType.Wall;
    }

    private RoomWallType GenerateWall()
    {
        int number = Random.Range(0, 2);

        return number == 0 ? RoomWallType.Wall : RoomWallType.Door;
    }

    private void SpawnWall()
    {
        
        Vector3 horizontalRightGap =  new Vector3(14.6f, 0.004f, 0); // правая дверь
        Vector3 horizontalLeftGap =  new Vector3(14.65f, 0.004f, 0); // левая дверь
        Vector3 horizontalRightWallGap =  new Vector3(13.18f, 0.4f, 0); // правая стена
        Vector3 horizontalLeftWallGap =  new Vector3(13.1f, 0.6f, 0); // левая стена
        Vector3 verticalBottomGap =  new Vector3(-0.15f, 5.51f, 0f); // нижняя стена и дверь
        Vector3 verticalUpGap =  new Vector3(-0.19f, 7.25f, 0f); // верхняя стена и дверь
        

        Dictionary<string, GameObject> dict = controller.GetWalls();


        if(roomWalls.topWall == RoomWallType.Door) { Instantiate(dict["topDoor"], transform.position + verticalUpGap, Quaternion.identity); };
        if(roomWalls.bottomWall == RoomWallType.Door) { Instantiate(dict["bottomDoor"], transform.position - verticalBottomGap, Quaternion.identity); };
        if(roomWalls.rightWall == RoomWallType.Door) { Instantiate(dict["rightDoor"], transform.position + horizontalRightGap, Quaternion.identity); };
        if(roomWalls.leftWall == RoomWallType.Door) { Instantiate(dict["leftDoor"], transform.position - horizontalLeftGap, Quaternion.identity); };


        if (roomWalls.topWall == RoomWallType.Wall) { Instantiate(dict["horizontalWall"], transform.position + verticalUpGap, Quaternion.identity); };
        if (roomWalls.bottomWall == RoomWallType.Wall) { Instantiate(dict["horizontalWall"], transform.position - verticalBottomGap, Quaternion.identity);  };
        if (roomWalls.rightWall == RoomWallType.Wall) { Instantiate(dict["verticalWall"], transform.position + horizontalRightWallGap, Quaternion.identity); };
        if (roomWalls.leftWall == RoomWallType.Wall) { Instantiate(dict["verticalWall"], transform.position - horizontalLeftWallGap, Quaternion.identity); };

        Instantiate(controller.GetRandomColumn(), transform.position, Quaternion.identity);
    } 
    
    
    public void SpawnNearRooms()
    {

        if (roomWalls.topWall == RoomWallType.Door)
        {
            canSpawn = Physics2D.OverlapCircle(transform.position + new Vector3(0, 20, 0), 2);
            Debug.Log(canSpawn + "It's me mario");
            if (canSpawn == null)
            {
                GameObject newFloor = Instantiate(controller.getFloor(), transform.position + new Vector3(0, 20, 0), Quaternion.identity);
                Room newRoom = newFloor.AddComponent<Room>();

                RoomWalls walls = new RoomWalls();
               
                walls.bottomWall = RoomWallType.Door;
                

                newRoom.SetRoomWalls(walls);
                newRoom.SetDepth(depth + 1);
            }
           
            
        }
         if(roomWalls.bottomWall == RoomWallType.Door)
        {
            canSpawn = Physics2D.OverlapCircle(transform.position + new Vector3(0, -20, 0), 2);
            if (canSpawn == null)
            {
                GameObject newFloor = Instantiate(controller.getFloor(), transform.position + new Vector3(0, -20, 0), Quaternion.identity);
                Room newRoom = newFloor.AddComponent<Room>();

                RoomWalls walls = new RoomWalls();
                walls.topWall = RoomWallType.Door;
               
                newRoom.SetRoomWalls(walls);
                newRoom.SetDepth(depth + 1);
            }
            
        }
         if(roomWalls.rightWall == RoomWallType.Door)
        {
            canSpawn = Physics2D.OverlapCircle(transform.position + new Vector3(36, 0, 0), 2);
            if (canSpawn == null)
            {

                GameObject newFloor = Instantiate(controller.getFloor(), transform.position + new Vector3(36, 0, 0), Quaternion.identity);
                Room newRoom = newFloor.AddComponent<Room>();

                RoomWalls walls = new RoomWalls();
               
                walls.leftWall = RoomWallType.Door;

                newRoom.SetRoomWalls(walls);
                newRoom.SetDepth(depth + 1);
            }

        }
         if(roomWalls.leftWall == RoomWallType.Door)
        {
            canSpawn = Physics2D.OverlapCircle(transform.position + new Vector3(-36, 0, 0), 2);
            if (canSpawn == null)
            {
                GameObject newFloor = Instantiate(controller.getFloor(), transform.position + new Vector3(-36, 0, 0), Quaternion.identity);
                Room newRoom = newFloor.AddComponent<Room>();

                RoomWalls walls = new RoomWalls();
               
                walls.rightWall = RoomWallType.Door;
                

                newRoom.SetRoomWalls(walls);
                newRoom.SetDepth(depth + 1);
            }
           
        }
    }

    public void SetRoomWalls(RoomWalls inp_RoomWalls)
    {
        Debug.Log("SetRoomWalsing");
        roomWalls = inp_RoomWalls;
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
        GenerateWalls();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDepth(int value)
    {
        depth = value;
    }
   
}
    

   

