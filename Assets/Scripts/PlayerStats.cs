using UnityEngine;
using System.Collections;

public static class PlayerStats
{
	private static uint kills, deaths, assists, points;

	public static uint Kills 
	{
		get 
		{
			return kills;
		}
		set 
		{
			kills = value;
		}
	}

	public static uint Deaths 
	{
		get 
		{
			return deaths;
		}
		set 
		{
			deaths = value;
		}
	}

	public static uint Assists 
	{
		get 
		{
			return assists;
		}
		set 
		{
			assists = value;
		}
	}

	public static uint Points 
	{
		get 
		{
			return points;
		}
		set 
		{
			points = value;
		}
	}
}
