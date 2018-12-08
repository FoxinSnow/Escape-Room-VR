using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

// Coded by Fei Huang(Algorithm), Yuqi Wang(VR Interaction)
public class ETR_AlarmControl : MonoBehaviour
{
    public GameObject tutorialControl;

    public Transform hourHand, minuteHand;

    public static bool userInput = false;
    public static bool mOrH = true; //true is min, false is hour
    private static float angle = 0;
    public int hour, minute, second; //these are set from ClockControl
    public AudioSource alarmRing;
    public AudioClip alarmDrop;
    public UnityEngine.Events.UnityEvent alarmTutorialEvent;
    private bool triggered; 

    private bool ring = true;//true is ring, if false never ring

    private const float
        hoursDegrees = 360f / (12f * 60f * 60f),
        hoursPerSecond = 1 / (60f * 60f),
        minutesDegrees = 360f / 3600f,
        minutesPerSecond = 1 / 60f,
        secondsDegrees = 360f / 60f;
    private float gameHourAngle, gameMinuteAngle, gameSecondAngle; //game time set by producer
  
    // Use this for initialization
    void Start()
    {
       
        gameHourAngle = hour * 30f + minute * 0.5f;
        gameMinuteAngle = minute * 6f;

        if (hour == 9 && minute == 15 && second == 0)
        {
            GoRing();
        }

        triggered = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (this.GetComponent<Rigidbody>().velocity.magnitude > 0.75f && collision.gameObject.tag != "Player" && collision.gameObject.tag != "Controller")
        {
            if (!triggered) {
                alarmRing.Stop();
                alarmRing.loop = false;
                alarmRing.clip = alarmDrop;
                alarmRing.Play();
                ring = false;
                //Debug.Log("Alarm ring stops");
                if (tutorialControl.activeSelf) {
                    alarmTutorialEvent.Invoke();
                } 
                triggered = true;
            }  
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("parents:" + hours.parent.name);

        if (userInput.Equals(false))
        {
            //if user does not do anything to the clock, it is a normal clock

            //every second
            gameHourAngle += Time.deltaTime * hoursDegrees;
            //gameHourAngle = gameHourAngle % 360f;

            gameMinuteAngle += Time.deltaTime * minutesDegrees;
            //gameHourAngle = gameMinuteAngle % 360f;

        }
        else
        {
            //if (mOrH.Equals(true)){ //minute is changed
            //    //current hour angle sum
            //    gameHourAngle += angle/12f;
            //    //gameHourAngle = gameHourAngle % 360f;

            //    //current hour angle sum
            //    gameMinuteAngle += angle;
            //    //gameMinuteAngle = gameMinuteAngle % 360f;

             
            //}
            //else{ //hour is changed
                //current hour angle sum
                gameHourAngle += angle;
                //gameHourAngle = gameHourAngle % 360f;

                //current hour angle sum
                gameMinuteAngle += 12f * angle;
                //gameMinuteAngle = gameMinuteAngle % 360f;

                //Debug.Log("Passed second:" + angle * 120f);
               
            //}
            userInput = false; //let the clock continue run

            
        }

        gameSecondAngle += Time.deltaTime * secondsDegrees;
       
        hourHand.localRotation = Quaternion.Euler(0f, 0f, gameHourAngle);
        minuteHand.localRotation = Quaternion.Euler(0f, 0f, gameMinuteAngle);

        //range the time
        int tmph = (int)Math.Floor(gameHourAngle % 720f / 30f);
        hour = tmph >= 0 ? tmph : 24 + tmph;

        int tmpm = (int)Math.Floor(gameMinuteAngle % 360f / 6f);
        minute = tmpm >= 0 ? tmpm : 60 + tmpm;

        second = 0;

        if (hour == 9 && minute == 15 && second == 0)
        {
            GoRing();
        }

    }

    //static method

    //turn = ture if user drag the minute
    public static void TurnClock(bool turn, float a)
    {

        if (turn.Equals(true))
        {
            mOrH = true;
            userInput = true;
            angle = a;
        }
    }

    //turn = ture if user drag the hour
    public static void TurnClockHour(bool turn, float a)
    {

        if (turn.Equals(true))
        {
            mOrH = false;
            userInput = true;
            angle = a;

        }
    }

    private void GoRing()
    {
        if (ring.Equals(true))
        {
            Debug.Log("alarm play");
            alarmRing.Play();
        }
    }
}
