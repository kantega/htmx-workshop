# HTMX-workshop

HTMX is a powerful tool for building modern web applications without JavaScript.
In this workshop, we'll dive into the basics of HTMX and learn how to enhance your web projects with dynamic,
interactive features.

Ready to explore the world of HTMX and revolutionize the way you build web applications? Let's dive in and discover the
power of HTMX together!

## Exercise 1 - Dynamic "Add to cart"

In this exercise, you'll start with a traditional full-page-reload application where clicking the "Add" button refreshes
the entire page. Your task is to enhance the user experience by implementing HTMX to make the "Add" functionality
dynamic.

**Objective**  

Replace the full-page reload behavior with an HTMX request that adds a product to the shopping cart without refreshing
the entire page.

**Instructions**

Using the `hx-post` attribute, make the "Add to cart" form post to `/webshop/add-to-cart`. At present, this endpoint
returns the entire page, but we want to change this so that only the form is updated. Change the endpoint so it returns
a fragment of HTML containing only the form, plus the text "Added to cart". Use `hx-swap` to replace the entire form
with the html returned by the endpoint. The default behavior for `hx-target` is to swap out the element that made the
request, so that should suit us fine.

**Test that it works**

When you click the "Add to cart" button, you should see the text "Added to cart". However, the shopping cart in the
top right corner is not updated yet.

**Resources**

- https://htmx.org/docs
- https://htmx.org/attributes/hx-swap
- https://htmx.org/attributes/hx-target

As you might have noticed, the shopping cart doesn't update without a manual full page reload. Proceed to exercise 2 to
fix this.

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

**You can add the following line to the ```/webshop/add-to-cart``` endpoint:**

Spring MVC:```response.setHeader("HX-Trigger", "cart-updated");```  
.NET: ```Response.Headers.Add("HX-trigger", "cart-updated");```

Implement HTMX Event Listener: In the shopping cart component, add an HTMX event listener to listen for the custom event
defined in the server response header, so that it fetches the updated shopping cart from `/webshop/cart`.

**Resources**

- https://htmx.org/attributes/hx-trigger/#triggering-via-the-hx-trigger-header
- https://htmx.org/headers/hx-trigger

## Exercise 3 - Free shipping banner message

The webshop offers free shipping to customers shopping for more than 1000 kr. We want to add a banner to the top of
the page informing users how much more they have to spend to get free shipping.

**Objective**

Add a banner on the top of the page, and update it using `hx-trigger` when the page loads, and when items are added
to the shopping cart.

**Instructions**

Add a `<div>` to the top of the page. There is an endpoint called `/webshop/shipping-info` that will return the banner
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

Add a search box to the top of the page. There is a commented out html fragment in the `index` page you can use. Use
`hx-get` to fetch search results from the endpoint called `/webshop/search`. Listen for events `keyup`, `search`
and `changed`, and experiment with an appropriate `delay` to avoid searching after every keystroke.

**Resources**

- https://htmx.org/examples/active-search

## Exercise 5 - Fetching product stock status with HTMX on "load" Event Trigger and hx-indicator

Some services are a bit slow. In this webshop, figuring out how many items are in stock (the inventory) takes about a
second or two, and we don't want users to have to wait for this before the page loads. The solution is to lazy load
the inventory using a trigger when the page loads.

**Objective**

Display product inventory on page load. Use a loading indicator as a placeholder while the inventory loads. As a bonus,
update the inventory when a user puts an item in the basket.

**Instructions**

Add a `<div>` tag to the `products` page, and use `hx-trigger` to fetch the inventory from the endpoint
`/inventory?productId=<id>`. Add the `/three-dots.svg` image to use as a loading indicator. Read about the required
css classes and the `hx-indicator` attribute to connect it to the item being loaded.

To update the inventory information when a user adds a product to the shopping cart, you could send an event as an
HTTP Header as a response to `/webshop/add-to-cart`. You could for instance name the event
`stock-updated-<product id>`, to be able to differentiate between products. When sending the `HX-Trigger` HTTP Header,
you can add several events by separating them with a comma. Alternatively, use the json syntax for events to send 
events with data. Note that this requires the use of javascript to read the data.

**Resources**

- https://htmx.org/attributes/hx-indicator/
- https://htmx.org/headers/hx-trigger/

## Exercise 6 - Delete from cart

We don't have any way to remove items from the shopping cart. Let's fix that. 

**Objective**  

Add functionality to remove one item from the cart, and to clear the cart.

**Instructions** 


**Bonus:** If you want, you can add css-transitions to make a element fade out when deleting.
Useful resource:   
**https://htmx.org/attributes/hx-delete/**  
**https://htmx.org/examples/animations/#fade-out-on-swap**
