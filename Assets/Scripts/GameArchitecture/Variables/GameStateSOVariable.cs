using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "GameStateSOVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Game State",
	    order = 120)]
	public class GameStateSOVariable : BaseVariable<GameStateSO>
	{
	}
}