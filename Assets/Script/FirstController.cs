using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction {

	public CCActionManager actionManager { get; set;}

	// public shoremanager shore1,shore2;
	public GameObject shore1,shore2;
	public GameObject boat;
	public GameObject Dsample,Psample;

	public int gameover = 0 ;

	// the first scripts
	void Awake () {
		SSDirector director = SSDirector.getInstance ();
		director.setFPS (60);
		director.currentSceneController = this;
		director.currentSceneController.LoadResources ();
		Debug.Log ("awake FirstController!");
	}
	 
	// loading resources for first scence
	public void LoadResources () {
		shoremanager SM1 = shore1.GetComponent<shoremanager>();
		SM1.Demonnum = 3;
		SM1.Priestnum = 3;

		GameObject clone = Instantiate(Dsample); // 创建克隆对象
		clone.transform.position = Dsample.transform.position + new Vector3(-1.5f, 0, 0);
		clone.name = Dsample.name + "_1";
		SM1.Seats[4] = clone;
		GameObject clone2 = Instantiate(Dsample); // 创建克隆对象
		clone2.transform.position = Dsample.transform.position + new Vector3(-3f, 0, 0);
		clone2.name = Dsample.name + "_2";
		SM1.Seats[5] = clone2;
		SM1.Seats[3] = GameObject.Find("Demon sample");


		SM1.Seats[2] = GameObject.Find("Priest sample");
		GameObject clone3 = Instantiate(Psample); // 创建克隆对象
		clone3.transform.position = Psample.transform.position + new Vector3(1.5f, 0, 0);
		clone3.name = Psample.name + "_1";
		SM1.Seats[1] = clone3;
		GameObject clone4 = Instantiate(Psample); // 创建克隆对象
		clone4.transform.position = Psample.transform.position + new Vector3(3f, 0, 0);
		clone4.name = Psample.name + "_2";
		SM1.Seats[0] = clone4;
		;
	}

	void OnGUI() {
		float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float windowWidth = 200;
        float windowHeight = 200;
		if(gameover == 1){
			GUI.Box(new Rect(
                    (screenWidth - windowWidth) / 2,
                    (screenHeight - windowHeight) / 2,
                    windowWidth,
                    windowHeight
                ), "\n\n\n\n\nYOU LOSS!\n ");
		}
		if(gameover == 2){
			GUI.Box(new Rect((screenWidth - windowWidth) / 2,(screenHeight - windowHeight) / 2,windowWidth,windowHeight), "\n\n\n\n\nCongratulations You Won!\n");
		}
	}


	public void JudgeResultCallBack (int situation){
		gameover = situation;
	}

	public void Pause ()
	{
		throw new System.NotImplementedException ();
	}

	public void Resume ()
	{
		throw new System.NotImplementedException ();
	}

	#region IUserAction implementation
	public void GameOver ()
	{
		SSDirector.getInstance ().NextScene ();
	}
	#endregion


	// Use this for initialization
	void Start () {
		//give advice first
	}
	
	// Update is called once per frame
	void Update () {
		//give advice first
		
		if (Input.GetMouseButtonDown(0))
        {
            // 创建从摄像机到鼠标点击位置的射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 使用 Raycast 检测碰撞
            if (Physics.Raycast(ray, out hit))
            {
                // 获取被点击的对象
                GameObject clickedObject = hit.collider.gameObject;
                Debug.Log("Clicked on: " + clickedObject.name);
				
				if(clickedObject.name=="boat"){
					this.actionManager.boatgo();
				}

				if(clickedObject.tag == "character"){
					this.actionManager.onclickcharacter(clickedObject);
				}
                // 在这里可以对 clickedObject 执行其他操作
            }
        }
	}

}
