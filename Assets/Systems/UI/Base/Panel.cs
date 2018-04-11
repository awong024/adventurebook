using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour {
    
    public virtual void Display() {
        
    }

    public virtual void Dismiss() {
        gameObject.SetActive(false);
    }
}
