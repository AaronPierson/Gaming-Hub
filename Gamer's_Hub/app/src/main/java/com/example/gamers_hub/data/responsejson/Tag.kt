package com.example.gamers_hub.data.responsejson


import com.google.gson.annotations.SerializedName

data class Tag(
    @SerializedName("games_count")
    val gamesCount: Int,
    val id: Int,
    @SerializedName("image_background")
    val imageBackground: String,
    val language: String,
    val name: String,
    val slug: String
)