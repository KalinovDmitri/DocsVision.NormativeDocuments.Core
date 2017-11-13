using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.Platform.DataModel.Mapping
{
	internal class BaseCardMapper : IEntityMapper
	{
		private readonly Func<IDictionary<Type, Guid>> _discriminatorsFactory;

		public bool ShouldResolveMetadata => false;

		public BaseCardMapper(Func<IDictionary<Type, Guid>> discriminatorsFactory)
		{
			if (discriminatorsFactory == null)
			{
				throw new ArgumentNullException(nameof(discriminatorsFactory), "Discriminators factory cannot be null.");
			}

			_discriminatorsFactory = discriminatorsFactory;
		}

		public void Map(ModelBuilder modelBuilder)
		{
			var entityBuilder = modelBuilder.Entity<BaseCard>().ToTable("dvsys_instances");
			
			entityBuilder.Property(x => x.Id).HasColumnName("InstanceID");
			entityBuilder.Property(x => x.ArchiveState);
			entityBuilder.Property(x => x.Barcode);
			entityBuilder.Property(x => x.CardTypeID);
			entityBuilder.Property(x => x.Deleted);
			entityBuilder.Property(x => x.Description);
			entityBuilder.Property(x => x.IconID);
			entityBuilder.Property(x => x.Order);
			entityBuilder.Property(x => x.ParentID);
			entityBuilder.Property(x => x.SDID);
			entityBuilder.Property(x => x.Status);
			entityBuilder.Property(x => x.Template);
			entityBuilder.Property(x => x.Timestamp).IsRowVersion();
			entityBuilder.Property(x => x.TopicID);
			entityBuilder.Property(x => x.TopicIndex);

			entityBuilder.HasKey(x => x.Id)
				.ForSqlServerIsClustered(false)
				.HasName("dvsys_instances_pk_instanceid");

			entityBuilder.HasOne(x => x.Dates).WithOne()
				.HasForeignKey<BaseCardDates>(x => x.Id)
				.HasPrincipalKey<BaseCard>(x => x.Id);

			entityBuilder.HasOne(x => x.SystemInfo).WithOne()
				.HasForeignKey<BaseCardSystemInfo>(x => x.InstanceID)
				.HasPrincipalKey<BaseCard>(x => x.Id);

			entityBuilder.HasOne(x => x.Security).WithMany()
				.HasForeignKey(x => x.SDID)
				.HasPrincipalKey(x => x.Id);

			entityBuilder.HasOne(x => x.Type).WithMany()
				.HasForeignKey(x => x.CardTypeID)
				.HasPrincipalKey(x => x.Id);

			var discriminatorBuilder = entityBuilder.HasDiscriminator(x => x.CardTypeID);

			var discriminators = _discriminatorsFactory.Invoke();
			foreach (var discriminatorPair in discriminators)
			{
				discriminatorBuilder.HasValue(discriminatorPair.Key, discriminatorPair.Value);
			}
		}

		public void ResolveMetadata(IMetadataProvider metadataProvider) { }

		public void Visit(IEntityMapperVisitor visitor) { }
	}
}