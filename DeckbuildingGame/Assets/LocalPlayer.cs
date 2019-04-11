using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayer : MonoBehaviour
{
    public static LocalPlayer instance = null;

    public List<InteractableCard> hand;
    //public List<Something> deck;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
