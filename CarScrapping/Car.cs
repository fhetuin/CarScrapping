using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarScrapping
{
    public class Car
    {
        public string Title { get; set; }
        public string Brand { get; set; }
        public string Carburation { get; set; }
        public string GearBox { get; set; }
        public string Miles { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }

        public List<byte[]> Images { get; set; }

    }

    public class Advertiser
    {
        [JsonProperty("company_info")]
        public string CompanyInfo { get; set; }

        [JsonProperty("contact_methods")]
        public ContactMethods ContactMethods { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("store_name")]
        public string StoreName { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class ApiKeywords
    {
        [JsonProperty("aa-sch-country_code")]
        public List<string> AaSchCountryCode { get; set; }

        [JsonProperty("aa-sch-publisher")]
        public List<string> AaSchPublisher { get; set; }

        [JsonProperty("se-blocket-adid")]
        public List<string> SeBlocketAdid { get; set; }

        [JsonProperty("se-blocket-adtitle")]
        public List<string> SeBlocketAdtitle { get; set; }

        [JsonProperty("se-blocket-adtype")]
        public List<string> SeBlocketAdtype { get; set; }

        [JsonProperty("se-blocket-companyad")]
        public List<string> SeBlocketCompanyad { get; set; }

        [JsonProperty("se-blocket-country")]
        public List<string> SeBlocketCountry { get; set; }

        [JsonProperty("se-blocket-county")]
        public List<string> SeBlocketCounty { get; set; }

        [JsonProperty("se-blocket-itemimage")]
        public List<string> SeBlocketItemimage { get; set; }

        [JsonProperty("se-blocket-itemsecuredthumb")]
        public List<string> SeBlocketItemsecuredthumb { get; set; }

        [JsonProperty("se-blocket-itemthumb")]
        public List<string> SeBlocketItemthumb { get; set; }

        [JsonProperty("se-blocket-mileage")]
        public List<string> SeBlocketMileage { get; set; }

        [JsonProperty("se-blocket-model")]
        public List<string> SeBlocketModel { get; set; }

        [JsonProperty("se-blocket-municipality")]
        public List<string> SeBlocketMunicipality { get; set; }

        [JsonProperty("se-blocket-section")]
        public List<string> SeBlocketSection { get; set; }

        [JsonProperty("se-blocket-services")]
        public List<object> SeBlocketServices { get; set; }

        [JsonProperty("se-blocket-storeid")]
        public List<string> SeBlocketStoreid { get; set; }

        [JsonProperty("se-blocket-type")]
        public List<string> SeBlocketType { get; set; }

        [JsonProperty("se-generic-appmode")]
        public List<string> SeGenericAppmode { get; set; }

        [JsonProperty("se-generic-brand")]
        public List<string> SeGenericBrand { get; set; }

        [JsonProperty("se-generic-dealerhasownfinance")]
        public List<string> SeGenericDealerhasownfinance { get; set; }

        [JsonProperty("se-generic-fueltype")]
        public List<string> SeGenericFueltype { get; set; }

        [JsonProperty("se-generic-gearbox")]
        public List<string> SeGenericGearbox { get; set; }

        [JsonProperty("se-generic-id")]
        public List<string> SeGenericId { get; set; }

        [JsonProperty("se-generic-lkf")]
        public List<string> SeGenericLkf { get; set; }

        [JsonProperty("se-generic-modelyear")]
        public List<string> SeGenericModelyear { get; set; }

        [JsonProperty("se-generic-page")]
        public List<string> SeGenericPage { get; set; }

        [JsonProperty("se-generic-price")]
        public List<string> SeGenericPrice { get; set; }

        [JsonProperty("se-generic-section")]
        public List<string> SeGenericSection { get; set; }
    }

    public class Appnexus
    {
        [JsonProperty("api_keywords")]
        public ApiKeywords ApiKeywords { get; set; }

        [JsonProperty("client_keywords")]
        public ClientKeywords ClientKeywords { get; set; }

        [JsonProperty("allowed_formats")]
        public List<string> AllowedFormats { get; set; }

        [JsonProperty("inventory_code")]
        public string InventoryCode { get; set; }

        [JsonProperty("keywords")]
        public Keywords Keywords { get; set; }

        [JsonProperty("member")]
        public int Member { get; set; }

        [JsonProperty("sizes")]
        public string Sizes { get; set; }

        [JsonProperty("target_id")]
        public string TargetId { get; set; }
    }

    public class Attribute
    {
        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("items")]
        public List<string> Items { get; set; }
    }

    public class BlocketPackage
    {
        [JsonProperty("activated_providers")]
        public List<object> ActivatedProviders { get; set; }

        [JsonProperty("ad_id")]
        public string AdId { get; set; }

        [JsonProperty("blocket_payment_backwards_compatability")]
        public object BlocketPaymentBackwardsCompatability { get; set; }

        [JsonProperty("buyers_protection_fee")]
        public object BuyersProtectionFee { get; set; }

        [JsonProperty("eligible_providers")]
        public List<object> EligibleProviders { get; set; }

        [JsonProperty("fail_code")]
        public object FailCode { get; set; }

        [JsonProperty("failure")]
        public object Failure { get; set; }

        [JsonProperty("feature_swish")]
        public bool FeatureSwish { get; set; }

        [JsonProperty("features")]
        public Features Features { get; set; }

        [JsonProperty("is_in_dispute")]
        public bool IsInDispute { get; set; }

        [JsonProperty("partner")]
        public string Partner { get; set; }

        [JsonProperty("payment_methods")]
        public List<object> PaymentMethods { get; set; }

        [JsonProperty("payment_request_entrance")]
        public object PaymentRequestEntrance { get; set; }

        [JsonProperty("payment_url")]
        public object PaymentUrl { get; set; }

        [JsonProperty("service_data")]
        public object ServiceData { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("transaction_dates")]
        public object TransactionDates { get; set; }

        [JsonProperty("urls")]
        public Urls Urls { get; set; }
    }

    public class Category
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ClientKeywords
    {
        [JsonProperty("logged_in")]
        public string LoggedIn { get; set; }

        [JsonProperty("page_gen")]
        public string PageGen { get; set; }

        [JsonProperty("ppid_1")]
        public string Ppid1 { get; set; }

        [JsonProperty("ppid_2")]
        public string Ppid2 { get; set; }

        [JsonProperty("screen_height")]
        public string ScreenHeight { get; set; }

        [JsonProperty("screen_width")]
        public string ScreenWidth { get; set; }

        [JsonProperty("site_mode")]
        public string SiteMode { get; set; }

        [JsonProperty("supply_type")]
        public string SupplyType { get; set; }

        [JsonProperty("viewport_height")]
        public string ViewportHeight { get; set; }

        [JsonProperty("viewport_width")]
        public string ViewportWidth { get; set; }
    }

    public class ContactMethods
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public bool Phone { get; set; }
    }

    public class Context
    {
        [JsonProperty("appnexus")]
        public Appnexus Appnexus { get; set; }
    }

    public class Data
    {
        [JsonProperty("ad_id")]
        public string AdId { get; set; }

        [JsonProperty("ad_status")]
        public string AdStatus { get; set; }

        [JsonProperty("advertiser")]
        public Advertiser Advertiser { get; set; }

        [JsonProperty("attributes")]
        public List<Attribute> Attributes { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("category")]
        public List<Category> Category { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("license_plate")]
        public string LicensePlate { get; set; }

        [JsonProperty("list_id")]
        public string ListId { get; set; }

        [JsonProperty("list_time")]
        public DateTime ListTime { get; set; }

        [JsonProperty("location")]
        public List<Location> Location { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("map_url")]
        public string MapUrl { get; set; }

        [JsonProperty("parameter_groups")]
        public List<ParameterGroup> ParameterGroups { get; set; }

        [JsonProperty("parameters_raw")]
        public ParametersRaw ParametersRaw { get; set; }

        [JsonProperty("partner_info")]
        public PartnerInfo PartnerInfo { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("share_url")]
        public string ShareUrl { get; set; }

        [JsonProperty("state_id")]
        public string StateId { get; set; }

        [JsonProperty("store")]
        public Store Store { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("blocket_package")]
        public BlocketPackage BlocketPackage { get; set; }

        [JsonProperty("direct_purchase")]
        public DirectPurchase DirectPurchase { get; set; }
    }

    public class DirectPurchase
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Features
    {
        [JsonProperty("is_part_of_merge")]
        public bool IsPartOfMerge { get; set; }
    }

    public class Image
    {
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }

    public class Image2
    {
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }

    public class Inventory
    {
        [JsonProperty("context")]
        public Context Context { get; set; }

        [JsonProperty("placements")]
        public List<Placement> Placements { get; set; }
    }

    public class Keywords
    {
        [JsonProperty("se-generic-adformat")]
        public List<string> SeGenericAdformat { get; set; }

        [JsonProperty("se-generic-adsize")]
        public List<string> SeGenericAdsize { get; set; }
    }

    public class Link
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Link2
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Location
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("query_key")]
        public string QueryKey { get; set; }
    }

    public class Logo
    {
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }

    public class MotorDirectPurchase
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class MotorHasFinance
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Parameter
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("suffix")]
        public string Suffix { get; set; }
    }

    public class ParameterGroup
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("parameters")]
        public List<Parameter> Parameters { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class ParametersRaw
    {
        [JsonProperty("motor_direct_purchase")]
        public MotorDirectPurchase MotorDirectPurchase { get; set; }

        [JsonProperty("motor_has_finance")]
        public MotorHasFinance MotorHasFinance { get; set; }
    }

    public class Partner
    {
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("icon_png")]
        public string IconPng { get; set; }

        [JsonProperty("icon_svg")]
        public string IconSvg { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("is_advertisement")]
        public bool IsAdvertisement { get; set; }

        [JsonProperty("link")]
        public Link Link { get; set; }

        [JsonProperty("tracking_creative")]
        public string TrackingCreative { get; set; }

        [JsonProperty("tracking_position")]
        public string TrackingPosition { get; set; }
    }

    public class PartnerInfo
    {
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Phone
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("phone_number_itu")]
        public string PhoneNumberItu { get; set; }
    }

    public class Placement
    {
        [JsonProperty("appnexus")]
        public Appnexus Appnexus { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("vendor")]
        public string Vendor { get; set; }

        [JsonProperty("viewport")]
        public string Viewport { get; set; }

        [JsonProperty("safe_purchase")]
        public SafePurchase SafePurchase { get; set; }
    }

    public class Price
    {
        [JsonProperty("suffix")]
        public string Suffix { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("value_without_vat")]
        public int ValueWithoutVat { get; set; }
    }

    public class Root
    {
        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("inventory")]
        public Inventory Inventory { get; set; }
    }

    public class SafePurchase
    {
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("links")]
        public List<Link> Links { get; set; }

        [JsonProperty("partners")]
        public List<Partner> Partners { get; set; }
    }

    public class Store
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("blocket_url")]
        public string BlocketUrl { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("full_address")]
        public string FullAddress { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("logo")]
        public Logo Logo { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public Phone Phone { get; set; }

        [JsonProperty("store_id")]
        public string StoreId { get; set; }

        [JsonProperty("store_type")]
        public string StoreType { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_path")]
        public string UrlPath { get; set; }

        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }
    }

    public class Urls
    {
        [JsonProperty("seller_activate")]
        public string SellerActivate { get; set; }
    }


}
