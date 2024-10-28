using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoremanager : MonoBehaviour
{
    // Start is called before the first frame update
    public int Demonnum;
    public int Priestnum;

    public GameObject[] Seats = new GameObject[6];

    public void offshore(GameObject Character){
        for(int i=0;i<6;i++){
            if(Seats[i] == Character){
                Seats[i] = null;
            }
        }
    }

    public int returnseat(){
        for(int i=0;i<6;i++){
            if(Seats[i] == null){
                return i;
            }
        }
        return -1;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int[] GetRoleNum(){
        int[] numbers = new int[] { Priestnum , Demonnum };
        return numbers;
    }
}
