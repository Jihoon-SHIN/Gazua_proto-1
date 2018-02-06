using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCheck : MonoBehaviour {

    static float beat = 0;
    static float memory = 0;
	static float pos = 0;
	static float timeLap = 0;
    public static void setbeat(float timelap)
    {
            memory = beat;
			timeLap = timelap;
            beat = (timelap * 130 / (60f)) % 4 + 1;
			//beat = (timelap * 130 / (120f)) + 1;
    }

    public static int getbeat()
    {
        if (memory > beat)
        {
            return 0;
        }
        return (int)beat;
    }

	public static float getPosition()
	{
		//pos = -5.75f + (3.5f*(((beat-1) + (7f / 130f)) % (240f/130f))/(240f/130f));
		pos = -5.75f + (3.5f*((timeLap + (7f / 130f)) % (240f/130f))/(240f/130f));
		//pos = -5.75f + (3.5f / 4  * (-(beat - 1)));
		return pos;
	}
}
