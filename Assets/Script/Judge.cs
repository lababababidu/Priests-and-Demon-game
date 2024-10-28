using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge:MonoBehaviour
    {
        public FirstController sceneController;
        public shoremanager shore2;
        public shoremanager shore1;
        public Boatmanager boat;
        private void Start()
        {
            sceneController = (FirstController)SSDirector.getInstance().currentSceneController;
            this.shore2 = sceneController.shore2.GetComponent<shoremanager>();
            this.shore1 = sceneController.shore1.GetComponent<shoremanager>();
            this.boat = sceneController.boat.GetComponent<Boatmanager>();
        }
        private void Update()
        {
            int start_priest = (shore1.GetRoleNum())[0];
            int start_devil = (shore1.GetRoleNum())[1];
            int end_priest = (shore2.GetRoleNum())[0];
            int end_devil = (shore2.GetRoleNum())[1];
 
            if (end_priest + end_devil == 6)     //获胜
                sceneController.JudgeResultCallBack(2);
 
            if (start_priest > 0 && start_priest < start_devil) //失败
            {
                sceneController.JudgeResultCallBack(1);
            }
            if (end_priest > 0 && end_priest < end_devil)        //失败
            {
                sceneController.JudgeResultCallBack(1);
            }
            //未完成
        }
    }
