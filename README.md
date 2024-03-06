# HTMX-workshop

HTMX is a powerful tool for building modern web applications without JavaScript.
In this workshop, we'll introduce the basic concepts of HTMX by making progressive enhancements to a webshop.

## Run the application

Spring MVC: In a terminal, go to the folder `java` and run `mvn spring-boot:run` or use the run-button in your editor.
Then open a
browser and go to http://localhost:8080

ASP.NET: In a terminal, go to the folder `dotnet` and run `dotnet watch` to get hot-reload on changes made to Razor
files. A browser
should open automatically when the application is finished building.

## Exercise 1 - Dynamic "Add to cart"

In this exercise, you'll start with a traditional full-page-reload application where clicking the "Add" button refreshes
the entire page. Your task is to enhance the user experience by implementing HTMX to make the "Add" functionality
dynamic.

**Objective**

Replace the full-page reload behavior with an HTMX request that adds a product to the shopping cart without refreshing
the entire page.

**Instructions**

Find the "Add to cart" button on the Products page. The `<form>` currently posts to `/webshop/add-to-cart-full-reload`
but we want to change that. Remove the `method` and `action` attributes from the form. Then,
using the `hx-post` attribute, make the "Add to cart" form post to `/webshop/add-to-cart`,

This endpoint returns a fragment of HTML containing only the form, plus the text "Added to cart". Use `hx-swap` to
replace the entire form with the html returned by the endpoint. The default behavior for `hx-target` is to swap out the
element that made the request, so that should suit us fine.

**Test that it works**

When you click the "Add to cart" button, you should see the text "Added to cart". However, the shopping cart in the
top right corner is not updated yet. Proceed to exercise 2 to fix this.

If you click the "Add to cart" button twice, you may notice a full page reload on the second click. This is because
the "add-to-cart-success" page also needs the `hx-post` and `hx-swap` attributes added to the form.

**Resources**

- https://htmx.org/docs
- https://htmx.org/attributes/hx-swap
- https://htmx.org/attributes/hx-target

## Exercise 2 - Updating Shopping Cart state with hx-trigger

We want the shopping cart in the top right corner to update automatically when we add new items to the cart.
This can be achieved by making it listen for an event that we trigger when the item is added. We can send the event
as an HTTP Header from the server in the response from the `/webshop/add-to-cart` endpoint.

**Objective**

Update the shopping cart in the top right corner when the user clicks the "Add to cart" button, without doing a full
page reload.

**Instructions**

Define Custom Event: Modify the server response to include a custom event in the response header when a product is
successfully added to the cart. This custom event should be unique and descriptive, such as "cart-updated".

**You can add the following line to the ```/webshop/add-to-cart``` endpoint, before the return statement:**

Spring MVC:```response.setHeader("HX-Trigger", "cart-updated");```  
.NET: ```Response.Headers.Add("HX-trigger", "cart-updated");```

Implement HTMX Event Listener: In the shopping cart component in the index file, add an HTMX event listener (hx-trigger)
to listen for the custom event
defined in the server response header, so that it fetches the updated shopping cart from `/webshop/cart`.

**Test that it works**

Restart the application to apply the changes made to the endpoint.
Try adding a product to the cart. The cart should be updated without having to do a manual page reload. Check the
network pane in your browser to see the requests being made to the backend.

**Resources**

- https://htmx.org/attributes/hx-trigger/#triggering-via-the-hx-trigger-header
- https://htmx.org/headers/hx-trigger

## Exercise 3 - Free shipping banner message

The web shop offers free shipping to customers shopping for more than 1000 kr. We want to add a banner to the top of
the page informing users how much more they have to spend to get free shipping.

**Objective**

Add a banner on the top of the page, and update it using `hx-trigger` when the page loads, and when items are added
to the shopping cart.

**Instructions**

Use the empty div with id="banner" in the index file. There is an endpoint called `/webshop/shipping-info` that will
return the banner
text. Use `hx-trigger` in combination with `hx-get` to fetch the contents. You can listen to several events
using a comma separated list of event names.

**Resources**

- https://htmx.org/docs/#special-events
- https://htmx.org/attributes/hx-trigger

## Exercise 4 - Active search

To make it easier for users to find products, we need a search box. We want the results to show up as the user types,
after a small delay to save bandwidth.

**Objective**

Create a search box that filters products as the user types

**Instructions**

- Use the search box at the top of the page. There is a non-working html fragment in the `index` page you can use.
- Use `hx-get` to fetch search results from the endpoint called `/webshop/search` on the input element.
- Use `hx-trigger` to listen for events `keyup`, `search` and `changed`, and experiment with an appropriate `delay` to
  avoid searching after every keystroke.
- Use `hx-target` to replace the list of products on the page with the search results.

**Resources**

- https://htmx.org/examples/active-search

## Exercise 5 - Fetching product stock status with HTMX on "load" Event Trigger and hx-indicator

Some services are a bit slow. In this webshop, figuring out how many items are in stock (the inventory) takes about a
second or two, and we don't want users to have to wait for this before the page loads. The solution is to lazy load
the inventory using a trigger when the page loads.

**Objective**

Display product inventory on page load. Use a loading indicator as a placeholder while the inventory loads. As a bonus,
update the inventory when a user adds or removes an item from the shopping cart.

**Instructions**

There is an empty `<div>` tag in the `products` page with the class name `product-stock`. Use `hx-get`to fetch the
inventory from the endpoint
`/inventory?productId=<id>` and use the `hx-trigger` to trigger this on page load.
Add the `/three-dots.svg` image to use as a loading indicator. Read about the required
css classes and the `hx-indicator` attribute to connect it to the item being loaded.

To update the inventory information when a user adds a product to the shopping cart, you could send an event as an
HTTP Header as a response to `/webshop/add-to-cart`. You could for instance name the event
`stock-updated-<product id>`, to be able to differentiate between products. When sending the `HX-Trigger` HTTP Header,
you can add several events by separating them with a comma. Alternatively, use the json syntax for events to send
events with data. Note that this requires the use of javascript to read the data.

**Resources**

- https://htmx.org/attributes/hx-indicator/
- https://htmx.org/headers/hx-trigger/
- https://htmx.org/docs/#special-events

## Exercise 6 - Delete from cart

Removing items from the shopping cart reloads the entire page. Let's fix that.

**Objective**

Add functionality to remove one item from the cart, and to clear the cart. Make sure the inventory count is updated
on the page.

**Instructions**

To remove an item from the shopping cart, remove the `action` and `method` attributes from the form wrapping the button.
Send a post request to the endpoint `/webshop/remove-from-cart`.

To clear the cart, remove the entire form wrapping the button. Make the button send a delete request to `/webshop/cart`.

Send an `HX-Trigger` HTTP Header to update inventory for the items removed from the cart, and to trigger reloading of
the cart.

**Bonus:**

If you want, you can add css-transitions to make an element fade out when deleting.

Useful resource:   
**https://htmx.org/attributes/hx-delete/**  
**https://htmx.org/examples/animations/#fade-out-on-swap**
