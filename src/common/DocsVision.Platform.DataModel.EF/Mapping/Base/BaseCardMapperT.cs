using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Platform.DataModel.Entities;

namespace DocsVision.Platform.DataModel.Mapping
{
	public abstract class BaseCardMapper<TCard> : AbstractEntityMapper<TCard>, ICardMapper where TCard : BaseCard
	{
		public Type CardType => typeof(TCard);

		public Guid CardTypeID { get; }

		protected internal BaseCardMapper(Guid typeID) : base()
		{
			if (typeID == Guid.Empty)
			{
				throw new ArgumentOutOfRangeException(nameof(typeID), $"Card type ID cannot be equal to '{Guid.Empty}'.");
			}

			CardTypeID = typeID;
		}

		public override void Visit(IEntityMapperVisitor visitor)
		{
			visitor.Visit(this);
		}

		protected override void MapEntity(EntityTypeBuilder<TCard> entityBuilder)
		{
			entityBuilder.ToTable("dvsys_instances").HasBaseType<BaseCard>();
		}
	}
}