using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boatmanager : MonoBehaviour
{
    // Start is called before the first frame update
    public int emptyseat=2;
    public int side=1;
    public Transform BoatTransform;
    public GameObject Seat1;
    public GameObject Seat2;

    public int returnseat(){
        if(Seat1 == null){
            return 1;
        }
        if(Seat2 == null){
            return 2;
        }
        else{
            return 0;
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
