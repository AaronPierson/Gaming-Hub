package com.example.gamers_hub.data.responsejson


import com.google.gson.annotations.SerializedName

data class Result(
    val added: Int,
    @SerializedName("added_by_status")
    val addedByStatus: AddedByStatus,
    @SerializedName("background_image")
    val backgroundImage: String,
    val clip: Any,
    @SerializedName("community_rating")
    val communityRating: Int,
    @SerializedName("dominant_color")
    val dominantColor: String,
    val genres: List<Genre>,
    val id: Int,
    val metacritic: Any,
    val name: String,
    @SerializedName("parent_platforms")
    val parentPlatforms: List<ParentPlatform>,
    val platforms: List<PlatformX>,
    val playtime: Int,
    val rating: Double,
    @SerializedName("rating_top")
    val ratingTop: Int,
    val ratings: List<Rating>,
    @SerializedName("ratings_count")
    val ratingsCount: Int,
    val released: String,
    @SerializedName("reviews_count")
    val reviewsCount: Int,
    @SerializedName("reviews_text_count")
    val reviewsTextCount: Int,
    @SerializedName("saturated_color")
    val saturatedColor: String,
    val score: String,
    @SerializedName("short_screenshots")
    val shortScreenshots: List<ShortScreenshot>,
    val slug: String,
    val stores: List<Store>,
    @SerializedName("suggestions_count")
    val suggestionsCount: Int,
    val tags: List<Tag>,
    val tba: Boolean,
    @SerializedName("user_game")
    val userGame: Any
)