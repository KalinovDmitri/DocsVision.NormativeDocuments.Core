using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Platform.DataModel.CardDefs;
using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.Platform.DataModel.Mapping
{
	public abstract class BaseCardSectionRowMapper<TSectionRow> : AbstractEntityMapper<TSectionRow> where TSectionRow : BaseCardSectionRow
	{
		private readonly Guid _sectionID;

		protected internal BaseCardSectionRowMapper(Guid sectionID) : base()
		{
			_sectionID = sectionID;
		}

		protected override void MapEntity(EntityTypeBuilder<TSectionRow> entityBuilder)
		{
			entityBuilder.ToTable(MakeTableName());

			entityBuilder.Property(x => x.Id).HasColumnName("RowID");
			entityBuilder.Property(x => x.ChangeServerID);
			entityBuilder.Property(x => x.OwnServerID);
			entityBuilder.Property(x => x.InstanceID);
			entityBuilder.Property(x => x.ParentRowID);
			entityBuilder.Property(x => x.ParentTreeRowID);
			entityBuilder.Property(x => x.Timestamp).HasColumnName("SysRowTimestamp").IsRowVersion();

			entityBuilder.HasKey(x => x.Id).ForSqlServerIsClustered(false);
		}

		private string MakeTableName()
		{
			return string.Format("dvtable_{{{0}}}", _sectionID);
		}
	}
}