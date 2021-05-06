using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFSQueueNode<T> {
    public T value;
    public List<T> path;
    public BFSQueueNode<T> next;
    public BFSQueueNode(T value, List<T> path) {
        this.value = value;
        this.path = new List<T>(path);
        this.path.Add(value);
    }
}
