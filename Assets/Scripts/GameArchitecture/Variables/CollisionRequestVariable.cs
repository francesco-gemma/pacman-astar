using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "CollisionRequestVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Collision",
	    order = 120)]
	public class CollisionRequestVariable : BaseVariable<CollisionRequest>
	{
	}
}