using UnityEngine;
using System.Collections;

public class ShipControl : MonoBehaviour {
	public float speed; 
	public float speed_limit; 
	public float turn; 
	public Rigidbody shot; 
	public Transform shot_spawn; 
	public float fire_rate; 
	public int boost; 


	protected float lower_speed_limit; 
	protected float upper_speed_limit; 
	protected bool speedup; 
	protected bool slowdown; 
	protected float speed_delta = 0.5f; 
	protected Renderer[] ts; 
	protected float next_fire; 
	protected float original_turn; 
	protected float fast_turn; 
	protected Renderer this_renderer; 
	protected int current_boost; 
	protected bool boost_lock; 

	// Uses physics 
	public void Start() {
		lower_speed_limit = speed; 
		upper_speed_limit = speed_limit; 
		original_turn = turn*1.0f; 
		fast_turn = turn*1.5f; 
		current_boost = boost; 
		boost_lock = false; 

		Renderer[] renderers = transform.GetChild(0).GetComponentsInChildren<Renderer>(); 
		foreach(Renderer r in renderers) {
			if(r.name=="part_jet_flare") {
				this_renderer = r; 
				break; 
			}
		}
	}

	public void FixedUpdate () {
		Move(); 
	}

	// Does not require physics 
	public void Update() {
		Shoot(); 
	}

	public virtual void Move() { return; }
	public virtual void Shoot() { return; } 
}
