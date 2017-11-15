using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DocsVision.Platform.DataModel
{
	public class DocsVisionContext : DbContext
	{
		public DocsVisionContext(DbContextOptions options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			IMetadataProvider metadataProvider = this.GetService<IMetadataProvider>();
			DocsVisionSchema databaseSchema = this.GetService<DocsVisionSchema>();

			databaseSchema.BuildModel(metadataProvider, modelBuilder);
		}
	}
}