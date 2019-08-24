// ------------------------------------------------------------------------------
// <auto-generated>
//    Generated by avrogen, version 1.9.0.0
//    Changes to this file may cause incorrect behavior and will be lost if code
//    is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
namespace AvroListOfLists.Records
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using Avro;
	using Avro.Specific;
	
	public partial class ListOfListsRecord : ISpecificRecord
	{
		public static Schema _SCHEMA = Avro.Schema.Parse("{\"type\":\"record\",\"name\":\"ListOfListsRecord\",\"namespace\":\"AvroListOfLists.Records\"" +
				",\"fields\":[{\"name\":\"MyListOfLists\",\"type\":{\"type\":\"array\",\"items\":{\"type\":\"array" +
				"\",\"items\":\"int\"}}}]}");
		private IList<IList<System.Int32>> _MyListOfLists;
		public virtual Schema Schema
		{
			get
			{
				return ListOfListsRecord._SCHEMA;
			}
		}
		public IList<IList<System.Int32>> MyListOfLists
		{
			get
			{
				return this._MyListOfLists;
			}
			set
			{
				this._MyListOfLists = value;
			}
		}
		public virtual object Get(int fieldPos)
		{
			switch (fieldPos)
			{
			case 0: return this.MyListOfLists;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
			};
		}
		public virtual void Put(int fieldPos, object fieldValue)
		{
			switch (fieldPos)
			{
			case 0: this.MyListOfLists = (IList<IList<System.Int32>>)fieldValue; break;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
			};
		}
	}
}
