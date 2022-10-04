using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Supabase.Microservices.Models.Entities;

namespace Supabase.Microservices.Context
{
    public partial class JiraDbContext : DbContext
    {
        public JiraDbContext()
        {
        }

        public JiraDbContext(DbContextOptions<JiraDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TaskInfo> TaskInfos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum("graphql", "cardinality", new[] { "ONE", "MANY" })
                .HasPostgresEnum("graphql", "column_order_direction", new[] { "asc", "desc" })
                .HasPostgresEnum("graphql", "comparison_op", new[] { "=", "<", "<=", "<>", ">=", ">", "in" })
                .HasPostgresEnum("graphql", "field_meta_kind", new[] { "Constant", "Query.collection", "Column", "Relationship.toMany", "Relationship.toOne", "OrderBy.Column", "Filter.Column", "Function", "Mutation.insert", "Mutation.delete", "Mutation.update", "UpdateSetArg", "ObjectsArg", "AtMostArg", "Query.heartbeat", "Query.__schema", "Query.__type", "__Typename" })
                .HasPostgresEnum("graphql", "meta_kind", new[] { "__Schema", "__Type", "__TypeKind", "__Field", "__InputValue", "__EnumValue", "__Directive", "__DirectiveLocation", "ID", "Float", "String", "Int", "Boolean", "Date", "Time", "Datetime", "BigInt", "UUID", "JSON", "OrderByDirection", "PageInfo", "Cursor", "Query", "Mutation", "Interface", "Node", "Edge", "Connection", "OrderBy", "FilterEntity", "InsertNode", "UpdateNode", "InsertNodeResponse", "UpdateNodeResponse", "DeleteNodeResponse", "FilterType", "Enum" })
                .HasPostgresEnum("graphql", "type_kind", new[] { "SCALAR", "OBJECT", "INTERFACE", "UNION", "ENUM", "INPUT_OBJECT", "LIST", "NON_NULL" })
                .HasPostgresEnum("pgsodium", "key_status", new[] { "default", "valid", "invalid", "expired" })
                .HasPostgresEnum("pgsodium", "key_type", new[] { "aead-ietf", "aead-det" })
                .HasPostgresExtension("extensions", "pg_graphql")
                .HasPostgresExtension("extensions", "pg_stat_statements")
                .HasPostgresExtension("extensions", "pgcrypto")
                .HasPostgresExtension("extensions", "pgjwt")
                .HasPostgresExtension("extensions", "uuid-ossp")
                .HasPostgresExtension("pgsodium", "pgsodium");

            modelBuilder.Entity<TaskInfo>(entity =>
            {
                entity.ToTable("TASK_INFO");

                entity.HasComment("Task table");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AcceptanceCriteria)
                    .HasColumnType("character varying")
                    .HasColumnName("ACCEPTANCE_CRITERIA");

                entity.Property(e => e.Completed).HasColumnName("COMPLETED");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("character varying")
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDatetime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("CREATED_DATETIME");

                entity.Property(e => e.Description)
                    .HasColumnType("character varying")
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Nfr)
                    .HasColumnType("character varying")
                    .HasColumnName("NFR");

                entity.Property(e => e.OriginalEstimate).HasColumnName("ORIGINAL_ESTIMATE");

                entity.Property(e => e.Priority)
                    .HasColumnType("character varying")
                    .HasColumnName("PRIORITY");

                entity.Property(e => e.Remaining).HasColumnName("REMAINING");

                entity.Property(e => e.Status)
                    .HasColumnType("character varying")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Title)
                    .HasColumnType("character varying")
                    .HasColumnName("TITLE");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnType("character varying")
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDatetime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("UPDATED_DATETIME");
            });

            modelBuilder.HasSequence<int>("seq_schema_version", "graphql").IsCyclic();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
