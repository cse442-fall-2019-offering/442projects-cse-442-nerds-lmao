using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0; //which wavepoint the enemy is pursuing

    void Start(){
    	target = WaypointsScript.points[0];
    }

    void Update(){
    	Vector3 dir =  target.position - transform.position; //if one wavepoint has been reached, has to jump to the next wavepoint
    	transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

    	if(Vector3.Distance(transform.position, target.position) <= 0.2f){
    		GetNextWaypoint();
    	}
    }

    void GetNextWaypoint(){
    	if(wavepointIndex >= WaypointsScript.points.Length - 1){
    		Destroy(gameObject);
    		return;
    	}
    	wavepointIndex++;
    	target = WaypointsScript.points[wavepointIndex];
    }
}
