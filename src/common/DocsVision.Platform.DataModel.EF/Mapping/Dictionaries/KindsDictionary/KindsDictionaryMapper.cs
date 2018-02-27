using System;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Platform.DataModel.CardDefs;
using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.Platform.DataModel.Mapping
{
	public sealed class KindsDictionaryMapper : BaseDictionaryCardMapper<KindsDictionary>
	{
		public KindsDictionaryMapper() : base(RefKinds.ID) { }

		protected override void MapEntity(EntityTypeBuilder<KindsDictionary> entityBuilder)
		{
			base.MapEntity(entityBuilder);
		}
	}
}