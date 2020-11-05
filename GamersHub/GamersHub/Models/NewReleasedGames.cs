namespace RAWGQT
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class NewReleasedGames
    {
        [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
        public long? Count { get; set; }

        [JsonProperty("next", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public List<Result> Results { get; set; }

        [JsonProperty("seo_title", NullValueHandling = NullValueHandling.Ignore)]
        public string SeoTitle { get; set; }

        [JsonProperty("seo_description", NullValueHandling = NullValueHandling.Ignore)]
        public string SeoDescription { get; set; }

        [JsonProperty("seo_keywords", NullValueHandling = NullValueHandling.Ignore)]
        public string SeoKeywords { get; set; }

        [JsonProperty("seo_h1", NullValueHandling = NullValueHandling.Ignore)]
        public string SeoH1 { get; set; }

        [JsonProperty("noindex", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Noindex { get; set; }

        [JsonProperty("nofollow", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Nofollow { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public Filters Filters { get; set; }

        [JsonProperty("nofollow_collections", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> NofollowCollections { get; set; }
    }

    public partial class Filters
    {
        [JsonProperty("years", NullValueHandling = NullValueHandling.Ignore)]
        public List<FiltersYear> Years { get; set; }
    }

    public partial class FiltersYear
    {
        [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
        public long? From { get; set; }

        [JsonProperty("to", NullValueHandling = NullValueHandling.Ignore)]
        public long? To { get; set; }

        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public string Filter { get; set; }

        [JsonProperty("decade", NullValueHandling = NullValueHandling.Ignore)]
        public long? Decade { get; set; }

        [JsonProperty("years", NullValueHandling = NullValueHandling.Ignore)]
        public List<YearYear> Years { get; set; }

        [JsonProperty("nofollow", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Nofollow { get; set; }

        [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
        public long? Count { get; set; }
    }

    public partial class YearYear
    {
        [JsonProperty("year", NullValueHandling = NullValueHandling.Ignore)]
        public long? Year { get; set; }

        [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
        public long? Count { get; set; }

        [JsonProperty("nofollow", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Nofollow { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("slug", NullValueHandling = NullValueHandling.Ignore)]
        public string Slug { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("released")]
        public object Released { get; set; }

        [JsonProperty("tba", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Tba { get; set; }

        [JsonProperty("background_image")]
        public Uri BackgroundImage { get; set; }

        [JsonProperty("rating", NullValueHandling = NullValueHandling.Ignore)]
        public long? Rating { get; set; }

        [JsonProperty("rating_top", NullValueHandling = NullValueHandling.Ignore)]
        public long? RatingTop { get; set; }

        [JsonProperty("ratings", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Ratings { get; set; }

        [JsonProperty("ratings_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? RatingsCount { get; set; }

        [JsonProperty("reviews_text_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? ReviewsTextCount { get; set; }

        [JsonProperty("added", NullValueHandling = NullValueHandling.Ignore)]
        public long? Added { get; set; }

        [JsonProperty("added_by_status")]
        public AddedByStatus AddedByStatus { get; set; }

        [JsonProperty("metacritic")]
        public object Metacritic { get; set; }

        [JsonProperty("playtime", NullValueHandling = NullValueHandling.Ignore)]
        public long? Playtime { get; set; }

        [JsonProperty("suggestions_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? SuggestionsCount { get; set; }

        [JsonProperty("user_game")]
        public object UserGame { get; set; }

        [JsonProperty("reviews_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? ReviewsCount { get; set; }

        [JsonProperty("community_rating", NullValueHandling = NullValueHandling.Ignore)]
        public long? CommunityRating { get; set; }

        [JsonProperty("saturated_color", NullValueHandling = NullValueHandling.Ignore)]
        public Color? SaturatedColor { get; set; }

        [JsonProperty("dominant_color", NullValueHandling = NullValueHandling.Ignore)]
        public Color? DominantColor { get; set; }

        [JsonProperty("platforms", NullValueHandling = NullValueHandling.Ignore)]
        public List<PlatformElement> Platforms { get; set; }

        [JsonProperty("parent_platforms", NullValueHandling = NullValueHandling.Ignore)]
        public List<ParentPlatform> ParentPlatforms { get; set; }

        [JsonProperty("genres", NullValueHandling = NullValueHandling.Ignore)]
        public List<Genre> Genres { get; set; }

        [JsonProperty("stores", NullValueHandling = NullValueHandling.Ignore)]
        public List<Store> Stores { get; set; }

        [JsonProperty("clip")]
        public object Clip { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<Genre> Tags { get; set; }

        [JsonProperty("short_screenshots", NullValueHandling = NullValueHandling.Ignore)]
        public List<ShortScreenshot> ShortScreenshots { get; set; }
    }

    public partial class AddedByStatus
    {
        [JsonProperty("owned", NullValueHandling = NullValueHandling.Ignore)]
        public long? Owned { get; set; }
    }

    public partial class Genre
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("slug", NullValueHandling = NullValueHandling.Ignore)]
        public string Slug { get; set; }

        [JsonProperty("games_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? GamesCount { get; set; }

        [JsonProperty("image_background", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageBackground { get; set; }

        [JsonProperty("domain", NullValueHandling = NullValueHandling.Ignore)]
        public string Domain { get; set; }

        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public Language? Language { get; set; }
    }

    public partial class ParentPlatform
    {
        [JsonProperty("platform", NullValueHandling = NullValueHandling.Ignore)]
        public ParentPlatformPlatform Platform { get; set; }
    }

    public partial class ParentPlatformPlatform
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("slug", NullValueHandling = NullValueHandling.Ignore)]
        public string Slug { get; set; }
    }

    public partial class PlatformElement
    {
        [JsonProperty("platform", NullValueHandling = NullValueHandling.Ignore)]
        public PlatformPlatform Platform { get; set; }

        [JsonProperty("released_at")]
        public DateTimeOffset? ReleasedAt { get; set; }

        [JsonProperty("requirements_en")]
        public object RequirementsEn { get; set; }

        [JsonProperty("requirements_ru")]
        public object RequirementsRu { get; set; }
    }

    public partial class PlatformPlatform
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("slug", NullValueHandling = NullValueHandling.Ignore)]
        public string Slug { get; set; }

        [JsonProperty("image")]
        public object Image { get; set; }

        [JsonProperty("year_end")]
        public object YearEnd { get; set; }

        [JsonProperty("year_start")]
        public object YearStart { get; set; }

        [JsonProperty("games_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? GamesCount { get; set; }

        [JsonProperty("image_background", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ImageBackground { get; set; }
    }

    public partial class ShortScreenshot
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Image { get; set; }
    }

    public partial class Store
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("store", NullValueHandling = NullValueHandling.Ignore)]
        public Genre StoreStore { get; set; }

        [JsonProperty("url_en", NullValueHandling = NullValueHandling.Ignore)]
        public Uri UrlEn { get; set; }

        [JsonProperty("url_ru")]
        public string UrlRu { get; set; }
    }

    public enum Color { The0F0F0F };

    public enum Language { Eng };

    public partial class NewReleasedGames
    {
        public static NewReleasedGames FromJson(string json) => JsonConvert.DeserializeObject<NewReleasedGames>(json, RAWGQT.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this NewReleasedGames self) => JsonConvert.SerializeObject(self, RAWGQT.Converter.Settings);
    }


    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ColorConverter.Singleton,
                LanguageConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ColorConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Color) || t == typeof(Color?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "0f0f0f")
            {
                return Color.The0F0F0F;
            }
            throw new Exception("Cannot unmarshal type Color");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Color)untypedValue;
            if (value == Color.The0F0F0F)
            {
                serializer.Serialize(writer, "0f0f0f");
                return;
            }
            throw new Exception("Cannot marshal type Color");
        }

        public static readonly ColorConverter Singleton = new ColorConverter();
    }

    internal class LanguageConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Language) || t == typeof(Language?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "eng")
            {
                return Language.Eng;
            }
            throw new Exception("Cannot unmarshal type Language");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Language)untypedValue;
            if (value == Language.Eng)
            {
                serializer.Serialize(writer, "eng");
                return;
            }
            throw new Exception("Cannot marshal type Language");
        }

        public static readonly LanguageConverter Singleton = new LanguageConverter();
    }
}
