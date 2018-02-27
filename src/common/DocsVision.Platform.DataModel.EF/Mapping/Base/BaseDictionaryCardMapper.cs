using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.Platform.DataModel.Mapping
{
	public abstract class BaseDictionaryCardMapper<TDictionary> : BaseCardMapper<TDictionary> where TDictionary : BaseDictionaryCard
	{
		protected internal BaseDictionaryCardMapper(Guid typeID) : base(typeID) { }

		protected override void MapEntity(EntityTypeBuilder<TDictionary> entityBuilder)
		{
			base.MapEntity(entityBuilder);
		}
	}
}