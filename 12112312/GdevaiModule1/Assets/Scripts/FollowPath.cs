using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    Transform Goal;
    float speed = 5.0f;
    float accuracy = 1.0f;
    float rotspeed = 2.0f;
    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWaypointIndex = 0;
    Graph graph;
    // Start is called before the first frame update
    void Start()
    {
        wps=wpManager.GetComponent<WaypointManager>().waypoints;
        graph=wpManager.GetComponent<WaypointManager>().graph;
        currentNode = wps[0];
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //if close enough to current watpoint move to next waypoint
        if(graph.getPathLength()==0||currentWaypointIndex==graph.getPathLength())
        {
            return;
        }
        currentNode = graph.getPathPoint(currentWaypointIndex);

        if (Vector3.Distance(graph.getPathPoint(currentWaypointIndex).transform.position, transform.position) < accuracy)
        {
            currentWaypointIndex++;
        }
        // if not at the end of tha path
        if(currentWaypointIndex<graph.getPathLength())
        {
            Goal = graph.getPathPoint(currentWaypointIndex).transform;
            Vector3 lookAtGoal = new Vector3(Goal.position.x,transform.position.y,Goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;
            this.transform.rotation= Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(direction),Time.deltaTime* rotspeed);
            this.transform.Translate(0,0,speed * Time.deltaTime);
        }

    }

    public void GoToHelipad()
    {
        graph.AStar(currentNode, wps[2]);
        currentWaypointIndex = 0;
    }
    public void GoToRuins()
    {
        graph.AStar(currentNode, wps[6]);
        currentWaypointIndex = 0;
    }
    public void OilPump()
    {
        graph.AStar(currentNode, wps[14]);
        currentWaypointIndex = 0;
    }
    public void Factory()
    {
        graph.AStar(currentNode, wps[11]);
        currentWaypointIndex = 0;
    }
    public void TwinMount()
    {
        graph.AStar(currentNode, wps[1]);
        currentWaypointIndex = 0;
    }
    public void Barracks()
    {
        graph.AStar(currentNode, wps[17]);
        currentWaypointIndex = 0;
    }
    public void CommandCenter()
    {
        graph.AStar(currentNode, wps[16]);
        currentWaypointIndex = 0;
    }
    public void Tankers()
    {
        graph.AStar(currentNode, wps[9]);
        currentWaypointIndex = 0;
    }
    public void Radar()
    {
        graph.AStar(currentNode, wps[19]);
        currentWaypointIndex = 0;
    }
    public void CommandPost()
    {
        graph.AStar(currentNode, wps[5]);
        currentWaypointIndex = 0;
    }
    public void MiddleMap()
    {
        graph.AStar(currentNode, wps[13]);
        currentWaypointIndex = 0;
    }
  

}
