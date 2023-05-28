using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Reference<T> : ScriptableObject {
    public T reference;

    public void set(T newValue) {
        this.reference = newValue;
    }

    public T get () {
        return this.reference;
    } 

    public bool hasValue() {
        return this.reference != null;
    }
}
