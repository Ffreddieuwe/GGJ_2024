using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public GasReaction gasReaction;
    public bool gotKey = false;
    public bool gotMask
    {
        get => gotMask;
        set
        {
            if (value == true)
            {
                gasReaction.decayRate = 0.01f;
            }
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
