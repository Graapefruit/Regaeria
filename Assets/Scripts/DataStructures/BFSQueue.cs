using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFSQueue<T> {
    private HashSet<T> tilesSeen;
    private BFSQueueNode<T> start;
    private BFSQueueNode<T> end;
    public BFSQueue() {
        tilesSeen = new HashSet<T>();
        start = null;
        end = null;
    }

    public bool isEmpty() {
        return start == null;
    }

    public void add(T value, List<T> path) {
        if (tilesSeen.Contains(value)) {
            return;
        }
        tilesSeen.Add(value);
        if (isEmpty()) {
            BFSQueueNode<T> newNode = new BFSQueueNode<T>(value, path);
            start = newNode;
            end = newNode;
        } else {
            BFSQueueNode<T> newNode = new BFSQueueNode<T>(value, path);
            end.next = newNode;
            end = newNode;
        }
    }

    public T pop(out List<T> path) {
        if (isEmpty()) {
            path = null;
            return default(T);
        } else {
            BFSQueueNode<T> poppedNode = start;
            start = start.next;
            path = poppedNode.path;
            return poppedNode.value;
        }
    }
}
