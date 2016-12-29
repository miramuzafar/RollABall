using UnityEngine;

public class ToggleableItem : MonoBehaviour {

	ToggleableContainer _container;
    // public AudioSource crash;

    // Allow the parent container to register itself.
    public void SetContainer(ToggleableContainer container) { 
        _container = container;
    }

    // For simple click interactions, Unity will handle the raycasting for you
    // if you just implement a method to respond to the "OnMouseDown" message.
    void OnMouseDown() {
        // Tell our container we've been selected - it will handle coordinating the rest.
        if(_container != null)
             _container.Select(this);
    }
}
