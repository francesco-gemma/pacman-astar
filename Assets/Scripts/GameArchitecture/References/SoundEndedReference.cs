using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class SoundEndedReference : BaseReference<SoundEnded, SoundEndedVariable>
	{
	    public SoundEndedReference() : base() { }
	    public SoundEndedReference(SoundEnded value) : base(value) { }
	}
}