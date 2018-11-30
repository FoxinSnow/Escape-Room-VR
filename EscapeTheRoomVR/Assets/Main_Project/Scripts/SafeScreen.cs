using System.Collections;
using System.Collections.Generic;
using VRTK;
using VRTK.Controllables.PhysicsBased;
using UnityEngine;

public class SafeScreen : MonoBehaviour {

    public GameObject safeDoorToUnlock;
    public Transform scr0, scr1, scr2, scr3, scr4, scr5, scr6;
    //C = 10, E = 11, O = 12, R = 13, T = 14, x = 15, * = 16, # = 17;
    public Texture tex0, tex1, tex2, tex3, tex4, tex5, tex6, tex7,
        tex8, tex9, tex10, tex11, tex12, tex13, tex14, tex15, tex16, tex17;
    private Transform[] scrs = new Transform[7]; //screens
    private Texture[] texs = new Texture[18]; //textures
    private int currentScr = 0; //0 ~ 6, mark the next screen should use
    private int[] password = new int[4];
    private int[] input = new int[7]
        {-1, -1, -1, -1, -1, -1, -1}; //7 is the max length, only check first 4 digit
    private float second = 0;//time to test whether to sleep
    private bool wOrS = false; //false = sleep, true = wake
    private int passC = 0; //not checked = 0, wrong = -1, correct = 1, when -1 begin sleep check
    private bool unlock = false; //false cannot open, true can open

    // Use this for initialization
    void Start () {
        scrs[0] = scr0; scrs[1] = scr1; scrs[2] = scr2; scrs[3] = scr3;
        scrs[4] = scr4; scrs[5] = scr5; scrs[6] = scr6;
        texs[0] = tex0; texs[1] = tex1; texs[2] = tex2; texs[3] = tex3;
        texs[4] = tex4; texs[5] = tex5; texs[6] = tex6; texs[7] = tex7;
        texs[8] = tex8; texs[9] = tex9; texs[10] = tex10; texs[11] = tex11;
        texs[12] = tex12; texs[13] = tex13; texs[14] = tex14; texs[15] = tex15;
        texs[16] = tex16; texs[17] = tex17;

        password[0] = 1;
        password[1] = 1;
        password[2] = 1;
        password[3] = 1;
	}
	
	// Update is called once per frame
	void Update () {
        sleepCheck();
    }

    //display numbers, n = 0 ~ 9, or 16, 17
    private void inputNum(int n){
        //current screen will display the input number
        scrs[currentScr].GetComponent<Renderer>().material.mainTexture = texs[n];
        input[currentScr] = n; //the input number will be stored for check
        currentScr++; //the current scr move to next one 
    }

    //delete the last number
    private void deleteNum(){
        scrs[currentScr - 1].GetComponent<Renderer>().material.mainTexture = texs[15];
        input[currentScr - 1] = -1;
        currentScr--;
        //Debug.Log("Delete " + currentScr);
    }

    private void cancel(){
        //reset changed variables
        resetInput();
        passC = 0;
        sleep();
    }

    //check whether password is correct
    private void checkPassword(){
        if (input[4] != -1){  //if there is more than 4 digit, wrong
            passwordWrong();
            return;
        } else { //else if there is only 4 digit
            for (int i = 0; i < 4; i++) {
                if (password[i] != input[i]){ //if any one is not correct, wrong
                    passwordWrong();
                    return;
                }
            }
            passwordCorrect();
        }
    }

    private void passwordCorrect(){
        Debug.Log("CORRECT");
        scrs[0].GetComponent<Renderer>().material.mainTexture = texs[10];//c
        scrs[1].GetComponent<Renderer>().material.mainTexture = texs[12];//o
        scrs[2].GetComponent<Renderer>().material.mainTexture = texs[13];//r
        scrs[3].GetComponent<Renderer>().material.mainTexture = texs[13];//r
        scrs[4].GetComponent<Renderer>().material.mainTexture = texs[11];//e
        scrs[5].GetComponent<Renderer>().material.mainTexture = texs[10];//c
        scrs[6].GetComponent<Renderer>().material.mainTexture = texs[14];//t
        passC = 1;//password is correct
        unlock = true;
        passC = -1; //after correct, the sleep check begin
        getUnLock();
    }

    private void passwordWrong(){
        Debug.Log("WRONG");
        allX();
        //reset to wait new input
        resetInput();
        passC = -1;
        //call ifWrongSleepCheck() in update
    }

    private void sleepCheck(){
        //after 2 second slepp the screen
        if (passC == -1)
        {
            second += Time.deltaTime;
            //Debug.Log(second);
            if (second > 2.0f)
            {
                sleep();
                passC = 0;
            }
        }
    }

    private void wakeUp(){
        allX();
        wOrS = true;
    }

    private void sleep(){
        allEmpty();
        wOrS = false;
    }

    private void resetInput(){
        //reset the input array
        for (int i = 0; i < 6; i++)
        {
            input[i] = -1;
        }
        //reset the current scr
        currentScr = 0;
    }

    //n = 0 ~ 17
    //main function
    public void pressButton(int n){
        //if not wake up, wake up first
        if(wOrS.Equals(false)){
            if (n != 10 && n != 11 && n !=12) { //delete enter and cancel can not wake up
                wakeUp();
            }
        }
        //0 1 2 3 4 5 6 7 8 9
        //delete = 10; cancel = 11; enter = 12;
        //* = 16, # = 17; 16 17 to be same with texture index 
        switch (n){
            case 0:
                if (currentScr > 6)
                {
                    break;
                }
                else{
                    inputNum(0);
                    break;
                }
            case 1:
                if (currentScr > 6)
                {
                    break;
                }
                else
                {
                    inputNum(1);
                    break;
                }
            case 2:
                if (currentScr > 6)
                {
                    break;
                }
                else
                {
                    inputNum(2);
                    break;
                }
            case 3:
                if (currentScr > 6)
                {
                    break;
                }
                else
                {
                    inputNum(3);
                    break;
                }
            case 4:
                if (currentScr > 6)
                {
                    break;
                }
                else
                {
                    inputNum(4);
                    break;
                }
            case 5:
                if (currentScr > 6)
                {
                    break;
                }
                else
                {
                    inputNum(5);
                    break;
                }
            case 6:
                if (currentScr > 6)
                {
                    break;
                }
                else
                {
                    inputNum(6);
                    break;
                }
            case 7:
                if (currentScr > 6)
                {
                    break;
                }
                else
                {
                    inputNum(7);
                    break;
                }
            case 8:
                if (currentScr > 6)
                {
                    break;
                }
                else
                {
                    inputNum(8);
                    break;
                }
            case 9:
                if (currentScr > 6)
                {
                    break;
                }
                else
                {
                    inputNum(9);
                    break;
                }
            case 10:
                if(currentScr == 0)
                {
                    break;
                }
                else{
                    deleteNum();
                    break;
                }
            case 11:
                cancel();
                break;
            case 12:
                checkPassword();
                break;
            case 16:
                if (currentScr > 6)
                {
                    break;
                }
                else
                {
                    inputNum(16);
                    break;
                }
            case 17:
                if (currentScr > 6)
                {
                    break;
                }
                else
                {
                    inputNum(17);
                    break;
                }
        }
    }

    private void getUnLock(){
        if (unlock.Equals(true))
        {
            safeDoorToUnlock.GetComponent<VRTK_PhysicsRotator>().enabled = true;
            safeDoorToUnlock.GetComponent<VRTK_PhysicsRotator>().isLocked = false;
            safeDoorToUnlock.GetComponent<VRTK_InteractObjectHighlighter>().enabled = true;
        }
    }

    private void allX(){
        scrs[0].GetComponent<Renderer>().material.mainTexture = texs[15];
        scrs[1].GetComponent<Renderer>().material.mainTexture = texs[15];
        scrs[2].GetComponent<Renderer>().material.mainTexture = texs[15];
        scrs[3].GetComponent<Renderer>().material.mainTexture = texs[15];
        scrs[4].GetComponent<Renderer>().material.mainTexture = texs[15];
        scrs[5].GetComponent<Renderer>().material.mainTexture = texs[15];
        scrs[6].GetComponent<Renderer>().material.mainTexture = texs[15];
    }

    private void allEmpty(){
        scrs[0].GetComponent<Renderer>().material.mainTexture = null;
        scrs[1].GetComponent<Renderer>().material.mainTexture = null;
        scrs[2].GetComponent<Renderer>().material.mainTexture = null;
        scrs[3].GetComponent<Renderer>().material.mainTexture = null;
        scrs[4].GetComponent<Renderer>().material.mainTexture = null;
        scrs[5].GetComponent<Renderer>().material.mainTexture = null;
        scrs[6].GetComponent<Renderer>().material.mainTexture = null;
    }
}
