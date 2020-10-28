package com.example.gamers_hub.data


import com.example.gamers_hub.data.responsejson.GameSearchResponse
//import com.jakewharton.retrofit2.adapter.kotlin.coroutines.experimental.CoroutineCallAdapterFactory
import kotlinx.coroutines.Deferred
import okhttp3.Interceptor
import okhttp3.OkHttpClient
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import retrofit2.http.GET
import retrofit2.http.Query

const val API_KEY = "cccf617d082948b2820d2b26262789c9"

interface RAWGApiService {
    @GET("games?")
    fun getVideoGameSearchAsync(
        @Query("search") VideoGameName: String
    ): GameSearchResponse
    // Kotlin doesn't support Java-like static class members.
    // Instead, whatever is put into a companion object can be accessed directly on the class.
    // e.g. OpenWeatherApiService.someFunction()
    companion object{
        // This adds a nice syntax - it looks like we're instantiating
        // a new object with a constructor, while in fact we're just calling a function.

        operator fun invoke(): RAWGApiService {
            val apiKeyInterceptor = Interceptor { chain ->
                val url = chain.request()
                //Get the current url
                    .url()
                    .newBuilder()
                    .addQueryParameter("appid", API_KEY)
                    .build()

                // Set the update
                val request = chain.request()
                    .newBuilder()
                    .url(url)
                    .build()
                //continue
                return@Interceptor  chain.proceed(request)
            }

            val okHttpClient = OkHttpClient.Builder()
                .build()

            return Retrofit.Builder()
                .client(okHttpClient)
                .baseUrl("https://api.rawg.io/api/")
                    //
                //.addCallAdapterFactory(CoroutineCallAdapterFactory())
                .addConverterFactory(GsonConverterFactory.create())
                .build()
                .create(RAWGApiService::class.java)
        }
    }
}