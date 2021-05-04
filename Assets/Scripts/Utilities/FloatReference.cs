using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloatReference {
    public FloatReference(float constantValue) {
        this.useConstant = true;
        this.constantValue = constantValue;
    }

    public FloatReference(FloatVariable floatVariable) {
        this.useConstant = false;
        this.floatVariable = floatVariable;
    }

    public bool useConstant;
    public float constantValue;
    public FloatVariable floatVariable;

    public float Value {
        get { return useConstant ? constantValue : floatVariable.value; }
    }
}
