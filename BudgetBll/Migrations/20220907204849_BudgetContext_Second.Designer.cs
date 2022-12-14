// <auto-generated />
using System;
using BudgetBll.DbContextBll;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BudgetBll.Migrations
{
    [DbContext(typeof(BudgetContext))]
    [Migration("20220907204849_BudgetContext_Second")]
    partial class BudgetContext_Second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BudgetInterface.Models.LogEntry", b =>
                {
                    b.Property<int>("LogEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LogEntryId"));

                    b.Property<float>("Bill")
                        .HasColumnType("real");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("boolean");

                    b.Property<int>("PersonWhoPaidId")
                        .HasColumnType("integer");

                    b.Property<int>("ShopId")
                        .HasColumnType("integer");

                    b.HasKey("LogEntryId");

                    b.HasIndex("PersonWhoPaidId");

                    b.HasIndex("ShopId");

                    b.ToTable("LogsEntrie");
                });

            modelBuilder.Entity("BudgetInterface.Models.PersonWhoPaid", b =>
                {
                    b.Property<int>("PersonWhoPaidId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PersonWhoPaidId"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("PersonWhoPaidId");

                    b.ToTable("PeopleWhoPaid");
                });

            modelBuilder.Entity("BudgetInterface.Models.Shop", b =>
                {
                    b.Property<int>("ShopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ShopId"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ShopId");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("BudgetInterface.Models.LogEntry", b =>
                {
                    b.HasOne("BudgetInterface.Models.PersonWhoPaid", "PersonWhoPaid")
                        .WithMany("LogsEntrie")
                        .HasForeignKey("PersonWhoPaidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BudgetInterface.Models.Shop", "Shop")
                        .WithMany("LogsEntrie")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonWhoPaid");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("BudgetInterface.Models.PersonWhoPaid", b =>
                {
                    b.Navigation("LogsEntrie");
                });

            modelBuilder.Entity("BudgetInterface.Models.Shop", b =>
                {
                    b.Navigation("LogsEntrie");
                });
#pragma warning restore 612, 618
        }
    }
}
