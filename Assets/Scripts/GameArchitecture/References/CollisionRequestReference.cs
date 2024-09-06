using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class CollisionRequestReference : BaseReference<CollisionRequest, CollisionRequestVariable>
	{
	    public CollisionRequestReference() : base() { }
	    public CollisionRequestReference(CollisionRequest value) : base(value) { }
	}
}