using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inqueue : SSAction
{
    // Start is called before the first frame update
    public float speed;

    public static inqueue GetSSAction(float speed){
		inqueue action = ScriptableObject.CreateInstance<inqueue> ();
		// action.target = target;
		action.speed = speed;
		return action;
	}
    public override void Start () {
	}

    // Update is called once per frame
    public override void Update ()
	{

		Vector3 target;
        //出列
        target =  new Vector3(this.transform.position[0],this.transform.position[1],-0.5f);
        
        this.transform.position = Vector3.MoveTowards (this.transform.position, target , (float) speed * Time.deltaTime);
		if (this.transform.position == target) {
			//waiting for destroy
			this.destory = true;  
			this.callback.SSActionEvent (this);
		}
        
	}
}
