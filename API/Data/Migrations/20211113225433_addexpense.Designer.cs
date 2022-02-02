﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211113225433_addexpense")]
    partial class addexpense
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("API.Entities.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("Interests")
                        .HasColumnType("text");

                    b.Property<string>("Introduction")
                        .HasColumnType("text");

                    b.Property<string>("KnownAs")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LookingFor")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("API.Entities.AppUserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("API.Entities.Connection", b =>
                {
                    b.Property<string>("ConnectionId")
                        .HasColumnType("text");

                    b.Property<string>("GroupName")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("ConnectionId");

                    b.HasIndex("GroupName");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("API.Entities.Expense", b =>
                {
                    b.Property<int>("ExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("AccountDetail")
                        .HasColumnType("text");

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<string>("Employee")
                        .HasColumnType("text");

                    b.Property<DateTime?>("EnterDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ExpenseCategory")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ExpenseDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ExpenseDescription")
                        .HasColumnType("text");

                    b.Property<string>("ExpenseDetail")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("PaidVia")
                        .HasColumnType("text");

                    b.Property<string>("Payee")
                        .HasColumnType("text");

                    b.Property<decimal>("Shipping")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Taxes")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("numeric");

                    b.HasKey("ExpenseId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("API.Entities.Group", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("API.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateRead")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("MessageSent")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("RecipientDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("RecipientId")
                        .HasColumnType("integer");

                    b.Property<string>("RecipientUsername")
                        .HasColumnType("text");

                    b.Property<bool>("SenderDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("SenderId")
                        .HasColumnType("integer");

                    b.Property<string>("SenderUsername")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("API.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("AppUserId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsMain")
                        .HasColumnType("boolean");

                    b.Property<string>("PublicId")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("API.Entities.PoPlan", b =>
                {
                    b.Property<int>("PoPlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("AMS")
                        .HasColumnType("text");

                    b.Property<string>("ArrivalWk")
                        .HasColumnType("text");

                    b.Property<string>("BOL")
                        .HasColumnType("text");

                    b.Property<string>("ContainerExt")
                        .HasColumnType("text");

                    b.Property<string>("ContainerId")
                        .HasColumnType("text");

                    b.Property<string>("CustomerOrderNumber")
                        .HasColumnType("text");

                    b.Property<string>("CustomerPn")
                        .HasColumnType("text");

                    b.Property<string>("Destination")
                        .HasColumnType("text");

                    b.Property<DateTime?>("EtaDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ExtremePn")
                        .HasColumnType("text");

                    b.Property<string>("FreightFowarder")
                        .HasColumnType("text");

                    b.Property<string>("Invoice")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<DateTime?>("OrderDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("OrderQty")
                        .HasColumnType("integer");

                    b.Property<string>("Pallet")
                        .HasColumnType("text");

                    b.Property<string>("PartDescription")
                        .HasColumnType("text");

                    b.Property<decimal>("PartPrice")
                        .HasColumnType("numeric");

                    b.Property<string>("PoConfirmedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("PoConfirmedDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PoLine")
                        .HasColumnType("text");

                    b.Property<string>("PoNumber")
                        .HasColumnType("text");

                    b.Property<string>("PoOrderStatus")
                        .HasColumnType("text");

                    b.Property<string>("PoSentBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("PoSentDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("PromiseDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("ReceiptDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ReceivedQty")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("RequestedDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("ShipDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SoNumber")
                        .HasColumnType("text");

                    b.Property<string>("Supplier")
                        .HasColumnType("text");

                    b.HasKey("PoPlanId");

                    b.ToTable("PoPlans");
                });

            modelBuilder.Entity("API.Entities.Quote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("QuoteDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("QuotedBy")
                        .HasColumnType("text");

                    b.Property<int>("SupplierId")
                        .HasColumnType("integer");

                    b.HasKey("QuoteId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("API.Entities.QuoteDetail", b =>
                {
                    b.Property<int>("QuoteDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<decimal>("Freight")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Labor")
                        .HasColumnType("numeric");

                    b.Property<bool>("LatestQuote")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Material")
                        .HasColumnType("numeric");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("Pn")
                        .HasColumnType("text");

                    b.Property<int>("QuoteId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Tariff")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Weight")
                        .HasColumnType("numeric");

                    b.HasKey("QuoteDetailId");

                    b.HasIndex("QuoteId");

                    b.ToTable("QuoteDetails");
                });

            modelBuilder.Entity("API.Entities.SoPlan", b =>
                {
                    b.Property<int>("SoPlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Carrier")
                        .HasColumnType("text");

                    b.Property<string>("Customer")
                        .HasColumnType("text");

                    b.Property<string>("CustomerOrderLine")
                        .HasColumnType("text");

                    b.Property<string>("CustomerOrderNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CustomerPn")
                        .HasColumnType("text");

                    b.Property<string>("ExtremePn")
                        .HasColumnType("text");

                    b.Property<string>("HotShipment")
                        .HasColumnType("text");

                    b.Property<string>("InvNumber")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<DateTime?>("OrderDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("OrderQty")
                        .HasColumnType("integer");

                    b.Property<string>("PartDescription")
                        .HasColumnType("text");

                    b.Property<DateTime?>("PromiseDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("RequestedDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("ShipDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ShipPlanStatus")
                        .HasColumnType("text");

                    b.Property<int?>("ShipQty")
                        .HasColumnType("integer");

                    b.Property<string>("ShipToAddress")
                        .HasColumnType("text");

                    b.Property<string>("SoNumber")
                        .HasColumnType("text");

                    b.Property<string>("TrackingInfo")
                        .HasColumnType("text");

                    b.Property<string>("WoNumber")
                        .HasColumnType("text");

                    b.HasKey("SoPlanId");

                    b.ToTable("SoPlans");
                });

            modelBuilder.Entity("API.Entities.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("SupplierName")
                        .HasColumnType("text");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("API.Entities.TxQoh", b =>
                {
                    b.Property<int>("TxQohId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Customer")
                        .HasColumnType("text");

                    b.Property<string>("ExtremePn")
                        .HasColumnType("text");

                    b.Property<string>("HtsCode")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("PartDescription")
                        .HasColumnType("text");

                    b.Property<string>("Pn")
                        .HasColumnType("text");

                    b.Property<int>("Qoh")
                        .HasColumnType("integer");

                    b.HasKey("TxQohId");

                    b.ToTable("TxQohs");
                });

            modelBuilder.Entity("API.Entities.UserLike", b =>
                {
                    b.Property<int>("SourceUserId")
                        .HasColumnType("integer");

                    b.Property<int>("LikedUserId")
                        .HasColumnType("integer");

                    b.HasKey("SourceUserId", "LikedUserId");

                    b.HasIndex("LikedUserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("API.Entities.AppUserRole", b =>
                {
                    b.HasOne("API.Entities.AppRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.AppUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Entities.Connection", b =>
                {
                    b.HasOne("API.Entities.Group", null)
                        .WithMany("Connections")
                        .HasForeignKey("GroupName");
                });

            modelBuilder.Entity("API.Entities.Message", b =>
                {
                    b.HasOne("API.Entities.AppUser", "Recipient")
                        .WithMany("MessagesReceived")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Entities.AppUser", "Sender")
                        .WithMany("MessagesSent")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("API.Entities.Photo", b =>
                {
                    b.HasOne("API.Entities.AppUser", "AppUser")
                        .WithMany("Photos")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("API.Entities.Quote", b =>
                {
                    b.HasOne("API.Entities.Supplier", "Supplier")
                        .WithMany("Quotes")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("API.Entities.QuoteDetail", b =>
                {
                    b.HasOne("API.Entities.Quote", "Quote")
                        .WithMany("QuoteDetails")
                        .HasForeignKey("QuoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quote");
                });

            modelBuilder.Entity("API.Entities.UserLike", b =>
                {
                    b.HasOne("API.Entities.AppUser", "LikedUser")
                        .WithMany("LikedByUsers")
                        .HasForeignKey("LikedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.AppUser", "SourceUser")
                        .WithMany("LikedUsers")
                        .HasForeignKey("SourceUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LikedUser");

                    b.Navigation("SourceUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("API.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("API.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("API.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("API.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Entities.AppRole", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Navigation("LikedByUsers");

                    b.Navigation("LikedUsers");

                    b.Navigation("MessagesReceived");

                    b.Navigation("MessagesSent");

                    b.Navigation("Photos");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("API.Entities.Group", b =>
                {
                    b.Navigation("Connections");
                });

            modelBuilder.Entity("API.Entities.Quote", b =>
                {
                    b.Navigation("QuoteDetails");
                });

            modelBuilder.Entity("API.Entities.Supplier", b =>
                {
                    b.Navigation("Quotes");
                });
#pragma warning restore 612, 618
        }
    }
}
