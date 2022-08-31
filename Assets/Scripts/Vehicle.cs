using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public Transform[] wayPointList;

     public int currentWayPoint;
     Transform targetWayPoint;

     public float speed = 4f;

     // Update is called once per frame
     private void Update ()
     {
         // check if we have somewere to walk
         if (currentWayPoint >= wayPointList.Length) return;

         if(targetWayPoint == null)
             targetWayPoint = wayPointList[currentWayPoint];
         Walk();
     }

     private void Walk(){
         // rotate towards the target
         transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed*Time.deltaTime, 0.0f);

         // move towards the target
         transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position,   speed*Time.deltaTime);

         if(transform.position == targetWayPoint.position)
         {
             currentWayPoint ++ ;
             targetWayPoint = wayPointList[currentWayPoint];
         }
     }
}
