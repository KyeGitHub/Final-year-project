using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Script that deals with the message log, following tutorial found: https://www.youtube.com/watch?v=t6spzvSzNrQ
/// </summary>
public class Messenger : MonoBehaviour
{
    private static Messenger instance;




    public static Messenger Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Messenger>();
            }
            return instance;
        }
    }

    public void CreateMessage(bool willDestroy, float destroyTime, GameObject messagePrefab, RectTransform messageParent, string myMessage, Color messageColour)
    {
        GameObject cm = Instantiate(messagePrefab, messagePrefab.transform.position, Quaternion.identity);  // create message

       cm.transform.SetParent(messageParent); // set the messages parent to be the conent panel
      
       cm.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
      
       cm.transform.GetChild(0).GetComponent<Text>().text = myMessage;

        cm.transform.GetChild(0).GetComponent<Text>().color = messageColour;

        if (willDestroy)
            Destroy(cm, destroyTime);

    }
}
