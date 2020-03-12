using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Queue<string> messageQueue;

    public GameObject chatMessagePrefab;

    public RectTransform chatMessageParent; // Content panel 

    public bool doDestroy = false;
    public float destroyChatTime = 5f;

    private void Start()
    {
        messageQueue = new Queue<string>();

        messageQueue.Enqueue("The queue is awake");

    }

    private void Update()
    {
        CheckNewMessages();
    }

    void CheckNewMessages()
    {
        if (messageQueue.Count > 0)
        {
            foreach (string line in messageQueue)
            {
                Messenger.Instance.CreateMessage(doDestroy, destroyChatTime, chatMessagePrefab, chatMessageParent, line, Color.black);
            }
            messageQueue.Dequeue();
        }
    }

    public void CreateMessage()
    {
        messageQueue.Enqueue("I've created a messsage");
    }
}
