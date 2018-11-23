﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

// Coded by Fei Huang(Algorithm), Yuqi Wang(VR Interaction)
public class ETR_ClockControl : MonoBehaviour
{

    public Transform hourHand, minuteHand, secondHand, sunLight;
    public Light assistLight;

    public static bool userInput = false;
    public static bool mOrH = true; //true is min, false is hour
    private static float angle = 0;

    private const float
        hoursDegrees = 360f / (12f * 60f * 60f),
        hoursPerSecond = 1 / (60f * 60f),
        minutesDegrees = 360f / 3600f,
        minutesPerSecond = 1 / 60f,
        secondsDegrees = 360f / 60f;
    private float gameHourAngle, gameMinuteAngle, gameSecondAngle; //game time set by producer
    public int hour, minute, second; //the angle changed by operation
    private bool isGrabbed;

    // Use this for initialization
    void Start()
    {
        //hour = 8;
        //minute = 0;
        //second = 0;
        gameHourAngle = hour * 30f + minute * 0.5f;
        gameMinuteAngle = minute * 6f;
        isGrabbed = false;
        if(hour >= 8 && hour <= 16){
            assistLight.intensity = 1.5f;
        }else if(hour <= 4 || hour >= 20){
            assistLight.intensity = 0f;
        }else if(hour > 4 && hour < 8){
            assistLight.intensity = 0f + 0.375f * (hour - 4) + (0.375f / 60f) * minute;
        }else if((hour > 20 && hour < 23) || (hour == 23 && minute < 59)){
            assistLight.intensity = 1.5f - (0.375f * (hour - 4) + (0.375f / 60f) * minute);
        }else{
            //leave this one avoid bug
            Debug.Log("This line should not be displayed.");
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
            Debug.Log("hour " + hour + " minute " + minute + " second " + second);

            if(mOrH.Equals(true)){ //minute is changed
                //current hour angle sum
                gameHourAngle += angle/12f;
                //gameHourAngle = gameHourAngle % 360f;

                //current hour angle sum
                gameMinuteAngle += angle;
                //gameMinuteAngle = gameMinuteAngle % 360f;

                if (hour > 3 && hour < 9)  
                {
                    // 4AM - 8AM increase from 0 to 1.5
                    //per min 0.375/60 per min angle 0.375/1800
                    assistLight.intensity += (0.375f /1800f * angle); //angle is hour changed
                }
                else if (hour > 15 && hour < 21)
                {
                    assistLight.intensity -= (0.375f / 1800f) * angle; //angle is hour changed;
                }

            }
            else{ //hour is changed
                //current hour angle sum
                gameHourAngle += angle;
                //gameHourAngle = gameHourAngle % 360f;

                //current hour angle sum
                gameMinuteAngle += 12f * angle;
                //gameMinuteAngle = gameMinuteAngle % 360f;

                if (hour > 3 && hour < 9){
                    //per hour 0.375 per hour angle = 0.375/30
                    assistLight.intensity += (0.375f / 30f) * angle; //angle is hour changed
                }
                else if (hour > 15 && hour < 21)
                {
                    assistLight.intensity -= (0.375f / 30f) * angle; //angle is hour changed;
                }
            }
            userInput = false; //let the clock continue run
        }

        gameSecondAngle += Time.deltaTime * secondsDegrees;
        secondHand.localRotation = Quaternion.Euler(0f, 0f, gameSecondAngle);
        hourHand.localRotation = Quaternion.Euler(0f, 0f, gameHourAngle);
        minuteHand.localRotation = Quaternion.Euler(0f, 0f, gameMinuteAngle);

        //range the time
        int tmph = (int)Math.Floor(gameHourAngle % 720f / 30f);
        hour = tmph >= 0 ? tmph : 24 + tmph;

        int tmpm = (int)Math.Floor(gameMinuteAngle % 360f / 6f);
        minute = tmpm >= 0 ? tmpm : 60 + tmpm;

        //the second can not be changed and no negative situation
        second = (int)Math.Floor(gameSecondAngle % 360f / 6f);

        sunLight.rotation = Quaternion.Euler(-90f - gameHourAngle/2, 342.8f, -10.71399f);
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
}
