using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelFrame
{
	public Vector3 position;
	public Quaternion rotation;
	public Vector3 velocity;
	public float angularVelocity;
	public float inertia;

    public ReelFrame(Vector2 _position, Quaternion _rotation, Vector2 _velocity, float _angularVelocity, float _inertia) {
    	position = _position;
    	rotation = _rotation;
    	velocity = _velocity;
    	angularVelocity = _angularVelocity;
    	inertia = _inertia;
    }

    public bool isEqual(ReelFrame other) {
    	return position == other.position && 
    		velocity == other.velocity && 
    		rotation == other.rotation && 
    		angularVelocity == other.angularVelocity && 
    		inertia == other.inertia;
    }
}
