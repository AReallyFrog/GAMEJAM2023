using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCheck : MonoBehaviour
{

    public List<Root> rootList;
    public GameObject Cannon1;
    public GameObject Cannon2;
    public GameObject Window;
    public GameObject Meteor;
    bool Check;

    public void RunCheck()
    {
        
        Check = true;
                   
    }


    void LateUpdate()
    {
        if(Check == true)
        {
            for(int i = 0; i < rootList.Count; i++)
            {
                if (rootList[i].Finished == false)
                {
                    break;
                    Check = false;
                }
                else
                {
                    if (i == rootList.Count - 1)
                    {
                        if (rootList[1].Finished == true)
                        {

                            Cannon1.SetActive(true);
                            Cannon2.SetActive(true);
                            Window.SetActive(true);
                            Meteor.SetActive(false);

                            Check = false;
                        }
                    }
                }


            }



        }
    }
}



  
