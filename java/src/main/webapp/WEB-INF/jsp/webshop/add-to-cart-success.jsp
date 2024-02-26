<%@ page contentType="text/html;charset=UTF-8" %>

<form hx-post="/webshop/add-to-cart"
      hx-target="this"
      hx-swap="outerHTML"
>
    <input type="hidden" name="productId" value="${product.id}">

    <div class="alert alert-success alert-height mb-2">Added to cart!</div>
    <button class="btn btn-primary">
        <i class="bi bi-cart-plus"></i>
        Add to cart
    </button>

</form>