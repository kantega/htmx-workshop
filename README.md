# HTMX-workshop 

HTMX is a powerful tool for building modern web applications without JavaScript.
In this workshop, we'll dive into the basics of HTMX and learn how to enhance your web projects with dynamic, interactive features.

Ready to explore the world of HTMX and revolutionize the way you build web applications? Let's dive in and discover the power of HTMX together!

## Exercise 1 - Implementing HTMX for Dynamic "Add product to cart" Functionality
In this exercise, you'll start with a traditional full-page-reload application where clicking the "Add" button refreshes the entire page. Your task is to enhance the user experience by implementing HTMX to make the "Add" functionality dynamic.

**Objective**  
The objective of this exercise is to replace the full-page reload behavior with an HTMX request that adds a product to the shopping cart without refreshing the entire page.

**Instructions**  
Understanding the Code: Familiarize yourself with the existing HTML. Take note of how the "Add" button triggers a full-page reload when clicked.
Integrate HTMX: Integrate HTMX into the project by including the necessary hx-attributes in your HTML file.

Implement HTMX Request: Modify the "Add" button to send a hx-post request to the server when clicked. This request should add the selected product to the shopping cart on the server side. You can send the request to the endpoint: ```"/cart/add/product/{id}"```

Update UI Dynamically: Once the product has been successfully added to the cart on the server, swap out the "Add" button with the response received from the server.

Useful resource: **https://htmx.org/attributes/hx-swap/**

As you might have noticed, the shopping cart doesn´t update without a full page reload. Proceed to exercise 2 to fix this. 

## Exercise 2 - Updating Shopping Cart state with hx-trigger

In this exercise, you'll build upon the previous exercise by enhancing the shopping cart's functionality using HTMX events.
You'll implement an HTMX event listener in the shopping cart component to update its state when a product is added to the cart.s
Additionally, you'll define a custom event in the server response header to trigger the HTMX event on the client side.

**Objective**  
The objective of this exercise is to leverage HTMX events to dynamically update the shopping cart's state.
By the end of this exercise, you'll have a more responsive and synchronized shopping cart that reflects changes made on the server side in real-time.

**Instructions**  
Define Custom Event: Modify the server response to include a custom event in the response header when a product is successfully added to the cart. This custom event should be unique and descriptive, such as "add-to-shopping-cart".  

**You can add the following line to the ```/cart/add/product/{id}``` endpoint:**

Spring MVC:```response.setHeader("HX-Trigger", "add-to-shopping-cart");```  
.NET: ```Response.Headers.Add("HX-trigger", "add-to-shopping-cart");```


Implement HTMX Event Listener: In the shopping cart component, add an HTMX event listener to listen for the custom event defined in the server response header.
When triggered, the shopping cart should fetch the updated shopping cart-state accordingly without refreshing the entire page.


Useful resource: **https://htmx.org/attributes/hx-trigger/#triggering-via-the-hx-trigger-header**   

## Exercise 3 - Fetching product stock status with HTMX on "load" Event Trigger and hx-indicator
In this exercise, you'll enhance the user experience by implementing a stock status retrieval mechanism using HTMX triggered on the "load" event. By utilizing HTMX to fetch stock status data upon page load, users will receive immediate feedback on product availability without manual interaction.

**Objective**  
The objective of this exercise is to leverage HTMX to retrieve and display product stock status upon page load. By the end of this exercise, users will have access to real-time stock information without waiting for manual queries.

Useful resource: **https://htmx.org/attributes/hx-indicator/**

## Exercise 4 - Implementing product deletion and clear shopping-cart with hx-delete

In this exercise, you'll further enhance the shopping cart functionality by allowing users to delete individual products from the cart and emptying the entire cart using HTMX hx-delete requests. This will provide users with more control over their shopping experience without the need for page refreshes.

**Objective**  
The objective of this exercise is to implement product deletion and cart emptying functionalities using hx-delete requests. By the end of this exercise, users will be able to remove specific products from their cart or clear the entire cart with ease.

**Bonus:** If you want, you can add css-transitions to make a element fade out when deleting.
Useful resource:   
**https://htmx.org/attributes/hx-delete/**  
**https://htmx.org/examples/animations/#fade-out-on-swap**



## Exercise 5 - Implementing active search with HTMX

In this exercise, you'll introduce active search functionality to your web application using HTMX. Active search allows users to receive real-time search results as they type, providing a more dynamic and responsive search experience without the need for manual submission.

**Objective**

The objective of this exercise is to implement active search functionality using HTMX, enabling users to receive instant search results as they type in the search input field. By the end of this exercise, users will enjoy a smoother and more interactive search experience.

Useful resource:   
**https://htmx.org/examples/active-search/**