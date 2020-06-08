using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeReel : MonoBehaviour
{

	private List<ReelFrame> timeReel;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        timeReel = new List<ReelFrame>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Count: returns the number of saved snapshot frames
    public int Count() {
    	return timeReel.Count;
    }

    // Snapshot: takes a snapshot frame and adds it to the TimeReel
    public void snapshot()
    {
        ReelFrame currentFrame = new ReelFrame(transform.position, transform.rotation, rb2d.velocity, rb2d.angularVelocity, rb2d.inertia);
        timeReel.Add(currentFrame);
    }

    // GetTimeIndex: simple, rounds the realTime to the nearest snapshot index
    // add to interface
    private int getTimeIndex(float realTime) {
        return (int)Mathf.Round(realTime);
    }

    // SetTime: sets this object to exist in the specified time snapshot
    public void setTime(float realTime) {
        int time = getTimeIndex(realTime);

    	ReelFrame chosenFrame = timeReel[time-1];
        // set the physics variables
    	transform.position = chosenFrame.position;
    	transform.rotation = chosenFrame.rotation;
    	rb2d.velocity = chosenFrame.velocity;
    	rb2d.angularVelocity = chosenFrame.angularVelocity;
    	rb2d.inertia = chosenFrame.inertia;
    }

    // ClearFuture: calls SetTime, and then deletes any snapshot frame beyond the current one
    // effectively "clearing" the future 
    public void clearFuture(float realTime) {
        int time = getTimeIndex(realTime);

    	timeReel = timeReel.GetRange(0, time);
    	setTime(time);
    }

    // SetFrozen: freezes or enables physics simulation for this object
    // used to freeze the objects while time is stopped
    public void setFrozen(bool frozen) {
        if (frozen) {
            rb2d.simulated = false;
        } else {
            rb2d.simulated = true;
        }
    }
}
