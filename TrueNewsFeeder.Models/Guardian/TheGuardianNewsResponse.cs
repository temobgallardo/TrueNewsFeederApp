using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TrueNewsFeeder.Models.Guardian
{
    public class Fields
    {
        [JsonProperty("headline")]
        public string Headline { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }

    public class Tag
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("webTitle")]
        public string WebTitle { get; set; }

        [JsonProperty("webUrl")]
        public string WebUrl { get; set; }

        [JsonProperty("apiUrl")]
        public string ApiUrl { get; set; }

        [JsonProperty("references")]
        public IList<object> References { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("bylineImageUrl")]
        public string BylineImageUrl { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("twitterHandle")]
        public string TwitterHandle { get; set; }

        [JsonProperty("bylineLargeImageUrl")]
        public string BylineLargeImageUrl { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
    }

    public class Attributes
    {
    }

    public class TypeData
    {
        [JsonProperty("aspectRatio")]
        public string AspectRatio { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("isMaster")]
        public bool? IsMaster { get; set; }

        [JsonProperty("secureFile")]
        public string SecureFile { get; set; }
    }

    public class Asset
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("mimeType")]
        public string MimeType { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }

        [JsonProperty("typeData")]
        public TypeData TypeData { get; set; }
    }

    public class TextTypeData
    {
        [JsonProperty("html")]
        public string Html { get; set; }
    }

    public class ContentAtomTypeData
    {
        [JsonProperty("atomId")]
        public string AtomId { get; set; }

        [JsonProperty("atomType")]
        public string AtomType { get; set; }
    }

    public class ImageTypeData
    {
        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("displayCredit")]
        public bool DisplayCredit { get; set; }

        [JsonProperty("credit")]
        public string Credit { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("alt")]
        public string Alt { get; set; }

        [JsonProperty("mediaId")]
        public string MediaId { get; set; }

        [JsonProperty("mediaApiUri")]
        public string MediaApiUri { get; set; }

        [JsonProperty("imageType")]
        public string ImageType { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("photographer")]
        public string Photographer { get; set; }

        [JsonProperty("suppliersReference")]
        public string SuppliersReference { get; set; }
    }

    public class EmbedTypeData
    {
        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("alt")]
        public string Alt { get; set; }

        [JsonProperty("safeEmbedCode")]
        public bool? SafeEmbedCode { get; set; }

        [JsonProperty("isMandatory")]
        public bool? IsMandatory { get; set; }
    }

    public class PullquoteTypeData
    {
        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("attribution")]
        public string Attribution { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }

    public class InteractiveTypeData
    {
        [JsonProperty("originalUrl")]
        public string OriginalUrl { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("alt")]
        public string Alt { get; set; }

        [JsonProperty("scriptUrl")]
        public string ScriptUrl { get; set; }

        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("scriptName")]
        public string ScriptName { get; set; }

        [JsonProperty("iframeUrl")]
        public string IframeUrl { get; set; }

        [JsonProperty("isMandatory")]
        public bool IsMandatory { get; set; }
    }

    public class RichLinkTypeData
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("originalUrl")]
        public string OriginalUrl { get; set; }

        [JsonProperty("linkText")]
        public string LinkText { get; set; }

        [JsonProperty("linkPrefix")]
        public string LinkPrefix { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }

    public class VideoTypeData
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("credit")]
        public string Credit { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("originalUrl")]
        public string OriginalUrl { get; set; }
    }

    public class TweetTypeData
    {
        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("originalUrl")]
        public string OriginalUrl { get; set; }
    }

    public class MembershipTypeData
    {
        [JsonProperty("originalUrl")]
        public string OriginalUrl { get; set; }

        [JsonProperty("linkText")]
        public string LinkText { get; set; }

        [JsonProperty("linkPrefix")]
        public string LinkPrefix { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("start")]
        public DateTime Start { get; set; }

        [JsonProperty("end")]
        public DateTime End { get; set; }
    }

    public class Element
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("assets")]
        public IList<Asset> Assets { get; set; }

        [JsonProperty("textTypeData")]
        public TextTypeData TextTypeData { get; set; }

        [JsonProperty("contentAtomTypeData")]
        public ContentAtomTypeData ContentAtomTypeData { get; set; }

        [JsonProperty("imageTypeData")]
        public ImageTypeData ImageTypeData { get; set; }

        [JsonProperty("embedTypeData")]
        public EmbedTypeData EmbedTypeData { get; set; }

        [JsonProperty("pullquoteTypeData")]
        public PullquoteTypeData PullquoteTypeData { get; set; }

        [JsonProperty("interactiveTypeData")]
        public InteractiveTypeData InteractiveTypeData { get; set; }

        [JsonProperty("richLinkTypeData")]
        public RichLinkTypeData RichLinkTypeData { get; set; }

        [JsonProperty("videoTypeData")]
        public VideoTypeData VideoTypeData { get; set; }

        [JsonProperty("tweetTypeData")]
        public TweetTypeData TweetTypeData { get; set; }

        [JsonProperty("membershipTypeData")]
        public MembershipTypeData MembershipTypeData { get; set; }
    }

    public class Body
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("bodyHtml")]
        public string BodyHtml { get; set; }

        [JsonProperty("bodyTextSummary")]
        public string BodyTextSummary { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }

        [JsonProperty("published")]
        public bool Published { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("firstPublishedDate")]
        public DateTime FirstPublishedDate { get; set; }

        [JsonProperty("publishedDate")]
        public DateTime PublishedDate { get; set; }

        [JsonProperty("lastModifiedDate")]
        public DateTime LastModifiedDate { get; set; }

        [JsonProperty("contributors")]
        public IList<object> Contributors { get; set; }

        [JsonProperty("elements")]
        public IList<Element> Elements { get; set; }
    }

    public class Blocks
    {
        [JsonProperty("body")]
        public IList<Body> Body { get; set; }

        [JsonProperty("totalBodyBlocks")]
        public int TotalBodyBlocks { get; set; }
    }

    public class Result
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("sectionId")]
        public string SectionId { get; set; }

        [JsonProperty("sectionName")]
        public string SectionName { get; set; }

        [JsonProperty("webPublicationDate")]
        public DateTime WebPublicationDate { get; set; }

        [JsonProperty("webTitle")]
        public string WebTitle { get; set; }

        [JsonProperty("webUrl")]
        public string WebUrl { get; set; }

        [JsonProperty("apiUrl")]
        public string ApiUrl { get; set; }

        [JsonProperty("fields")]
        public Fields Fields { get; set; }

        [JsonProperty("tags")]
        public IList<Tag> Tags { get; set; }

        [JsonProperty("blocks")]
        public Blocks Blocks { get; set; }

        [JsonProperty("isHosted")]
        public bool IsHosted { get; set; }

        [JsonProperty("pillarId")]
        public string PillarId { get; set; }

        [JsonProperty("pillarName")]
        public string PillarName { get; set; }
    }

    public class Response
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("userTier")]
        public string UserTier { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("startIndex")]
        public int StartIndex { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }

        [JsonProperty("pages")]
        public int Pages { get; set; }

        [JsonProperty("orderBy")]
        public string OrderBy { get; set; }

        [JsonProperty("results")]
        public IList<Result> Results { get; set; }
    }

    public class TheGuardianNewsResponse
    {
        [JsonProperty("response")]
        public Response Response { get; set; }
    }
}
