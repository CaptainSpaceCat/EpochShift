using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private List<TimeReel> loggers;
    public int currentTime = 0;
    void Start()
    {
    	loggers = new List<TimeReel>();
     	foreach (GameObject go in GameObject.FindGameObjectsWithTag("Temporal")) {
     		loggers.Add(go.GetComponent<TimeReel>());
     	}
    }

    private bool stopped = false;
    private int maxTime = 0;
    void FixedUpdate()
    {
    	if (!stopped) {
    		currentTime += 1;
	    	foreach (TimeReel log in loggers) {
	        	log.snapshot();
	        }
	    } else {
	    	//control time
        	if(Input.GetKey(KeyCode.Z)) {
        		//Debug.Log("Reverse");
        		currentTime = Mathf.Clamp(currentTime - 3, 1, maxTime);
	        } else if (Input.GetKey(KeyCode.X)) {
	        	//Debug.Log("Forward");
	        	currentTime = Mathf.Clamp(currentTime + 3, 1, maxTime);
	        }

	        //set all timelogging objects to the correct time
	    	foreach (TimeReel log in loggers) {
        		log.setTime(currentTime);
        	}
	    }
    }

    void Update() {
    	if(Input.GetKeyDown(KeyCode.C)) {
        	stopped = !stopped;
        	if (stopped) {
        		//we just stopped time!!! woundlt wanna try to go past the point where we stopped.
        		maxTime = currentTime;
        	} else {
        		//we just restarted time! let's delete all of the future data we have so the future is bright and rich with new possibilities
        		foreach (TimeReel log in loggers) {
	        		log.clearFuture(currentTime);
	        	}
        	}        	
        	Debug.Log("Time toggled");
        }
    }
}
