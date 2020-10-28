package com.example.gamers_hub

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.Menu
import android.widget.Toast
import androidx.appcompat.widget.SearchView
import com.example.gamers_hub.data.RAWGApiService
import kotlinx.android.synthetic.main.activity_gaminghub.*
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch

class GamingHubActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_gaminghub)
        setSupportActionBar(toolbar)
        GlobalScope.launch {
          val response = RAWGApiService()
              .getVideoGameSearchAsync("pikmin")
            //placeholder_textview.text = response.results[0].name.toString()
        }

    }

    override fun onCreateOptionsMenu(menu: Menu): Boolean {
        // Make menu to be displayed as the menu in the Toolbar
        menuInflater.inflate(R.menu.gaminghub_menu, menu)

        // Get the action_search menu item and store its SearchView in a variable
        val searchMenuItem = menu.findItem(R.id.action_search)
        val searchView = searchMenuItem.actionView as SearchView

        searchView.setOnQueryTextListener(object : SearchView.OnQueryTextListener {
            override fun onQueryTextSubmit(query: String?): Boolean {
                // Show a placeholder message
                Toast.makeText(this@GamingHubActivity, "Searched for $query",
                    Toast.LENGTH_LONG).show()
                //Set the title of the toolbar
                supportActionBar?.title = query
                // If the SearchView isn't showing as an icon yet, make it so.
                if (!searchView.isIconified)
                    searchView.isIconified = true
                // Collapse the search view and show only the icon
                searchMenuItem.collapseActionView()
                return false
            }

            // Don't do anything on text change
            override fun onQueryTextChange(newText: String?): Boolean {
                return false
            }

        })

        // Display the menu
        return true
    }



}