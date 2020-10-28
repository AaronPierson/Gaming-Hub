package com.example.gamers_hub.data.responsejson


import com.google.gson.annotations.SerializedName

data class AddedByStatus(
    val beaten: Int,
    val dropped: Int,
    val owned: Int,
    val playing: Int,
    val toplay: Int,
    val yet: Int
)