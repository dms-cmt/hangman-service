using System;
using System.Runtime.Serialization;

namespace HangmanService
{
	[DataContract]
	public enum ETipSortiranja
	{
		[EnumMember]
		NajboljiUkupno,
		[EnumMember]
		NajboljiPoVremenu,
		[EnumMember]
		NajboljiPoBrojuSlova
	}
}

