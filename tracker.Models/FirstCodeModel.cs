namespace tracker.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FirstCodeModel : DbContext
    {
        public FirstCodeModel()
            : base("name=FirstCodeModel")
        {
        }

        public virtual DbSet<affiliate> affiliate { get; set; }
        public virtual DbSet<AffiliateParameter> AffiliateParameter { get; set; }
        public virtual DbSet<AffiliateSource> AffiliateSource { get; set; }
        public virtual DbSet<AppEvent> AppEvent { get; set; }
        public virtual DbSet<appName> appName { get; set; }
        public virtual DbSet<campaign> campaign { get; set; }
        public virtual DbSet<campaign_offer> campaign_offer { get; set; }
        public virtual DbSet<CampaignLog> CampaignLog { get; set; }
        public virtual DbSet<campaignPath> campaignPath { get; set; }
        public virtual DbSet<click> click { get; set; }
        public virtual DbSet<clickCount> clickCount { get; set; }
        public virtual DbSet<clickIdByname> clickIdByname { get; set; }
        public virtual DbSet<country> country { get; set; }
        public virtual DbSet<domain> domain { get; set; }
        public virtual DbSet<ifa> ifa { get; set; }
        public virtual DbSet<ip> ip { get; set; }
        public virtual DbSet<ipDB> ipDB { get; set; }
        public virtual DbSet<languageDB> languageDB { get; set; }
        public virtual DbSet<loginHistory> loginHistory { get; set; }
        public virtual DbSet<LWCallback> LWCallback { get; set; }
        public virtual DbSet<MediaBuy_Campaign> MediaBuy_Campaign { get; set; }
        public virtual DbSet<MediaBuyLink> MediaBuyLink { get; set; }
        public virtual DbSet<offer> offer { get; set; }
        public virtual DbSet<offerDayStatistics> offerDayStatistics { get; set; }
        public virtual DbSet<offerReportList> offerReportList { get; set; }
        public virtual DbSet<offerSource> offerSource { get; set; }
        public virtual DbSet<postbackPath> postbackPath { get; set; }
        public virtual DbSet<siteDomain> siteDomain { get; set; }
        public virtual DbSet<siteId> siteId { get; set; }
        public virtual DbSet<source> source { get; set; }
        public virtual DbSet<Sources> Sources { get; set; }
        public virtual DbSet<SourcesItem> SourcesItem { get; set; }
        public virtual DbSet<trafficSource> trafficSource { get; set; }
        public virtual DbSet<uaDB> uaDB { get; set; }
        public virtual DbSet<user> user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<affiliate>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<AppEvent>()
                .Property(e => e.clickid)
                .IsUnicode(false);

            modelBuilder.Entity<AppEvent>()
                .Property(e => e.eventID)
                .IsUnicode(false);

            modelBuilder.Entity<AppEvent>()
                .Property(e => e.ts)
                .IsUnicode(false);

            modelBuilder.Entity<appName>()
                .Property(e => e.val)
                .IsUnicode(false);

            modelBuilder.Entity<appName>()
                .Property(e => e.pkg_name)
                .IsUnicode(false);

            modelBuilder.Entity<appName>()
                .Property(e => e.pkg_id)
                .IsUnicode(false);

            modelBuilder.Entity<campaign>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<campaign>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<campaign>()
                .Property(e => e.redirect)
                .IsUnicode(false);

            modelBuilder.Entity<campaign>()
                .Property(e => e.brush)
                .IsUnicode(false);

            modelBuilder.Entity<campaign>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<campaign>()
                .Property(e => e.tag)
                .IsUnicode(false);

            modelBuilder.Entity<campaign>()
                .Property(e => e.conversion)
                .IsUnicode(false);

            modelBuilder.Entity<campaign>()
                .Property(e => e.domain)
                .IsUnicode(false);

            modelBuilder.Entity<campaign>()
                .Property(e => e.campaignPath)
                .IsUnicode(false);

            modelBuilder.Entity<CampaignLog>()
                .Property(e => e.TS)
                .IsUnicode(false);

            modelBuilder.Entity<campaignPath>()
                .Property(e => e.val)
                .IsUnicode(false);

            modelBuilder.Entity<click>()
                .Property(e => e.clickid)
                .IsUnicode(false);

            modelBuilder.Entity<click>()
                .Property(e => e.siteDomain)
                .IsUnicode(false);

            modelBuilder.Entity<click>()
                .Property(e => e.ifa)
                .IsUnicode(false);

            modelBuilder.Entity<click>()
                .Property(e => e.ip)
                .IsUnicode(false);

            modelBuilder.Entity<click>()
                .Property(e => e.dspSsp)
                .IsUnicode(false);

            modelBuilder.Entity<click>()
                .Property(e => e.siteId)
                .IsUnicode(false);

            modelBuilder.Entity<click>()
                .Property(e => e.appName)
                .IsUnicode(false);

            modelBuilder.Entity<click>()
                .Property(e => e.remainID)
                .IsUnicode(false);

            modelBuilder.Entity<click>()
                .Property(e => e.conversionTS)
                .IsUnicode(false);

            modelBuilder.Entity<click>()
                .Property(e => e.ua)
                .IsUnicode(false);

            modelBuilder.Entity<click>()
                .Property(e => e.lang)
                .IsUnicode(false);

            modelBuilder.Entity<clickCount>()
                .Property(e => e.TS)
                .IsUnicode(false);

            modelBuilder.Entity<clickIdByname>()
                .Property(e => e.val)
                .IsUnicode(false);

            modelBuilder.Entity<country>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<domain>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<domain>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<domain>()
                .Property(e => e.postbackUrl)
                .IsUnicode(false);

            modelBuilder.Entity<domain>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<domain>()
                .Property(e => e.track)
                .IsUnicode(false);

            modelBuilder.Entity<ifa>()
                .Property(e => e.val)
                .IsUnicode(false);

            modelBuilder.Entity<ip>()
                .Property(e => e.val)
                .IsUnicode(false);

            modelBuilder.Entity<ipDB>()
                .Property(e => e.ip)
                .IsUnicode(false);

            modelBuilder.Entity<ipDB>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<languageDB>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<LWCallback>()
                .Property(e => e.idfa)
                .IsUnicode(false);

            modelBuilder.Entity<MediaBuyLink>()
                .Property(e => e.launchLink)
                .IsUnicode(false);

            modelBuilder.Entity<MediaBuyLink>()
                .Property(e => e.trafficName)
                .IsUnicode(false);

            modelBuilder.Entity<MediaBuyLink>()
                .Property(e => e.linkcode)
                .IsUnicode(false);

            modelBuilder.Entity<offer>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<offer>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<offer>()
                .Property(e => e.tag)
                .IsUnicode(false);

            modelBuilder.Entity<offer>()
                .Property(e => e.source)
                .IsUnicode(false);

            modelBuilder.Entity<offer>()
                .Property(e => e.scope)
                .IsUnicode(false);

            modelBuilder.Entity<offer>()
                .Property(e => e.impUrl)
                .IsUnicode(false);

            modelBuilder.Entity<offerReportList>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<offerReportList>()
                .Property(e => e.recordDate)
                .IsUnicode(false);

            modelBuilder.Entity<offerSource>()
                .Property(e => e.sourceVal)
                .IsUnicode(false);

            modelBuilder.Entity<offerSource>()
                .Property(e => e.itemVal)
                .IsUnicode(false);

            modelBuilder.Entity<postbackPath>()
                .Property(e => e.val)
                .IsUnicode(false);

            modelBuilder.Entity<siteDomain>()
                .Property(e => e.val)
                .IsUnicode(false);

            modelBuilder.Entity<siteId>()
                .Property(e => e.val)
                .IsUnicode(false);

            modelBuilder.Entity<source>()
                .Property(e => e.val)
                .IsUnicode(false);

            modelBuilder.Entity<Sources>()
                .Property(e => e.source)
                .IsUnicode(false);

            modelBuilder.Entity<Sources>()
                .Property(e => e.tag)
                .IsUnicode(false);

            modelBuilder.Entity<SourcesItem>()
                .Property(e => e.item)
                .IsUnicode(false);

            modelBuilder.Entity<trafficSource>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<trafficSource>()
                .Property(e => e.param)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.ticket)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.role)
                .IsUnicode(false);
        }
    }
}
