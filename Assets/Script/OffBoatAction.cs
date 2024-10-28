using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffBoatAction
{

    public static CCSequenceAction GetSeqActions(GameObject Character,float speed,int to){

        CharacterManager CM = Character.GetComponent<CharacterManager>();

        GameObject BoatObj = GameObject.Find("boat");
        Boatmanager BM = BoatObj.GetComponent<Boatmanager>();

        GameObject shore1 = GameObject.Find("Shore1");
        shoremanager SM1 = shore1.GetComponent<shoremanager>();
        
        GameObject shore2 = GameObject.Find("Shore2");
        shoremanager SM2 = shore2.GetComponent<shoremanager>();

        Vector3 BoatPosition = BM.BoatTransform.position;
        Vector3 ori = Character.transform.position;

        

        CCMoveToAction M_DQ = CCMoveToAction.GetSSAction(new Vector3(ori[0],ori[1],-0.5f),speed);


        CCMoveToAction M_IQ_ = CCMoveToAction.GetSSAction(new Vector3(ori[0],ori[1],ori[2]),speed);
        
        CCSequenceAction SeqActions_OFB = null;
        if(to == 1){
            
            int emptyseat = SM1.returnseat();

            Debug.Log("TO1 TYPE1");
            CCMoveToAction M_OFB = CCMoveToAction.GetSSAction(new Vector3(ori[0],0.06f,-0.35f),3*speed);
            CCMoveToAction M_OS = CCMoveToAction.GetSSAction(new Vector3(-3.5f - 1.5f*emptyseat ,0.06f,-0.5f),3*speed);
            CCMoveToAction M_IQ = CCMoveToAction.GetSSAction(new Vector3(-3.5f - 1.5f*emptyseat,0.06f, 0.35f),speed);
            SeqActions_OFB = CCSequenceAction.GetSSAction (1, 0 , new List<SSAction> { M_DQ , M_OFB , M_OS , M_IQ });
            if(CM.type == 1){
                SM1.Priestnum += 1;
            }
            else{
                SM1.Demonnum += 1;
            }
            SM1.Seats[emptyseat] = Character;
            CM.side = 1;
            BM.emptyseat += 1;
            
           
        }else{
            int emptyseat = SM2.returnseat();

            Debug.Log("TO1 TYPE1");
            CCMoveToAction M_OFB = CCMoveToAction.GetSSAction(new Vector3(ori[0],0.06f,-0.35f),3*speed);
            CCMoveToAction M_OS = CCMoveToAction.GetSSAction(new Vector3(3.5f + 1.5f*emptyseat ,0.06f,-0.5f),3*speed);
            CCMoveToAction M_IQ = CCMoveToAction.GetSSAction(new Vector3(3.5f + 1.5f*emptyseat,0.06f, 0.35f),speed);
            SeqActions_OFB = CCSequenceAction.GetSSAction (1, 0 , new List<SSAction> { M_DQ , M_OFB , M_OS , M_IQ });
            if(CM.type == 1){
                SM2.Priestnum += 1;
            }
            else{
                SM2.Demonnum += 1;
            }
            SM2.Seats[emptyseat] = Character;
            CM.side = 2;
            BM.emptyseat += 1;
        }

        if(BM.Seat1 == Character){
            BM.Seat1 = null;
        }
        else{
            BM.Seat2 = null;
        }


        return SeqActions_OFB;

        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
