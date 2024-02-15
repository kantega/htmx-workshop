<%@ taglib prefix="t" tagdir="/WEB-INF/tags" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>

<style>
    #page-layout {
        display: grid;
        grid-template-areas: "products cart";
        grid-column-gap: 20px;
    }

    .product-layout {
        display: grid;
        grid-template-areas: "image description  stock"
                             "image description  addtobasket";
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
</style>

<t:layout>
    <div id="page-layout">
        <div id="products">
            <c:forEach var="product" items="${products}">
                <div class="card mb-2">
                    <div class="card-header d-flex justify-content-between align-items-center">
                        <div>
                            <h3>${product.name}</h3>
                        </div>
                        <div>
                            <fmt:formatNumber value="${product.price}" type="currency"/>
                        </div>
                    </div>
                    <div class="card-body product-layout">
                        <div class="product-image">
                            <img src="${product.image}"/>
                        </div>
                        <div class="product-description">
                            <p>${product.description}</p>
                        </div>
                        <div class="product-stock" hx-trigger="load" hx-get="/inventory?productId=${product.id}">
                            <img src="/three-dots.svg" style="width: 30px" class="hx-indicator"/>
                        </div>
                        <div class="product-addtobasket">
                            <form>
                                <input type="hidden" name="productId" value="${product.id}">

                                <button class="btn btn-primary mt-4"
                                        hx-post="/webshop/add-to-cart"
                                        hx-target="#cart"
                                        hx-swap="innerHTML"
                                >
                                    <i class="bi bi-cart-plus"></i>
                                    Add to cart
                                </button>

                            </form>
                        </div>
                    </div>
                </div>
            </c:forEach>
        </div>
        <div id="cart">
            <%@ include file="cart.jsp" %>
        </div>
    </div>
</t:layout>
