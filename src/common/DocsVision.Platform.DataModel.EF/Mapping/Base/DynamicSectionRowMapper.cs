using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.Platform.DataModel.Mapping
{
	public abstract class DynamicSectionRowMapper<TSectionRow> : AbstractEntityMapper<TSectionRow> where TSectionRow : BaseCardSectionRow
	{
		private readonly Guid _cardTypeID;
		private readonly string _sectionAlias;

		private string _tableName;

		public override bool ShouldResolveMetadata => true;

		protected internal DynamicSectionRowMapper(Guid cardTypeID, string sectionAlias) : base()
		{
			_cardTypeID = cardTypeID;
			_sectionAlias = sectionAlias;
		}

		public override void ResolveMetadata(IMetadataProvider metadataProvider)
		{
			Guid sectionID = metadataProvider.GetSectionID(_cardTypeID, _sectionAlias);

			if (sectionID == Guid.Empty)
			{
				throw new InvalidOperationException($"Section with alias '{_sectionAlias}' does not exist.");
			}

			_tableName = string.Format("dvtable_{{{0}}}", sectionID);
		}

		protected override void MapEntity(EntityTypeBuilder<TSectionRow> entityBuilder)
		{
			entityBuilder.ToTable(_tableName);

			entityBuilder.Property(x => x.Id).HasColumnName("RowID");
			entityBuilder.Property(x => x.ChangeServerID);
			entityBuilder.Property(x => x.OwnServerID);
			entityBuilder.Property(x => x.InstanceID);
			entityBuilder.Property(x => x.ParentRowID);
			entityBuilder.Property(x => x.ParentTreeRowID);
			entityBuilder.Property(x => x.Timestamp).HasColumnName("SysRowTimestamp").IsRowVersion();

			entityBuilder.HasKey(x => x.Id).ForSqlServerIsClustered(false);
		}
	}
}