<%@ page contentType="text/html;charset=UTF-8" %>

<%@ taglib prefix="t" tagdir="/WEB-INF/tags" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>

<style>
    #page-layout {
        display: grid;
        grid-template-areas: "alert alert"
                             "search search"
                             "products cart";
        grid-column-gap: 20px;
        grid-template-rows: auto auto 1fr;
    }

    .product-layout {
        display: grid;
        grid-template-areas: "image description stock"
                             "image description addtobasket";
        grid-template-columns: 100px 1fr auto;
        grid-template-rows: 1fr auto;
        height: 180px;
    }

    .product-addtobasket {
        grid-area: addtobasket;
    }

    .product-image {
        grid-area: image;
        width: 90px;
    }

    .product-image img {
        width: 100%;
    }

    .product-stock {
        grid-area: stock;
    }

    .product-description {
        grid-area: description;
    }

    #search {
        grid-area: search;
    }

    #alert {
        grid-area: alert;
    }

    #products {
        grid-area: products;
    }

    #cart {
        grid-area: cart;
    }
</style>

<t:layout>
    <div id="page-layout">
        <div id="alert" hx-trigger="load, cart-updated from:body" hx-get="/webshop/shipping-info">
        </div>

        <div id="search" class="mb-2">
            <label>
                Search:
                <input type="search" class="form-control form-control-sm"
                       hx-trigger="keyup delay:250ms, search, changed delay:500ms"
                       hx-get="/webshop/search"
                       hx-target="#products"
                       name="q">
            </label>
        </div>

        <div id="products">
            <%@ include file="products.jsp" %>
        </div>
        <div id="cart" hx-trigger="cart-updated from:body" hx-get="/webshop/cart">
            <%@ include file="cart.jsp" %>
        </div>
    </div>
</t:layout>
