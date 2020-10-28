package com.example.gamers_hub.data.responsejson


import com.google.gson.annotations.SerializedName

data class GameSearchResponse(
  //  val count: Int,
  //  val next: String,
  //  val previous: Any,
    val results: List<Result>
 //   @SerializedName("user_platforms")
 //   val userPlatforms: Boolean
)