using UnityEngine;
using System.Collections;

public class ToggleableContainer : MonoBehaviour {

	 ToggleableItem _currentSelection;
     bool isAlreadyClicked = false;

    // On initialization, find all toggleable children of this parent.
    void Start() {
       ToggleableItem[] children = GetComponentsInChildren<ToggleableItem>();
       // Let each child know who to talk to when they're clicked:
       foreach(var child in children)
           child.SetContainer(this);
    }

    // When one platform is clicked, disable it and re-enable the last selection (if any).
    public void Select(ToggleableItem target) {
       if(!isAlreadyClicked)//if only one platform can be clicked, or else disable this boolean
       {
       if(target == _currentSelection)
          return;

        if(_currentSelection != null)
            _currentSelection.gameObject.SetActive(true);

        if(target != null)
            target.gameObject.SetActive(false);

        _currentSelection = target;
        isAlreadyClicked = true;
        }
    }    
}
