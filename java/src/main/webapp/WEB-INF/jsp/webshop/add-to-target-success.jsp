<%@ page contentType="text/html;charset=UTF-8" %>

<form hx-post="/webshop/add-to-cart"
      hx-target="this"
      hx-swap="outerHTML"
>
    <input type="hidden" name="productId" value="${product.id}">

    <button class="btn btn-primary mt-4">
        <i class="bi bi-cart-plus"></i>
        Add to cart
    </button>

    <div class="alert alert-info">Added to cart!</div>
</form>
