using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ClockRun : MonoBehaviour {

    public Transform hours, minutes, seconds, thelight;

    public static bool userInput = false;
    private static float angle = 0;

    private const float
        hoursDegrees = 360f / (12f * 60f * 60f),
        hoursPerSecond = 1 / (60f * 60f),
        minutesDegrees = 360f / 3600f,
        minutesPerSecond = 1 / 60f,
        secondsDegrees = 360f / 60f;
    private float gameHourAngle, gameMinuteAngle, gameSecondAngle; //game time set by producer
    private int hour, minute, second; //the angle changed by operation

    // Use this for initialization
    void Start () {
        hour = 8;
        minute = 0;
        second = 0;
        gameHourAngle = -hour * 30f;
        gameMinuteAngle = -minute * 0.5f;
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log("parents:" + hours.parent.name);

        if (userInput.Equals(false))
        {
            //if user does not do anything to the clock, it is a normal clock

            //every second
            gameHourAngle -= Time.deltaTime * hoursDegrees;
            //gameHourAngle = gameHourAngle % 360f;

            gameMinuteAngle -= Time.deltaTime * minutesDegrees;
            //gameHourAngle = gameMinuteAngle % 360f;

        }
        else
        {
            Debug.Log("hour " + hour + " minute " + minute + " second " + second);

            //current hour angle sum
            gameHourAngle -= angle;
            //gameHourAngle = gameHourAngle % 360f;

            //current hour angle sum
            gameMinuteAngle -= 12 * angle;
            //gameMinuteAngle = gameMinuteAngle % 360f;

            userInput = false; //let the clock continue run
        }

        gameSecondAngle -= Time.deltaTime * secondsDegrees;
        seconds.localRotation = Quaternion.Euler(0f, 0f, gameSecondAngle);
        hours.localRotation = Quaternion.Euler(0f, 0f, gameHourAngle);
        minutes.localRotation = Quaternion.Euler(0f, 0f, gameMinuteAngle);

        //range the time
        int tmph = (int)Math.Floor(-gameHourAngle % 720f / 30f);
        hour = tmph >= 0 ? tmph : 24 + tmph;

        int tmpm = (int)Math.Floor(-gameMinuteAngle % 360f / 6f);
        minute = tmpm >= 0 ? tmpm : 60 + tmpm;

        //the second can not be changed and no negative situation
        second = (int)Math.Floor(-gameSecondAngle % 360f / 6f);

        thelight.localRotation = Quaternion.Euler(0f, 0f, gameHourAngle/2);
        //game hour angle /2 because 24hours 360degree sun
        //??what is moonlight...
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
