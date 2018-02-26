using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DocsVision.Platform.DataModel.Entities;
using DocsVision.Platform.DataModel.Mapping;

namespace DocsVision.Platform.DataModel
{
	internal class MetadataContext : DbContext
	{
		public MetadataContext(DbContextOptions options) : base(options) { }
				
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			new CardLibraryMapper().Map(modelBuilder);
			new CardTypeMapper().Map(modelBuilder);
			new CardSectionMapper().Map(modelBuilder);
		}
	}
}