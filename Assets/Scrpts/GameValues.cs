
using UnityEditor.SceneManagement;

public class GameValues 
{
	public enum Difficulties { Easy, Medium, Hard };
	public static bool IsMultiplayer;
	public static Difficulties Difficulty = Difficulties.Easy;
}
