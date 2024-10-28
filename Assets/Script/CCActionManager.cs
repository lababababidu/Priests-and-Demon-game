using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCActionManager : SSActionManager, ISSActionCallback {
	
	private FirstController sceneController;

	public bool onaction = false;

	protected new void Start() {

		sceneController = (FirstController)SSDirector.getInstance().currentSceneController;
        sceneController.actionManager = this;


	}

	// Update is called once per frame
	protected new void Update ()
	{
		base.Update ();
	}
		
	public void boatgo(){
		if(onaction){
			return;
		}
		onaction = true;

		

		GameObject boat = sceneController.boat;
		Boatmanager BM = boat.GetComponent<Boatmanager>();

		if(BM.emptyseat == 2){
			onaction = false;
			return;
		}

		GameObject OnSeatObj1,OnSeatObj2;
		OnSeatObj1 = BM.Seat1;
		OnSeatObj2 = BM.Seat2;

		CCMoveToAction M,M1,M2;
		if(BM.side == 1){
			Vector3 target = BM.BoatTransform.position + new Vector3(3,0,0);
			BM.side = 2;
			M = CCMoveToAction.GetSSAction(target,4);
		}
		else{
			Vector3 target = BM.BoatTransform.position + new Vector3(-3,0,0);
			BM.side = 1;
			M = CCMoveToAction.GetSSAction(target,4);
		}
		
		this.RunAction (boat, M, this);

		if(OnSeatObj1!=null){
			if(BM.side != 1){
				Vector3 target1 = OnSeatObj1.transform.position + new Vector3(3,0,0);
				M1 = CCMoveToAction.GetSSAction(target1,4);
			}
			else{
				Vector3 target1 = OnSeatObj1.transform.position + new Vector3(-3,0,0);
				M1 = CCMoveToAction.GetSSAction(target1,4);
			}
				
			this.RunAction (OnSeatObj1, M1, this);
		}
		if(OnSeatObj2!=null){
			if(BM.side != 1){
				Vector3 target2 = OnSeatObj2.transform.position + new Vector3(3,0,0);
				M2 = CCMoveToAction.GetSSAction(target2,4);
			}
			else{
				Vector3 target2 = OnSeatObj2.transform.position + new Vector3(-3,0,0);
				M2 = CCMoveToAction.GetSSAction(target2,4);
			}
				
			this.RunAction (OnSeatObj2, M2, this);
			// onaction = false;
		}

	}

	public void onclickcharacter(GameObject Obj){

		CharacterManager CM = Obj.GetComponent<CharacterManager>();

		if(CM.side != 0){
			onboat(Obj,CM.side);
		}
		else{
			Boatmanager BM = GameObject.Find("boat").GetComponent<Boatmanager>();
			offboat(Obj,BM.side);
		}


	}

	public void onboat(GameObject Obj,int from){
		if(onaction){
			return;
		}
		onaction = true;
		CCSequenceAction SeqActions = OnBoatAction.GetSeqActions (Obj,4,from);
		this.RunAction (Obj, SeqActions, this);
		// onaction = false;
	}

	public void offboat(GameObject Obj,int to){
		if(onaction){
			return;
		}
		onaction = true;
		CCSequenceAction SeqActions = OffBoatAction.GetSeqActions (Obj,4,to);
		this.RunAction (Obj, SeqActions, this);
		// onaction = false;
	}

	#region ISSActionCallback implementation
	public void SSActionEvent (SSAction source, SSActionEventType events = SSActionEventType.Competeted, int intParam = 0, string strParam = null, Object objectParam = null)
	{
		onaction = false;
		Debug.Log("action finished");
	}
	#endregion
}

