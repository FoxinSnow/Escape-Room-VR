using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

// Coded by Fei Huang(Algorithm), Yuqi Wang(VR Interaction)
public class ETR_ClockControl : MonoBehaviour
{

    public Transform hourHand, minuteHand, secondHand, sunLight;

    public static bool userInput = false;
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

            //current hour angle sum
            gameHourAngle += angle;
            //gameHourAngle = gameHourAngle % 360f;

            //current hour angle sum
            gameMinuteAngle += 12 * angle;
            //gameMinuteAngle = gameMinuteAngle % 360f;

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

        sunLight.localRotation = Quaternion.Euler(gameHourAngle, 0f, 0f);
    }

    //static method

    //turn = ture if user drag the hour
    public static void TurnClock(bool turn, float a)
    {

        if (turn.Equals(true))
        {
            userInput = true;
            angle = a;
        }
    }

}
