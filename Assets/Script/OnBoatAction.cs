using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBoatAction
{
    public double speed;
    public int from;
    public int ToWhichSeat;

    public static CCSequenceAction GetSeqActions(GameObject Character,float speed,int from){

        CharacterManager CM = Character.GetComponent<CharacterManager>();

        GameObject BoatObj = GameObject.Find("boat");
        Boatmanager BM = BoatObj.GetComponent<Boatmanager>();

        GameObject shore1 = GameObject.Find("Shore1");
        shoremanager SM1 = shore1.GetComponent<shoremanager>();
        
        GameObject shore2 = GameObject.Find("Shore2");
        shoremanager SM2 = shore2.GetComponent<shoremanager>();
        
        Vector3 BoatPosition = BM.BoatTransform.position;
        Vector3 ori = Character.transform.position;

        CCMoveToAction M_DQ = CCMoveToAction.GetSSAction(new Vector3(ori[0],ori[1],ori[2]-1f),speed);

        if(BM.emptyseat == 0||BM.side != from){
            CCMoveToAction M_IQ = CCMoveToAction.GetSSAction(new Vector3(ori[0],ori[1],ori[2]),speed);
            CCSequenceAction SeqActions_DI = CCSequenceAction.GetSSAction (1, 0 , new List<SSAction> {M_DQ, M_IQ});
            Debug.Log("On Boat Failed");
            return SeqActions_DI;
        }
        else{
            CCSequenceAction SeqActions_OB;
            int emptyseat = BM.returnseat();
            if(emptyseat == 1){
                CCMoveToAction M_2B = CCMoveToAction.GetSSAction(new Vector3(BoatPosition[0]-0.5f,ori[1],ori[2]-1f),3*speed);
                CCMoveToAction M_OB = CCMoveToAction.GetSSAction(new Vector3(BoatPosition[0]-0.7f,BoatPosition[1]+1f,BoatPosition[2]),2*speed);

                 SeqActions_OB = CCSequenceAction.GetSSAction (1, 0 , new List<SSAction> {M_DQ, M_2B, M_OB});
                BM.emptyseat -= 1;
                BM.Seat1 = Character;

                Debug.Log("On Boat");

            }
            else{
                CCMoveToAction M_2B = CCMoveToAction.GetSSAction(new Vector3(BoatPosition[0],ori[1],ori[2]-1f),3*speed);
                CCMoveToAction M_OB = CCMoveToAction.GetSSAction(new Vector3(BoatPosition[0]+0.7f,BoatPosition[1]+1f,BoatPosition[2]),2*speed);

                 SeqActions_OB = CCSequenceAction.GetSSAction (1, 0 , new List<SSAction> {M_DQ, M_2B, M_OB});
                BM.emptyseat -= 1;
                BM.Seat2 = Character;

                Debug.Log("On Boat");
                
            }
            
            if(from == 1){
                if(CM.type == 1){
                    Debug.Log("from1 Type1");
                    SM1.Priestnum -= 1;
                }
                else{
                    SM1.Demonnum -= 1;
                }
                SM1.offshore(Character);
            }
            else{
                if(CM.type == 1){
                    SM2.Priestnum -= 1;
                }
                else{
                    SM2.Demonnum -= 1;
                }
                SM2.offshore(Character);
            }

            CM.side = 0;

            return SeqActions_OB;

        }
        
    }

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {




       
    }
}
